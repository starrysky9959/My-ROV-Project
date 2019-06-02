/******************************************************************************
  * @file    MS5837.c
  * @author  ???
  * @version V1.0
  * @date    ????-??-??
  * @brief   MS5837深度传感器，由官方提供的驱动代码（删除了没有用到的CRC校验部分）为ROV提供深度、温度、压强信息
	* @attention MS5837-30BA传感器芯片在进行I2C通信时是不会回传Acknowledge的（怎么可以酱紫ミ(?゜д゜)?当时研究了半天），
							 因此不可利用是否回传Acknowledge来确认芯片是否处于正常工作
							 使用方法：调用MS5837_Read函数，即可从MS5837_Val结构体中获取传感器信息
							 白线SDA 绿线SCL
*******************************************************************************/

#include "MS5837.h"
#include "stm32f4xx.h"
#include "systick.h"

/********************************************官方定义的相关常量********************************************/
#define  Pa 						100.0f
#define  bar  					0.001f
#define  mbar  					1.0f
#define  fluidDensity   997.0f//淡水密度997kg/m3  ，海水1029


/********************************************官方定义的相关变量********************************************/
uint16_t C[8];
uint32_t D1, D2;
int32_t Temp;
int32_t P;

IIC_STRUCT MS5837_I2C;//模拟I2C定义的结构体，模拟I2C代码见I2C.c
MS5837_ValueTypeDef MS5837_Val={0,0,0,0.02};

/**************************************************************
 * @brief 给MS5837发送复位指令,上电第一件事必须复位，否则无法正常工作
 * @param
 * @retval 复位操作
 * @addition
**************************************************************/
static uint8_t MS5837_Reset(void) 
{
	return MS5837_WriteByte(MS5837_I2C,MS5837_ADDRESS,0x1e, 0x1e);//0x1e为复位指令
}


/**************************************************************
 * @brief 计算压力值，官方给出的计算公式代码，没兴趣可以不看
 * @param
 * @retval
 * @addition
**************************************************************/
static void MS5837_Calculate(void) 
{
	// Given C1-C6 and D1, D2, MS5837_Calculated Temp and P
	// Do conversion first and then second order temp compensation
	
	int32_t dT;
	int64_t SENS;
	int64_t OFF;
	int32_t SENSi; 
	int32_t OFFi;  
	int32_t Ti;    
	int64_t OFF2;
	int64_t SENS2;
	
	// Terms called
	dT = D2-(uint32_t)(C[5])*256l;
	SENS = (int64_t)(C[1])*32768l+((int64_t)(C[3])*dT)/256l;
	OFF = (int64_t)(C[2])*65536l+((int64_t)(C[4])*dT)/128l;
	
	
	//Temp and P conversion
	Temp = 2000l+(int64_t)(dT)*C[6]/8388608LL;
	P = (D1*SENS/(2097152l)-OFF)/(8192l);
	
	//Second order compensation
	if((Temp/100)<20){         //Low temp
		Ti = (3*(int64_t)(dT)*(int64_t)(dT))/(8589934592LL);
		OFFi = (3*(Temp-2000)*(Temp-2000))/2;
		SENSi = (5*(Temp-2000)*(Temp-2000))/8;
		if((Temp/100)<-15){    //Very low temp
			OFFi = OFFi+7*(Temp+1500l)*(Temp+1500l);
			SENSi = SENSi+4*(Temp+1500l)*(Temp+1500l);
		}
	}
	else if((Temp/100)>=20){    //High temp
		Ti = 2*(dT*dT)/(137438953472LL);
		OFFi = (1*(Temp-2000)*(Temp-2000))/16;
		SENSi = 0;
	}
	
	OFF2 = OFF-OFFi;           //Calculate pressure and temp second order
	SENS2 = SENS-SENSi;
	
	Temp = (Temp-Ti);
	P = (((D1*SENS2)/2097152l-OFF2)/8192l);
}


/**************************************************************
 * @brief 得到传感器中的原始数据
 * @param
 * @retval
 * @addition
**************************************************************/
static void MS5837_Getdata(void)
{
	uint8_t bufe[3];
	MS5837_WriteByte(MS5837_I2C,MS5837_ADDRESS,0x48, 0x00);
	I2C_delay_ms(20);
	MS5837_ReadBuffer(MS5837_I2C,MS5837_ADDRESS,bufe,0x00, 3);	
	D1=bufe[0]<<16|bufe[1]<<8|bufe[2];
	MS5837_WriteByte(MS5837_I2C,MS5837_ADDRESS,0x58, 0x00);
	I2C_delay_ms(20);
	MS5837_ReadBuffer(MS5837_I2C,MS5837_ADDRESS,bufe,0x00, 3);	
	D2=bufe[0]<<16|bufe[1]<<8|bufe[2];	
}


/**************************************************************
 * @brief 计算压强
 * @param conversion：压强单位转换权值
 * @retval 实际压强值
 * @addition
**************************************************************/
float MS5837_pressure(float conversion) 
{
	return ((float)P)/10.0f*conversion;
}


/**************************************************************
 * @brief 计算温度
 * @param
 * @retval
 * @addition 实际温度值
**************************************************************/
float MS5837_temperature(void) 
{
	return Temp/100.0f;
}

/**************************************************************
 * @brief 计算深度
 * @param
 * @retval
 * @addition 实际深度(单位：m)
**************************************************************/
float MS5837_depth(void) 
{
	return (MS5837_pressure(Pa)-101300)/(fluidDensity*9.80665);
}


/**************************************************************
 * @brief 设置水深修正补偿值
 * @param offset：修正值
 * @retval
 * @addition 
**************************************************************/
void MS5837_SetOffset(float offset)
{
	MS5837_Val.offset=offset;
}


/**************************************************************
 * @brief 初始化水深传感器
 * @param 
 * @retval
 * @addition 
**************************************************************/
void MS5837_Init(void) 
{
	uint8_t buf[2];//用于存储从水深传感器中读取的参数

	I2C_Struct_Config(&MS5837_I2C,GPIOB,GPIO_Pin_8,GPIOB,GPIO_Pin_9);//初始化水深传感器所用模拟I2C结构体，定义相关引脚
	
	I2C_Simu_Init(MS5837_I2C);//初始化水深传感器所用模拟I2C
	
	MS5837_Reset();//使用前先复位
	
  MS5837_ReadBuffer(MS5837_I2C,MS5837_ADDRESS,buf,0xa0, 2);//读取传感器芯片中相关常数值，用于之后的计算
  C[0] = buf[0] << 8 |buf[1];
   MS5837_ReadBuffer(MS5837_I2C,MS5837_ADDRESS,buf,0xa2, 2);
  C[1] = buf[0] << 8 |buf[1];
   MS5837_ReadBuffer(MS5837_I2C,MS5837_ADDRESS,buf,0xa4, 2);
  C[2] = buf[0] << 8 |buf[1];
   MS5837_ReadBuffer(MS5837_I2C,MS5837_ADDRESS,buf,0xa6, 2);
  C[3] = buf[0] << 8 |buf[1];
   MS5837_ReadBuffer(MS5837_I2C,MS5837_ADDRESS,buf,0xa8, 2);
  C[4] = buf[0] << 8 |buf[1];
   MS5837_ReadBuffer(MS5837_I2C,MS5837_ADDRESS,buf,0xaa, 2);
  C[5] = buf[0] << 8 |buf[1]; 
    MS5837_ReadBuffer(MS5837_I2C,MS5837_ADDRESS,buf,0xac, 2);
  C[6] = buf[0] << 8 |buf[1];
	MS5837_Read();//第一次读取
	MS5837_SetOffset(MS5837_depth()*100.0);//设定当前深度基准值，同时将深度单位转化为厘米
	
}


/**************************************************************
 * @brief 得到传感器中的最终数据并将值赋给MS5837结构体
 * @param 
 * @retval
 * @addition 
**************************************************************/
void MS5837_Read(void) 
{
	static float last_val_depth=0;
	static float lastest_val_depth=0;
	static float lastestest_val_depth=0;//设置四个变量，用于存储前四次读取所得深度值，之后取平均滤波用
	float now_val;
	MS5837_Getdata();//获取初始值
	MS5837_Calculate();//计算初始值得到最终数据
	MS5837_Val.temp=MS5837_temperature();//获取温度（没什么用）
	now_val=MS5837_depth();
	
	if(now_val*100.0<-10||now_val*100.0>200)//异常值处理，实际使用中由于干扰，会出现深度传感器返回非常大的异常值的情况
		return;
	
	lastestest_val_depth=lastest_val_depth;//顺延赋值
	lastest_val_depth=last_val_depth;
	last_val_depth=MS5837_Val.depth;
	
	MS5837_Val.depth=((now_val*100.0-MS5837_Val.offset)+last_val_depth+lastest_val_depth+lastestest_val_depth)/4;//将前四次的深度值取平均
	MS5837_Val.pressure=MS5837_pressure(Pa);//获取压强单位为Pa（也没什么用哦╮(╯_╰)╭）
}
