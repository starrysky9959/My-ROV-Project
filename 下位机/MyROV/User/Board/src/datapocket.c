#include "string.h"
#include "stdio.h"
#include "usart1.h"
#include "datapocket.h"
#include "JY901.h"
#include "servo.h"
#include "systick.h"
#include "control.h"
#include "MS5837.h"
#include "stepper.h"

/**************************************************************
 * @brief 根据起始码startbit，向上位机发送相应的ROV数据信息
 * @param startbit：起始位
 * @retval
 * @addition
**************************************************************/
void PackDataUp(uint8_t startbit)
{
	uint8_t i;
	uint8_t checkbit=(0x00)^startbit;	//校验位
	TX_JY901_Buff_Union 		TX_JY901_Data;
	TX_MS5837_Buff_Union 		TX_MS5837_Data;
	TX_SEVRO_Buff_Union 		TX_SERVO_Data;
	TX_PID_Buff_Union				TX_PID_Data;

	//根据起始码将数据打包发送
	switch(startbit)
	{
		//如果数据头对应 JY901
		case(TX_StartBit_JY901):
		{
			//将相关数据赋值给共用体内相应成员
			TX_JY901_Data.motiondata.acc_x	 = JY901_Val.acc_x;
			TX_JY901_Data.motiondata.acc_y	 = JY901_Val.acc_y;
			TX_JY901_Data.motiondata.acc_z	 = JY901_Val.acc_z;
			TX_JY901_Data.motiondata.angle_x = JY901_Val.angle_x;
			TX_JY901_Data.motiondata.angle_y = JY901_Val.angle_y;
			TX_JY901_Data.motiondata.angle_z = JY901_Val.angle_z;
			TX_JY901_Data.motiondata.gyro_x	 = JY901_Val.gyro_x;
			TX_JY901_Data.motiondata.gyro_y	 = JY901_Val.gyro_y;
			TX_JY901_Data.motiondata.gyro_z	 = JY901_Val.gyro_z;
			//数据打包发送
			USART1_PutChar(startbit);//发送数据头
			for(i=0;i<TX_JY901_BUFF_LEN;i++)
			{
				USART1_PutChar(TX_JY901_Data.TX_JY901_BUFF[i]);//依次将联合体中每一个字节发送
				checkbit ^=TX_JY901_Data.TX_JY901_BUFF[i];//同时将每个字节加到校验码上
			}		
			USART1_PutChar(checkbit);	//发送求异或之后的校验位
			break;
		}
		
		
		//如果数据头对应 MS5837
		case(TX_StartBit_MS5837):
		{
			//将相关数据赋值给共用体内相应成员
			TX_MS5837_Data.ms5837data.depth		 = MS5837_Val.depth;
			TX_MS5837_Data.ms5837data.temp		 = MS5837_Val.temp;
			TX_MS5837_Data.ms5837data.pressure = MS5837_Val.pressure;
			TX_MS5837_Data.ms5837data.offset	 = MS5837_Val.offset;
			
			//数据打包发送
			USART1_PutChar(startbit);//发送数据头
			for(i=0;i<TX_MS5837_BUFF_LEN;i++)
			{
				USART1_PutChar(TX_MS5837_Data.TX_MS5837_BUFF[i]);//依次将联合体中每一个字节发送
				checkbit ^=TX_MS5837_Data.TX_MS5837_BUFF[i];//同时将每个字节加到校验码上
			}		
			USART1_PutChar(checkbit);	//发送求异或之后的校验位
			break;
		}
		
		
		//如果数据头对应舵机
		case(TX_StartBit_SERVO):
		{
			//将相关数据赋值给共用体内相应成员
			TX_SERVO_Data.servodata.FinTail_Front_StartingPosition = Servo_Val.FinTail_Front_StartingPosition;  //尾部舵机（前） 起始位置
			TX_SERVO_Data.servodata.FinTail_Front_EndingPosition	 = Servo_Val.FinTail_Front_EndingPosition;    //尾部舵机（前） 终止位置
			TX_SERVO_Data.servodata.FinTail_Front_EachCCR					 = Servo_Val.FinTail_Front_EachCCR;           //尾部舵机（前） 每次改变的占空比
			TX_SERVO_Data.servodata.FinTail_Front_DelayTime				 = Servo_Val.FinTail_Front_DelayTime;         //尾部舵机（前） 延时长度
			
			TX_SERVO_Data.servodata.FinTail_Rear_StartingPosition = Servo_Val.FinTail_Rear_StartingPosition;  //尾部舵机（后） 起始位置
			TX_SERVO_Data.servodata.FinTail_Rear_EndingPosition	  = Servo_Val.FinTail_Rear_EndingPosition;    //尾部舵机（后） 终止位置
			TX_SERVO_Data.servodata.FinTail_Rear_EachCCR					= Servo_Val.FinTail_Rear_EachCCR;           //尾部舵机（后） 每次改变的占空比
			TX_SERVO_Data.servodata.FinTail_Rear_DelayTime				= Servo_Val.FinTail_Rear_DelayTime;         //尾部舵机（后） 延时长度

			TX_SERVO_Data.servodata.Camera_Position =	Servo_Val.Camera_Position;      //摄像机云台舵机 位置 
			TX_SERVO_Data.servodata.Pulse_Num = Servo_Val.Pulse_Num;									//步进电机 位置
			
			//数据打包发送
			USART1_PutChar(startbit);//发送数据头
			for(i=0;i<TX_SERVO_BUFF_LEN;i++)
			{
				USART1_PutChar(TX_SERVO_Data.TX_SERVO_BUFF[i]);//依次将联合体中每一个字节发送
				checkbit ^=TX_SERVO_Data.TX_SERVO_BUFF[i];//同时将每个字节加到校验码上
			}		
			USART1_PutChar(checkbit);	//发送求异或之后的校验位
			break;
		}
		
		//如果数据头对应PID
		case(TX_StartBit_PID):
		{
			//将相关数据赋值给共用体内相应成员
			TX_PID_Data.PID_Parameter.Depth_Kp		 =PID_Depth.Kp;
			TX_PID_Data.PID_Parameter.Depth_Ki		 =PID_Depth.Ki;
			TX_PID_Data.PID_Parameter.Depth_Kd		 =PID_Depth.Kd;
			TX_PID_Data.PID_Parameter.Depth_Target =PID_Depth.SetValue;
			
						
			TX_PID_Data.PID_Parameter.Pitch_Kp		 =PID_Pitch.Kp;
			TX_PID_Data.PID_Parameter.Pitch_Ki		 =PID_Pitch.Ki;
			TX_PID_Data.PID_Parameter.Pitch_Kd		 =PID_Pitch.Kd;
			TX_PID_Data.PID_Parameter.Pitch_Target =PID_Pitch.SetValue;
			
			TX_PID_Data.PID_Parameter.AngleSpeedY_Kp		   =PID_AngleSpeedY.Kp;
			TX_PID_Data.PID_Parameter.AngleSpeedY_Ki		 	 =PID_AngleSpeedY.Ki;
			TX_PID_Data.PID_Parameter.AngleSpeedY_Kd		 	 =PID_AngleSpeedY.Kd;
			TX_PID_Data.PID_Parameter.AngleSpeedY_Target 	 =PID_AngleSpeedY.SetValue;		
			
			TX_PID_Data.PID_Parameter.AccelerationY_Kp		   =PID_AccelerationY.Kp;
			TX_PID_Data.PID_Parameter.AccelerationY_Ki		 	 =PID_AccelerationY.Ki;
			TX_PID_Data.PID_Parameter.AccelerationY_Kd		 	 =PID_AccelerationY.Kd;
			TX_PID_Data.PID_Parameter.AccelerationY_Target 	 =PID_AccelerationY.SetValue;			
			
			//数据打包发送
			USART1_PutChar(startbit);//发送数据头
			for(i=0;i<TX_PID_BUFF_LEN;i++)
			{
				USART1_PutChar(TX_PID_Data.TX_PID_BUFF[i]);//依次将联合体中每一个字节发送
				checkbit ^=TX_PID_Data.TX_PID_BUFF[i];//同时将每个字节加到校验码上
			}		
			USART1_PutChar(checkbit);	//发送求异或之后的校验位
			break;
		}

	}
}

/**************************************************************
 * @brief	对数据包进行接收校验
 * @param	data：当前接收的一字节数据
 * @retval
 * @addition	校验通过后，调用对应的函数处理已接收到的数据
**************************************************************/
void Command_ReceiveAndCheck(uint8_t data)
{

	static RX_SEVRO_Buff_Union RX_SEVRO_Data;
	static RX_PID_Buff_Union 	 RX_PID_Data;
	static RX_MODE_Buff_Union  RX_MODE_Data;
	
	static uint8_t RX_Cnt = 0;	//接收计数
	static uint8_t startbit;		//起始位
	uint8_t i,checkbit;
	
	RX_Cnt++;	//接收计数器自增一，表示当前数据包已接收到的字节数
	if (RX_Cnt == 1)	//表示该字节为数据包起始位
	{
		startbit = data;
		if (startbit != RX_StartBit_MODE &&
				startbit != RX_StartBit_SERVO &&
				startbit != RX_StartBit_PID)			//起始位不符合要求，舍弃当前已接收到的数据
		{
			RX_Cnt = 0;		//计数器归零，重新开始计数
		}
		return;
	}
	
	switch (startbit)	//按类型将数据存储到对应的共用体中
	{				
		case(RX_StartBit_MODE):
		{			
			if (RX_Cnt <= RX_MODE_BUFF_LEN + 1)
			{
				RX_MODE_Data.RX_MODE_BUFF[RX_Cnt-2] = data;
				return;
			}
			break;
		}
		
		case(RX_StartBit_SERVO):
		{
			if (RX_Cnt <= RX_SERVO_BUFF_LEN + 1)
			{
				RX_SEVRO_Data.RX_SERVO_BUFF[RX_Cnt-2]=data;
				return;
			}
			break;
		}
		
		case(RX_StartBit_PID):
		{
			if (RX_Cnt <= RX_PID_BUFF_LEN + 1)
			{
				RX_PID_Data.RX_PID_BUFF[RX_Cnt-2]=data;
				return;
			}
			break;
		}
	}
	
	//到此，数据包接收完毕，对数据进行校验
	checkbit=0x00^startbit;
	switch (startbit)
	{		
		case(RX_StartBit_MODE):
		{
			for (i = 0;i < RX_MODE_BUFF_LEN; i++)
			checkbit ^= RX_MODE_Data.RX_MODE_BUFF[i];
			if (checkbit != data)		//校验位不匹配则舍弃数据，重新开始；匹配则更新数据
			{
				RX_Cnt = 0;
				return;
			}
			else
			{
				RX_MODE_DataHandler(RX_MODE_Data);
			}
			break;
		}
		
		case(RX_StartBit_SERVO):
		{
			for (i = 0; i < RX_SERVO_BUFF_LEN; i++)
			checkbit ^= RX_SEVRO_Data.RX_SERVO_BUFF[i];
			if (checkbit != data)		//校验位不匹配则舍弃数据，重新开始；匹配则更新数据
			{
				RX_Cnt = 0;
				return;
			}
			else
			{
				RX_SERVO_DataHandler(RX_SEVRO_Data);
			}
			break;
		}
		
		case(RX_StartBit_PID):
		{
			for (i = 0; i < RX_PID_BUFF_LEN; i++)
			checkbit ^= RX_PID_Data.RX_PID_BUFF[i];
			if (checkbit != data)		//校验位不匹配则舍弃数据，重新开始；匹配则更新数据
			{
				RX_Cnt = 0;
				return;
			}
			else
			{
				RX_PID_DataHandler(RX_PID_Data);
			}
			break;
		}
	}
}


/**************************************************************
 * @brief	修改控制模式
 * @param	Data：控制模式数据体
 * @retval
 * @addition
**************************************************************/
void RX_MODE_DataHandler(RX_MODE_Buff_Union Data)
{
	Mode_Val.Control_mode 		 = Data.mode.Control_mode;
	Mode_Val.DepthMode 				 = Data.mode.DepthMode;
	Mode_Val.PitchMode 				 = Data.mode.PitchMode;
	Mode_Val.AngleSpeedYMode 	 = Data.mode.AngleSpeedYMode;
	Mode_Val.AccelerationYMode = Data.mode.AccelerationYMode;
}


/**************************************************************
 * @brief	更新舵机数据
 * @param	Data：舵机数据体
 * @retval
 * @addition
**************************************************************/
void RX_SERVO_DataHandler(RX_SEVRO_Buff_Union Data)
{
  Servo_Val.FinTail_Front_StartingPosition = Data.servodata.FinTail_Front_StartingPosition;  //尾部舵机（前） 起始位置
  Servo_Val.FinTail_Front_EndingPosition   = Data.servodata.FinTail_Front_EndingPosition;    //尾部舵机（前） 终止位置
  Servo_Val.FinTail_Front_EachCCR          = Data.servodata.FinTail_Front_EachCCR;           //尾部舵机（前） 每次改变的占空比
  Servo_Val.FinTail_Front_DelayTime        = Data.servodata.FinTail_Front_DelayTime;         //尾部舵机（前） 延时长度

	Servo_Val.FinTail_Rear_StartingPosition = Data.servodata.FinTail_Rear_StartingPosition;  //尾部舵机（后） 起始位置
  Servo_Val.FinTail_Rear_EndingPosition   = Data.servodata.FinTail_Rear_EndingPosition;    //尾部舵机（后） 终止位置
  Servo_Val.FinTail_Rear_EachCCR          = Data.servodata.FinTail_Rear_EachCCR;           //尾部舵机（后） 每次改变的占空比
  Servo_Val.FinTail_Rear_DelayTime        = Data.servodata.FinTail_Rear_DelayTime;         //尾部舵机（后）	延时长度
	
  Servo_Val.Camera_Position = Data.servodata.Camera_Position;      //摄像机云台舵机 位置
	Servo_Val.Pulse_Num = Data.servodata.Pulse_Num;									 //步进电机 位置
	
	Servo_PositionSet();	//更新舵机位置
	//AbsPosition(Servo_Val.Pulse_Num);
}


/**************************************************************
 *@brief	更新PID数据
 *@param	Data：PID数据体
 *@retval
 *@addition
**************************************************************/
void RX_PID_DataHandler(RX_PID_Buff_Union Data)
{
	PID_Depth.Kp 			 = Data.PID_Parameter.Depth_Kp;
	PID_Depth.Ki			 = Data.PID_Parameter.Depth_Ki;
	PID_Depth.Kd			 = Data.PID_Parameter.Depth_Kd;
	PID_Depth.SetValue = Data.PID_Parameter.Depth_Target;
			
	PID_Pitch.Kp			 = Data.PID_Parameter.Pitch_Kp;
	PID_Pitch.Ki			 = Data.PID_Parameter.Pitch_Ki;
	PID_Pitch.Kd			 = Data.PID_Parameter.Pitch_Kd;
	PID_Pitch.SetValue = Data.PID_Parameter.Pitch_Target;
			
	PID_AngleSpeedY.Kp				 = Data.PID_Parameter.AngleSpeedY_Kp;
	PID_AngleSpeedY.Ki				 = Data.PID_Parameter.AngleSpeedY_Ki;
	PID_AngleSpeedY.Kd				 = Data.PID_Parameter.AngleSpeedY_Kd;
	PID_AngleSpeedY.SetValue	 = Data.PID_Parameter.AngleSpeedY_Target;		
			
	PID_AccelerationY.Kp			 = Data.PID_Parameter.AccelerationY_Kp;
	PID_AccelerationY.Ki			 = Data.PID_Parameter.AccelerationY_Ki;
	PID_AccelerationY.Kd			 = Data.PID_Parameter.AccelerationY_Kd;
	PID_AccelerationY.SetValue = Data.PID_Parameter.AccelerationY_Target;	
}
