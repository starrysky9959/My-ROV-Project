/************************************模拟I2C底层驱动代码********************************/
/*
关于模拟I2C：
	所谓硬件I2C对应芯片上的I2C外设，有相应I2C驱动电路，其所使用的I2C管脚也是专用的；
	软件I2C则使用GPIO管脚，用软件控制管脚状态以模拟I2C通信波形。
	硬件I2C的效率要远高于软件的，而软件I2C由于不受管脚限制，接口比较灵活。
	模拟I2C 是通过GPIO，软件模拟寄存器的工作方式，而硬件（固件）I2C是直接调用内部寄存器进行配置。
	如果要从具体硬件上来看，可以去看下芯片手册。因为固件I2C的端口是固定的，所以会有所区别。

使用说明：
	本.c文件思路与普通模拟I2C稍有不同，采用类似面向对象的编程思路，自定义了一个IIC_STRUCT结构体。
	使用时先初始化一个自定义IIC_STRUCT结构体，内含I2C所用端口、时钟、引脚，再按照此结构体进行初始化。
	在实际使用模拟I2C时，也需要调用此IIC_STRUCT结构体对所用的模拟I2C进行指称。
	这样做的好处是，同一个.c文件可以实例化多个I2C，从而拥有多个I2C总线。（不过I2C总线本来就可以一对多，这么一想，好像这个设计没什么用呢_(:зゝ∠)_）
*/

#include "I2C.h"


/*
IIC_STRUCT结构体初始化程序，输入时钟线、信号线的端口和引脚，完成对IIC_STRUCT结构体内各成员的配置
*/
void I2C_Struct_Config(IIC_STRUCT *I2C,GPIO_TypeDef *SCL_GPIO_Port,uint32_t SCL_Pin,GPIO_TypeDef * SDA_GPIO_Port,uint32_t SDA_Pin)
{
	I2C->SCL_GPIO_Port=SCL_GPIO_Port;
	I2C->SDA_GPIO_Port=SDA_GPIO_Port;
	if(SCL_GPIO_Port==GPIOA) I2C->SCL_GPIO_CLK=RCC_AHB1Periph_GPIOA;//我也很想用switch，但是指针变量不能用于switch￣へ￣
	if(SCL_GPIO_Port==GPIOB) I2C->SCL_GPIO_CLK=RCC_AHB1Periph_GPIOB;
	if(SCL_GPIO_Port==GPIOC) I2C->SCL_GPIO_CLK=RCC_AHB1Periph_GPIOC;
	if(SCL_GPIO_Port==GPIOD) I2C->SCL_GPIO_CLK=RCC_AHB1Periph_GPIOD;
	if(SCL_GPIO_Port==GPIOE) I2C->SCL_GPIO_CLK=RCC_AHB1Periph_GPIOE;
	if(SCL_GPIO_Port==GPIOF) I2C->SCL_GPIO_CLK=RCC_AHB1Periph_GPIOF;
	if(SCL_GPIO_Port==GPIOG) I2C->SCL_GPIO_CLK=RCC_AHB1Periph_GPIOG;
	
	if(SDA_GPIO_Port==GPIOA) I2C->SDA_GPIO_CLK=RCC_AHB1Periph_GPIOA;
	if(SDA_GPIO_Port==GPIOB) I2C->SDA_GPIO_CLK=RCC_AHB1Periph_GPIOB;
	if(SDA_GPIO_Port==GPIOC) I2C->SDA_GPIO_CLK=RCC_AHB1Periph_GPIOC;
	if(SDA_GPIO_Port==GPIOD) I2C->SDA_GPIO_CLK=RCC_AHB1Periph_GPIOD;
	if(SDA_GPIO_Port==GPIOE) I2C->SDA_GPIO_CLK=RCC_AHB1Periph_GPIOE;
	if(SDA_GPIO_Port==GPIOF) I2C->SDA_GPIO_CLK=RCC_AHB1Periph_GPIOF;
	if(SDA_GPIO_Port==GPIOG) I2C->SDA_GPIO_CLK=RCC_AHB1Periph_GPIOG;
	
	I2C->SCL_Pin=SCL_Pin;
	I2C->SDA_Pin=SDA_Pin;
}

/*
模拟I2C初始化程序，根据输入IIC_STRUCT结构体的成员信息，对相应GPIO进行初始化。
*/
void I2C_Simu_Init(IIC_STRUCT I2C)
{
	GPIO_InitTypeDef GPIO_InitStructure;
	
	//打开GPIO时钟 
	RCC_AHB1PeriphClockCmd(I2C.SCL_GPIO_CLK|I2C.SDA_GPIO_CLK, ENABLE);	
	
	GPIO_InitStructure.GPIO_Pin = I2C.SCL_Pin;         
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_OUT;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_100MHz;
	GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_NOPULL;
	GPIO_InitStructure.GPIO_OType = GPIO_OType_OD;
	GPIO_Init(I2C.SCL_GPIO_Port, &GPIO_InitStructure);
	
	GPIO_InitStructure.GPIO_Pin = I2C.SDA_Pin;
	GPIO_Init(I2C.SDA_GPIO_Port, &GPIO_InitStructure);
}


//模拟I2C自带毫秒延时
void I2C_delay_ms(uint32_t time)
{
   uint64_t i=13500*time;  
   while(i) 
   { 
     i--; 
   }  
}


//模拟I2C自带延时，延时时间决定通信速率。可通过更改变量i来改变通信速率
void I2C_delay(void)
{
		
   u8 i=75; //这里可以优化速度	，经测试最低到2还能写入
   while(i) 
   { 
     i--; 
   }  
}

/**********************************************************/
//以下注释全为用GPIO引脚模拟I2C时序，结合I2C时序图即可看懂。
/**********************************************************/

void I2C_Ack(IIC_STRUCT I2C)
{	
	SCL_L(I2C);
	I2C_delay();
	SDA_L(I2C);
	I2C_delay();
	SCL_H(I2C);
	I2C_delay();
	SCL_L(I2C);
	I2C_delay();
}  

void I2C_NoAck(IIC_STRUCT I2C)
{	
	SCL_L(I2C);
	I2C_delay();
	SDA_H(I2C);
	I2C_delay();
	SCL_H(I2C);
	I2C_delay();
	SCL_L(I2C);
	I2C_delay();
} 

uint8_t I2C_Start(IIC_STRUCT I2C)
{
	SDA_H(I2C);
	SCL_H(I2C);
	I2C_delay();
	if(!SDA_read(I2C))return 0;	//SDA线为低电平则总线忙,退出
	SDA_L(I2C);
	I2C_delay();
	if(SDA_read(I2C)) return 0;	//SDA线为高电平则总线出错,退出
	SDA_L(I2C);
	I2C_delay();
	return 1;
}

void I2C_Stop(IIC_STRUCT I2C)
{
	SCL_L(I2C);
	I2C_delay();
	SDA_L(I2C);
	I2C_delay();
	SCL_H(I2C);
	I2C_delay();
	SDA_H(I2C);
	I2C_delay();
} 

uint8_t I2C_WaitAck(IIC_STRUCT I2C) 	 //返回为:=1有ACK,=0无ACK
{
	SCL_L(I2C);
	I2C_delay();
	SDA_H(I2C);			
	I2C_delay();
	SCL_H(I2C);
	I2C_delay();
	if(SDA_read(I2C))
	{
      SCL_L(I2C);
	  I2C_delay();
      return 0;
	}
	SCL_L(I2C);
	I2C_delay();
	return 1;

}

void I2C_WriteByte(IIC_STRUCT I2C,u8 WriteByte) //数据从高位到低位//
{
	u8 i=8;
	while(i--)
    {
    SCL_L(I2C);
    I2C_delay();
		if(WriteByte&0x80)
			SDA_H(I2C);  
		else 
			SDA_L(I2C);   
    WriteByte<<=1;
    I2C_delay();
		SCL_H(I2C);
    I2C_delay();
    }
	SCL_L(I2C);
}  

uint8_t I2C_ReadByte(IIC_STRUCT I2C)  //数据从高位到低位//
{ 
    u8 i=8;
    u8 ReceiveByte=0;

    SDA_H(I2C);				
    while(i--)
    {
      ReceiveByte<<=1;      
      SCL_L(I2C);
      I2C_delay();
	  SCL_H(I2C);
      I2C_delay();	
      if(SDA_read(I2C))
      {
        ReceiveByte|=0x01;
      }
    }
    SCL_L(I2C);
    return ReceiveByte;
} 

uint8_t I2C_Single_Write(IIC_STRUCT I2C,unsigned char SlaveAddress,unsigned char REG_Address,unsigned char REG_data)		     //void
{
  	if(!I2C_Start(I2C))return 0;
    I2C_WriteByte(I2C,SlaveAddress);   //发送设备地址+写信号//I2C_WriteByte(((REG_Address & 0x0700) >>7) | SlaveAddress & 0xFFFE);//设置高起始地址+器件地址 
    if(!I2C_WaitAck(I2C)){I2C_Stop(I2C); return 0;}
    I2C_WriteByte(I2C,REG_Address);   //设置低起始地址      
    I2C_WaitAck(I2C);	
    I2C_WriteByte(I2C,REG_data);
    I2C_WaitAck(I2C);   
    I2C_Stop(I2C); 
    I2C_delay_ms(1);
    return 1;
}

uint8_t I2C_Single_Read(IIC_STRUCT I2C,unsigned char SlaveAddress,unsigned char REG_Address)
{   unsigned char REG_data;     	
	if(!I2C_Start(I2C))return 0;
    I2C_WriteByte(I2C,SlaveAddress|I2C_WR); //I2C_WriteByte(((REG_Address & 0x0700) >>7) | REG_Address & 0xFFFE);//设置高起始地址+器件地址 
    if(!I2C_WaitAck(I2C)){I2C_Stop(I2C); return 0;}
    I2C_WriteByte(I2C,(u8) REG_Address);   //设置低起始地址      
		
    if(!I2C_WaitAck(I2C))
		{
			I2C_Stop(I2C);
			return 0;
		}
		
    I2C_Start(I2C);
    I2C_WriteByte(I2C,SlaveAddress|I2C_RD);
		
    if(!I2C_WaitAck(I2C))
		{
			I2C_Stop(I2C);
			return 0;
		}

	REG_data= I2C_ReadByte(I2C);
    I2C_NoAck(I2C);
    I2C_Stop(I2C);
	return REG_data;
}		



uint8_t I2C_CheckDevice(IIC_STRUCT I2C,uint8_t address)//1成功 0失败
{
	uint8_t ack;
	I2C_Start(I2C);
	I2C_WriteByte(I2C,address|I2C_WR);
	ack=I2C_WaitAck(I2C);
	I2C_Stop(I2C);
	return ack;
}

/*
批量写入
成功返回1，失败返回0

*/

uint8_t I2C_WriteBuffer(IIC_STRUCT I2C,uint8_t addr, uint8_t * data,uint8_t len)
{
	uint8_t i;
	I2C_Start(I2C);
	I2C_WriteByte(I2C,(addr)|I2C_WR);
	if(!I2C_WaitAck(I2C))
	{
		I2C_Stop(I2C);
		return 0;
	}
  for (i = 0; i < len; i++)
	{
			I2C_WriteByte(I2C,data[i]);
			if(!I2C_WaitAck(I2C))
			{
				I2C_Stop(I2C);
				return 0;
			}
	}
	I2C_Stop(I2C);
    return 1;
}


uint8_t I2C_ReadBuffer(IIC_STRUCT I2C,uint8_t addr, uint8_t* pBuffer, uint8_t readAddr, u16 NumByteToRead)
{
	
	if(!I2C_Start(I2C))return 0;
	
	I2C_WriteByte(I2C,(addr)| I2C_WR);
	if (!I2C_WaitAck(I2C))
			{
				I2C_Stop(I2C);
				return 0;	
			}
			
	I2C_WriteByte(I2C,readAddr);
			
	if (!I2C_WaitAck(I2C))
	{
		I2C_Stop(I2C);
		return 0;	
	}
	
	I2C_Start(I2C);
	
	I2C_WriteByte(I2C,addr| I2C_RD);
	
		if (!I2C_WaitAck(I2C))
	{
		I2C_Stop(I2C);
		return 0;	
	}
	
	 while(NumByteToRead)
  {

		*pBuffer = I2C_ReadByte(I2C);
		pBuffer++;
		if(NumByteToRead > 1)
			I2C_Ack(I2C);
		else
    {
			I2C_NoAck(I2C);
			I2C_Stop(I2C);
    }
		NumByteToRead--;
  }
		I2C_Stop(I2C);
	return 1;
	
}


