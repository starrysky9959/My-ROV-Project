#include "JY901.h"
#include "string.h"
#include "usart2.h"

struct SAcc 		   stcAcc;
struct SGyro 			 stcGyro;
struct SAngle 		 stcAngle;




void ShortToChar(short sData,unsigned char cData[])
{
	cData[0]=sData&0xff;
	cData[1]=sData>>8;
}


short CharToShort(unsigned char cData[])
{
	return ((short)cData[1]<<8)|cData[0];
}


/**
 *@brief	串口2中断调用函数，串口每收到一个数据，调用一次这个函数。
 *@param	ucData：接收到的数据
 *@retval
 *@addition
*/
void JY901_DataReceive(uint8_t ucData)
{
  static unsigned char ucRxBuffer[250];
	static unsigned char ucRxCnt = 0;	
	
	ucRxBuffer[ucRxCnt++]=ucData;	//将收到的数据存入缓冲区中
	if (ucRxBuffer[0]!=0x55) //数据头不对，则重新开始寻找0x55数据头
	{
		ucRxCnt=0;
		return;
	}
	if (ucRxCnt<11) {return;}//数据不满11个，则返回
	else
	{
		//判断数据是哪种数据，然后将其拷贝到对应的结构体中，有些数据包需要通过上位机打开对应的输出后，才能接收到这个数据包的数据
		switch(ucRxBuffer[1])
		{
			//memcpy为编译器自带的内存拷贝函数，需引用"string.h"，将接收缓冲区的字符拷贝到数据结构体里面，从而实现数据的解析
			case 0x51:	memcpy(&stcAcc,&ucRxBuffer[2],8);break;
			case 0x52:	memcpy(&stcGyro,&ucRxBuffer[2],8);break;
			case 0x53:	memcpy(&stcAngle,&ucRxBuffer[2],8);break;
		}
		ucRxCnt=0;//清空缓存区
	}
	
	//数据换算
	JY901_Val.acc_x = (float)stcAcc.a[0]/32768*16;
	JY901_Val.acc_y = (float)stcAcc.a[1]/32768*16;
	JY901_Val.acc_z = (float)stcAcc.a[2]/32768*16;
	JY901_Val.gyro_x = (float)stcGyro.w[0]/32768*2000;
	JY901_Val.gyro_y = (float)stcGyro.w[1]/32768*2000;
	JY901_Val.gyro_z = (float)stcGyro.w[2]/32768*2000;
	JY901_Val.angle_x = (float)stcAngle.Angle[0]/32768*180;
	JY901_Val.angle_y = (float)stcAngle.Angle[1]/32768*180;
	JY901_Val.angle_z = (float)stcAngle.Angle[2]/32768*180;
}


