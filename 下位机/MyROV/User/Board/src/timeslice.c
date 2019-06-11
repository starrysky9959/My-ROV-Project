/******************************************************************************
  * @file    timeslice.c
  * @author  陆展
  * @version V1.0
  * @date    2019-5-1
  * @brief   时间片轮询
	* @attention 在死循环中调用ROV_Running();
*******************************************************************************/

#include "timeslice.h"
#include "control.h"
#include "MS5837.h"
#include "servo.h"
#include "PID.h"
#include "datapocket.h"
#include "usart1.h"


/*****************************************************
 * @brief  时间片轮询函数
 * @param  
 * @retval 
 * @addition	每20ms PID闭环控制输出
							每50ms 
							每100ms 读取MS5837数据，上传一次MS5837、JY901数据
							每200ms 上传一次舵机参数
							每5000ms 上传PID系数
******************************************************/
void SpecialAction(void)
{
//	static int i=1,j=1;
	
	if (TimeSlice.Count_20ms>=20)
	{
		TimeSlice.Count_20ms = 0;
		Loop_20ms();
	}
	
	if (TimeSlice.Count_50ms>=50)
	{
		TimeSlice.Count_50ms = 0;
		Loop_50ms();
	}
		
	if (TimeSlice.Count_100ms>=100)
	{
		TimeSlice.Count_100ms = 0;
		Loop_100ms();
	}
		
	if (TimeSlice.Count_200ms>=200)
	{
		TimeSlice.Count_200ms = 0;
		Loop_200ms();
	}
		
	if (TimeSlice.Count_5000ms>=5000)
	{
		TimeSlice.Count_5000ms = 0;
		Loop_5000ms();
	}
	
//	//左侧划水舵机
//	if ((i <= Step_Val.Len_Left_Down)&&
//		  (TimeSlice.Count_Left >= Servo_Val.FinLeft_Thrash_Down_DelayTime))
//	{
//		TimeSlice.Count_Left = 0;
//		TIM_SetCompare2(TIM1, Step_Val.Left[i]);
//		i++;
//	}
//	else if ((i > Step_Val.Len_Left_Down)&&
//		       (TimeSlice.Count_Left >= Servo_Val.FinLeft_Thrash_Up_DelayTime))
//	{
//		TimeSlice.Count_Left = 0;
//		TIM_SetCompare2(TIM1, Step_Val.Left[i]);
//		i++;
//		if (i > Step_Val.Len_Left) i = 1;
//	}
//	//右侧划水舵机
//	if ((j <= Step_Val.Len_Right_Down)&&
//		  (TimeSlice.Count_Right >= Servo_Val.FinRight_Thrash_Down_DelayTime))
//	{
//		TimeSlice.Count_Right = 0;
//		TIM_SetCompare1(TIM1, Step_Val.Right[j]);
//		j++;
//	}
//	else if ((j > Step_Val.Len_Right_Down)&&
//		       (TimeSlice.Count_Right >= Servo_Val.FinRight_Thrash_Up_DelayTime))
//	{
//		TimeSlice.Count_Right = 0;
//		TIM_SetCompare1(TIM1, Step_Val.Right[j]);
//		j++;
//		if (j > Step_Val.Len_Right) j = 1;
//	}
}


/*****************************************************
 * @brief  每20ms PID闭环控制输出
 * @param  
 * @retval 
 * @addition
******************************************************/
void Loop_20ms(void)
{
	if (Mode_Val.Control_mode==1) ClosedLoop_Control();
}


/*****************************************************
 * @brief  每50ms 更新所有舵机的参数
 * @param  
 * @retval 
 * @addition
******************************************************/
void Loop_50ms(void)
{

}


/*****************************************************
 * @brief  每100ms 读取MS5837数据，上传一次MS5837、JY901数据
 * @param  
 * @retval 
 * @addition
******************************************************/
void Loop_100ms(void)
{
	MS5837_Read();
	PackDataUp(TX_StartBit_JY901);
	PackDataUp(TX_StartBit_MS5837);
}


/*****************************************************
 * @brief  每200ms 上传一次舵机参数
 * @param  
 * @retval 
 * @addition
******************************************************/
void Loop_200ms(void)
{
	PackDataUp(TX_StartBit_SERVO);
}


/*****************************************************
 * @brief  每5000ms 上传一次舵机参数
 * @param  
 * @retval 
 * @addition
******************************************************/
void Loop_5000ms(void)
{
	PackDataUp(TX_StartBit_PID);
}
