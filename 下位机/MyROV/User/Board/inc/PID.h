#ifndef __PID_H
#define __PID_H

#include "stm32f4xx.h"

/********************************************* PID 结构体********************************************/
struct PID
{
	float P;						//比例调节输出
	float I;						//积分调节输出
	float D;						//微分调节输出
	float Kp;						//比例系数
	float Ki;						//积分系数
	float Kd;						//微分系数
	float CurrentError; //本次偏差值
	float LastError;		//上次偏差值
	float dError;				//微分偏差
	float CurrentValue; //当前值
	float SetValue;			//设定值
	float MaxOut;				//被控对象的最大输出
	float IMax;					//积分最大值
	float Out;					//被控对象的输出
	float FuzzyInterval;//模糊区间
};
/************************************************函数声明*********************************************/

extern void PID_Init(struct PID *pidData, float Kp, float Ki, float Kd, float MaxOut, float IMax, float FuzzInterval);
extern float Limitation(float Ans, float max, float min);
extern void Calculate(struct PID *pidData);
extern void ResetPID(struct PID *pidData);
extern void ResetI(struct PID *pidData);
extern void DebugPID(struct PID *pidData, char *pFlag);

#endif
