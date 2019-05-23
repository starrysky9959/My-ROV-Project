#ifndef __DATAPOCKET_H
#define __DATAPOCKET_H

#include "stm32f4xx.h"

/*************************************************宏定义*********************************************/
//发送数据包
#define TX_JY901_BUFF_LEN 				36			//向上位机发送JY901姿态传感器数据包
#define TX_MS5837_BUFF_LEN 				16			//向上位机发送MS5837深度传感器数据包
#define TX_SERVO_BUFF_LEN 				38			//向上位机发送舵机数据包
#define TX_PID_BUFF_LEN       		64			//向上位机发送PID系数数据包

#define TX_StartBit_JY901					0xAA		//向上位机传输JY901姿态传感器数据
#define	TX_StartBit_MS5837				0xAB		//向上位机传输MS5837深度传感器数据
#define	TX_StartBit_SERVO				  0xAC		//向上位机传输舵机数据
#define	TX_StartBit_PID						0xAD		//向上位机发送PID数据


//接收数据包
#define RX_RGB_BUFF_LEN										//接收上位机的RGB灯指令数据包
#define RX_MODE_BUFF_LEN					20			//接收上位机的操作模式变更指令数据包
#define RX_SERVO_BUFF_LEN 				38			//接收上位机的舵机指令数据包
#define RX_PID_BUFF_LEN						64			//接收上位机的PID指令数据包

#define	RX_StartBit_RGB       		0xAA    //接收上位机的RGB灯指令
#define	RX_StartBit_MODE      		0xAB    //接收上位机的操作模式变更指令
#define	RX_StartBit_SERVO         0xAC		//接收上位机的舵机指令
#define	RX_StartBit_PID           0xAD    //接收上位机的PID指令


/********************************************下位机数据上传结构体*******************************************/
// JY901 参数数据共用体
typedef union 
{
	struct
		{
			float acc_x;
			float acc_y;
			float acc_z;
			float gyro_x;
			float gyro_y;
			float gyro_z;
			float angle_x;
			float angle_y;
			float angle_z;
		}motiondata;
	uint8_t TX_JY901_BUFF[TX_JY901_BUFF_LEN];
}TX_JY901_Buff_Union;

//MS5837 深度传感器共用体
typedef union 
{
	struct
	{
		float depth;
		float temp;
		float pressure;
		float offset;
	}ms5837data;
	uint8_t TX_MS5837_BUFF[TX_MS5837_BUFF_LEN];
}TX_MS5837_Buff_Union;

//PID 系数共用体
typedef union
{
	struct
	{
		float Depth_Kp;
		float Depth_Ki;
		float Depth_Kd;
		float Depth_Target;
		
		float Pitch_Kp;
		float Pitch_Ki;
		float Pitch_Kd;
		float Pitch_Target;
		
		float AngleSpeedY_Kp;
		float AngleSpeedY_Ki;
		float AngleSpeedY_Kd;
		float AngleSpeedY_Target;
		
		float AccelerationY_Kp;
		float AccelerationY_Ki;
		float AccelerationY_Kd;
		float AccelerationY_Target;		
	}PID_Parameter;
	uint8_t TX_PID_BUFF[TX_PID_BUFF_LEN];
}TX_PID_Buff_Union;


//舵机参数数据共用体
typedef union 
{
	struct
	{
		uint16_t FinTail_Advance_StartingPosition;  //尾部推进舵机 起始位置
		uint16_t FinTail_Advance_EndingPosition;    //尾部推进舵机 终止位置
		uint16_t FinTail_Advance_EachCCR;           //尾部推进舵机 每次改变的占空比
		uint16_t FinTail_Advance_DelayTime;         //尾部推进舵机 延时长度

		uint16_t FinLeft_Attitude_Position;   			//左侧鱼鳍姿态舵机 终止位置

		uint16_t FinLeft_Thrash_StartingPosition;   //左侧鱼鳍划水舵机 起始位置
		uint16_t FinLeft_Thrash_EndingPosition;     //左侧鱼鳍划水舵机 终止位置
		uint16_t FinLeft_Thrash_Down_EachCCR;       //左侧鱼鳍划水舵机 向下拍水时 每次改变的占空比
		uint16_t FinLeft_Thrash_Down_DelayTime;     //左侧鱼鳍划水舵机 向下拍水时 延时长度
		uint16_t FinLeft_Thrash_Up_EachCCR;         //左侧鱼鳍划水舵机 向上拍水时 每次改变的占空比
		uint16_t FinLeft_Thrash_Up_DelayTime;       //左侧鱼鳍划水舵机 向上拍水时 延时长度        

		uint16_t FinRight_Attitude_Position;  			//右侧鱼鳍姿态舵机 终止位置

		uint16_t FinRight_Thrash_StartingPosition;  //右侧鱼鳍划水舵机 起始位置
		uint16_t FinRight_Thrash_EndingPosition;    //右侧鱼鳍划水舵机 终止位置
		uint16_t FinRight_Thrash_Down_EachCCR;      //右侧鱼鳍划水舵机 向下拍水时 每次改变的占空比
		uint16_t FinRight_Thrash_Down_DelayTime;    //右侧鱼鳍划水舵机 向下拍水时 延时长度
		uint16_t FinRight_Thrash_Up_EachCCR;        //右侧鱼鳍划水舵机 向上拍水时 每次改变的占空比
		uint16_t FinRight_Thrash_Up_DelayTime;      //右侧鱼鳍划水舵机 向上拍水时 延时长度    

		uint16_t Camera_Position;                   //摄像机云台舵机 位置  
	}servodata;
	uint8_t TX_SERVO_BUFF[TX_SERVO_BUFF_LEN];
}TX_SEVRO_Buff_Union;



/********************************************上位机指令发送结构体*******************************************/
//控制模式共用体
typedef union
{
	struct
	{
		int Control_mode;
		int DepthMode;
		int PitchMode;           
    int AngleSpeedYMode;
    int AccelerationYMode;
	}mode;
	uint8_t RX_MODE_BUFF[RX_MODE_BUFF_LEN];
}RX_MODE_Buff_Union;

//PID 系数共用体
typedef union
{
	struct
	{
		float Depth_Kp;
		float Depth_Ki;
		float Depth_Kd;
		float Depth_Target;
		
		float Pitch_Kp;
		float Pitch_Ki;
		float Pitch_Kd;
		float Pitch_Target;
		
		float AngleSpeedY_Kp;
		float AngleSpeedY_Ki;
		float AngleSpeedY_Kd;
		float AngleSpeedY_Target;
		
		float AccelerationY_Kp;
		float AccelerationY_Ki;
		float AccelerationY_Kd;
		float AccelerationY_Target;		
	}PID_Parameter;
	uint8_t RX_PID_BUFF[RX_PID_BUFF_LEN];
}RX_PID_Buff_Union;

//舵机参数数据共用体
typedef union 
{
	struct
	{
    uint16_t FinTail_Advance_StartingPosition;  //尾部推进舵机 起始位置
    uint16_t FinTail_Advance_EndingPosition;    //尾部推进舵机 终止位置
    uint16_t FinTail_Advance_EachCCR;           //尾部推进舵机 每次改变的占空比
    uint16_t FinTail_Advance_DelayTime;         //尾部推进舵机 延时长度

	  uint16_t FinLeft_Attitude_Position;   			//左侧鱼鳍姿态舵机 终止位置

		uint16_t FinLeft_Thrash_StartingPosition;   //左侧鱼鳍划水舵机 起始位置
    uint16_t FinLeft_Thrash_EndingPosition;     //左侧鱼鳍划水舵机 终止位置
    uint16_t FinLeft_Thrash_Down_EachCCR;       //左侧鱼鳍划水舵机 向下拍水时 每次改变的占空比
    uint16_t FinLeft_Thrash_Down_DelayTime;     //左侧鱼鳍划水舵机 向下拍水时 延时长度
    uint16_t FinLeft_Thrash_Up_EachCCR;         //左侧鱼鳍划水舵机 向上拍水时 每次改变的占空比
    uint16_t FinLeft_Thrash_Up_DelayTime;       //左侧鱼鳍划水舵机 向上拍水时 延时长度        

    uint16_t FinRight_Attitude_Position;  			//右侧鱼鳍姿态舵机 终止位置

    uint16_t FinRight_Thrash_StartingPosition;  //右侧鱼鳍划水舵机 起始位置
    uint16_t FinRight_Thrash_EndingPosition;    //右侧鱼鳍划水舵机 终止位置
    uint16_t FinRight_Thrash_Down_EachCCR;      //右侧鱼鳍划水舵机 向下拍水时 每次改变的占空比
    uint16_t FinRight_Thrash_Down_DelayTime;    //右侧鱼鳍划水舵机 向下拍水时 延时长度
    uint16_t FinRight_Thrash_Up_EachCCR;        //右侧鱼鳍划水舵机 向上拍水时 每次改变的占空比
    uint16_t FinRight_Thrash_Up_DelayTime;      //右侧鱼鳍划水舵机 向上拍水时 延时长度    

    uint16_t Camera_Position;                   //摄像机云台舵机 位置   
	}servodata;
	uint8_t RX_SERVO_BUFF[RX_SERVO_BUFF_LEN];
}RX_SEVRO_Buff_Union;



/**********************************************函数声明***********************************************/
extern void PackDataUp(uint8_t startbit);
extern void Command_ReceiveAndCheck(uint8_t Data);
extern void RX_MODE_DataHandler(RX_MODE_Buff_Union Data);
extern void RX_SERVO_DataHandler(RX_SEVRO_Buff_Union Data);
extern void RX_PID_DataHandler(RX_PID_Buff_Union Data);
#endif

