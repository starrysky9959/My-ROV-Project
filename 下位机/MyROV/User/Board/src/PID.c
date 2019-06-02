#include "PID.h"
#include "string.h"
#include "math.h"

/**************************************************************
 * @brief	PID结构体参数初始化
 * @param	*pidData：对应 PID 结构体传址调用
	 @param  Kp：比例系数
	 @param  Ki：积分系数
	 @param  Kd：微分系数
	 @param  MaxOut：被控对象输出上限
	 @param  IMax：积分调节输出上限
	 @param  FuzzInterval：模糊区间
 * @retval
 * @addition 除给定值其他变量均置零
**************************************************************/
void PID_Init(struct PID *pidData, float Kp, float Ki, float Kd, float MaxOut, float IMax, float FuzzInterval)
{				
	pidData->Kp = Kp;						
	pidData->Ki = Ki;						
	pidData->Kd = Kd;						
	pidData->MaxOut = MaxOut;				
	pidData->IMax = IMax;						
	pidData->FuzzyInterval = FuzzInterval;
	pidData->P = 0;						
	pidData->I = 0;						
	pidData->D = 0;		
	pidData->CurrentError = 0; 
	pidData->LastError = 0;		
	pidData->dError = 0;	
	pidData->Out = 0;	
}


/**************************************************************
 * @brief	对数据进行限定
 * @param	Ans：待处理的数据
	 @param	max：数据范围上限 
	 @param	min：数据范围下限
 * @retval
 * @addition Ans 进行限定后的数据
**************************************************************/
float Limitation(float Ans, float max, float min)
{
	if (Ans>max) Ans = max;
	else if (Ans<min) Ans = min;
	return Ans;
}


/**************************************************************
 * @brief	PID输出计算
 * @param	*pidData：对应 PID 结构体传址调用
 * @retval
 * @addition
**************************************************************/
void Calculate(struct PID *pidData)
{
	//计算当前偏差
	pidData->CurrentError = pidData->SetValue - pidData->CurrentValue;
	//模糊计算
	if (fabs(pidData->CurrentError) <= pidData->FuzzyInterval)
			// 当前偏差值不超过模糊区间，视为0处理，否则向模糊区间靠拢
			 pidData->CurrentError = 0;
	else if (pidData->CurrentError > 0) 
			 pidData->CurrentError -= pidData->FuzzyInterval;
	else pidData->CurrentError += pidData->FuzzyInterval;
	
	pidData->dError = pidData->CurrentError - pidData->LastError;		//计算微分偏差
	pidData->P = pidData->Kp * pidData->CurrentError;								//计算比例调节输出
	//在限定范围内累加积分作用
	pidData->I += Limitation((pidData->Ki) * (pidData->CurrentError), pidData->IMax/10, -pidData->IMax/10);
	pidData->I = Limitation(pidData->I, pidData->IMax, -pidData->IMax);
	if (pidData->Ki==0)		//如果积分系数为零，清零积分调节作用累加器,防止不用积分调节时之前的数据仍有影响
		pidData->I = 0;
	pidData->D = (pidData->Kd) * (pidData->dError);									//计算微分作用
	pidData->LastError = pidData->CurrentError;											//更新偏差值
}


/**************************************************************
 * @brief	PID复位
 * @param	*pidData：对应 PID 结构体传址调用
 * @retval
 * @addition
**************************************************************/
void ResetPID(struct PID *pidData)
{
	pidData->P = 0;						
	pidData->I = 0;						
	pidData->D = 0;		
	pidData->CurrentError = 0; 
	pidData->LastError = 0;		
	pidData->dError = 0;	
}


/**************************************************************
 * @brief	积分作用归零
 * @param	*pidData：对应 PID 结构体传址调用
 * @retval
 * @addition
**************************************************************/
void ResetI(struct PID *pidData)
{			
	pidData->I = 0;						
}


/**************************************************************
 * @brief	指定使用比例、积分、微分中的几个进行调节
 * @param	*pidData：对应 PID 结构体传址调用
	 @param	*pFlag：对应不同调节类型的标志字符
 * @retval
 * @addition
**************************************************************/
void DebugPID(struct PID *pidData, char *pFlag)
{			
	//根据标志字符选择调节类型
	if (strcmp(pFlag,"P")==0)
		pidData->Out = pidData->P;
	if (strcmp(pFlag,"PI")==0)
		pidData->Out = pidData->P + pidData->I;
	if (strcmp(pFlag,"PD")==0)
		pidData->Out = pidData->P + pidData->D;
	if (strcmp(pFlag,"PID")==0)
		pidData->Out = pidData->P + pidData->I + pidData->D;

	pidData->Out = Limitation(pidData->Out, pidData->MaxOut, -pidData->MaxOut);
}
