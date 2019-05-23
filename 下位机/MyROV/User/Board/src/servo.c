/******************************************************************************
  * @file    servo.c
  * @author  陆展
  * @version V1.0
  * @date    2019-4-24
  * @brief   定时器相关代码
	* @attention 调用TIM1_Init();TIM8_Init();完成初始化
*******************************************************************************/

#include "servo.h"
#include "systick.h"

/**************************************************************
 * @brief	TIM1 定时器 GPIO与工作模式配置
 * @param	
 * @retval
 * @addition	
**************************************************************/
void TIM1_Init(void)
{
	TIM_TimeBaseInitTypeDef  TIM_TimeBaseStructure;
  TIM_OCInitTypeDef  TIM_OCInitStructure;
	GPIO_InitTypeDef GPIO_InitStructure;

	//开启相关的 GPIO、TIM1 时钟
	TIM1_RCC_ENABLE;

	//定时器通道引脚配置 														   
	GPIO_InitStructure.GPIO_Pin = FinLeft_Attitude_GPIO_PIN;	
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AF;    
	GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
	GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_NOPULL;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_100MHz; 
	GPIO_Init(FinLeft_Attitude_GPIO_PORT, &GPIO_InitStructure);
	
	//更改引脚，配置其他通道
	GPIO_InitStructure.GPIO_Pin = FinLeft_Thrash_GPIO_PIN;	
	GPIO_Init(FinLeft_Thrash_GPIO_PORT, &GPIO_InitStructure);	
	
	GPIO_InitStructure.GPIO_Pin = FinRight_Attitude_GPIO_PIN;	
	GPIO_Init(FinRight_Attitude_GPIO_PORT, &GPIO_InitStructure);	
	
	GPIO_InitStructure.GPIO_Pin = FinRight_Thrash_GPIO_PIN;	
	GPIO_Init(FinRight_Thrash_GPIO_PORT, &GPIO_InitStructure);	
	
  //定时器通道引脚复用 
	GPIO_PinAFConfig(FinLeft_Attitude_GPIO_PORT,  FinLeft_Attitude_GPIO_PINSOURCE, 	FinLeft_Attitude_GPIO_AF); 
	GPIO_PinAFConfig(FinLeft_Thrash_GPIO_PORT, 	  FinLeft_Thrash_GPIO_PINSOURCE, 		FinLeft_Thrash_GPIO_AF); 
	GPIO_PinAFConfig(FinRight_Attitude_GPIO_PORT, FinRight_Attitude_GPIO_PINSOURCE, FinRight_Attitude_GPIO_AF); 
	GPIO_PinAFConfig(FinRight_Thrash_GPIO_PORT, 	FinRight_Thrash_GPIO_PINSOURCE, 	FinRight_Thrash_GPIO_AF);	
	//工作模式配置
	//周期
  TIM_TimeBaseStructure.TIM_Period = TIM1_Period;       
	//预分频系数
  TIM_TimeBaseStructure.TIM_Prescaler = TIM1_Prescaler;	
  // 采样时钟分频
  TIM_TimeBaseStructure.TIM_ClockDivision=TIM_CKD_DIV1;
  // 计数方式
  TIM_TimeBaseStructure.TIM_CounterMode=TIM_CounterMode_Up;
	// 初始化定时器
	TIM_TimeBaseInit(TIM1, &TIM_TimeBaseStructure);
	
	//PWM模式配置
  TIM_OCInitStructure.TIM_OCMode = TIM_OCMode_PWM2;	    				//配置为PWM模式1
  TIM_OCInitStructure.TIM_OutputState = TIM_OutputState_Enable;	
  TIM_OCInitStructure.TIM_Pulse = 0;														//占空比
  TIM_OCInitStructure.TIM_OCPolarity = TIM_OCPolarity_Low;  	  //当定时器计数值小于CCR1_Val时为高电平
  TIM_OC1Init(TIM1, &TIM_OCInitStructure);	 							//使能通道1
	TIM_OC1PreloadConfig(TIM1, TIM_OCPreload_Enable);			//使能通道1重载
  TIM_OC2Init(TIM1, &TIM_OCInitStructure);	 							//使能通道2
	TIM_OC2PreloadConfig(TIM1, TIM_OCPreload_Enable);			//使能通道2重载
  TIM_OC3Init(TIM1, &TIM_OCInitStructure);	 							//使能通道3
	TIM_OC3PreloadConfig(TIM1, TIM_OCPreload_Enable);			//使能通道3重载
  TIM_OC4Init(TIM1, &TIM_OCInitStructure);	 							//使能通道4
	TIM_OC4PreloadConfig(TIM1, TIM_OCPreload_Enable);			//使能通道4重载	
	
	// 使能定时器
	TIM_Cmd(TIM1, ENABLE);	
	//主动输出使能
  TIM_CtrlPWMOutputs(TIM1, ENABLE);
}


/**************************************************************
 * @brief	TIM8 定时器 GPIO与工作模式配置
 * @param	
 * @retval
 * @addition	
**************************************************************/
void TIM8_Init(void)
{
	GPIO_InitTypeDef GPIO_InitStructure;
	TIM_TimeBaseInitTypeDef  TIM_TimeBaseStructure;
  TIM_OCInitTypeDef  TIM_OCInitStructure;
	
	//开启定时器相关的GPIO外设时钟
	TIM8_RCC_ENABLE;

  //指定引脚复用功能 
	GPIO_PinAFConfig(FinTail_Advance_GPIO_PORT,FinTail_Advance_GPIO_PINSOURCE, FinTail_Advance_GPIO_AF); 
	GPIO_PinAFConfig(Camera_Position_GPIO_PORT,Camera_Position_GPIO_PINSOURCE, Camera_Position_GPIO_AF); 
	
	//定时器通道引脚配置 														   
	GPIO_InitStructure.GPIO_Pin = FinTail_Advance_GPIO_PIN;	
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AF;    
	GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
	GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_NOPULL;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_100MHz; 
	GPIO_Init(FinTail_Advance_GPIO_PORT, &GPIO_InitStructure);
	
	//更改引脚，配置其他通道
	GPIO_InitStructure.GPIO_Pin = Camera_Position_GPIO_PIN;		
	GPIO_Init(Camera_Position_GPIO_PORT, &GPIO_InitStructure);
	
	//周期
  TIM_TimeBaseStructure.TIM_Period = TIM8_Period;
	//预分频系数
  TIM_TimeBaseStructure.TIM_Prescaler = TIM8_Prescaler;	
  // 采样时钟分频
  TIM_TimeBaseStructure.TIM_ClockDivision=TIM_CKD_DIV1;
  // 计数方式
  TIM_TimeBaseStructure.TIM_CounterMode=TIM_CounterMode_Up;
  // 重复计数器
  TIM_TimeBaseStructure.TIM_RepetitionCounter=0;	
	// 初始化定时器TIMx, x[1,8]
	TIM_TimeBaseInit(TIM8, &TIM_TimeBaseStructure);
	
  //PWM模式配置
  TIM_OCInitStructure.TIM_OCMode = TIM_OCMode_PWM2;
  TIM_OCInitStructure.TIM_OutputState = TIM_OutputState_Enable;	
  TIM_OCInitStructure.TIM_Pulse = 0;
  TIM_OCInitStructure.TIM_OCPolarity = TIM_OCPolarity_Low;

  TIM_OC1Init(TIM8, &TIM_OCInitStructure);	   			//使能通道1
	TIM_OC1PreloadConfig(TIM8, TIM_OCPreload_Enable);	//使能通道1重载
	TIM_OC2Init(TIM8, &TIM_OCInitStructure);	   			//使能通道2
	TIM_OC2PreloadConfig(TIM8, TIM_OCPreload_Enable);	//使能通道2重载
		
	// 使能定时器
	TIM_Cmd(TIM8, ENABLE);	
	
	//主动输出使能
  TIM_CtrlPWMOutputs(TIM8, ENABLE);
}


/**************************************************************
 * @brief	左右鱼鳍方向，摄像头云台位置更新
 * @param	
 * @retval
 * @addition	接收完舵机数据直接调用Servo_PositionSet();
**************************************************************/
void Servo_PositionSet()
{
	TIM_SetCompare1(TIM1, Servo_Val.FinLeft_Attitude_Position);
	TIM_SetCompare3(TIM1, Servo_Val.FinRight_Attitude_Position);
	TIM_SetCompare2(TIM8, Servo_Val.Camera_Position);
}


/**************************************************************
 * @brief	左右鱼鳍、尾部舵机循环摆动
 * @param	
 * @retval
 * @addition	除特定时刻进入中断，其余时间都在转动舵机
							视实际情况中 StartingPosition 和 EndingPosition 的大小改变程序段
**************************************************************/
void Servo_WorkingLoop()
{
	int i;
	
	//尾部推进舵机的运动
	for (i=Servo_Val.FinTail_Advance_StartingPosition; i<=Servo_Val.FinTail_Advance_EndingPosition; i += Servo_Val.FinTail_Advance_EachCCR) 	
	{
		TIM_SetCompare2(TIM8, i);
		delay_ms(Servo_Val.FinTail_Advance_DelayTime);
	}
	for (i=Servo_Val.FinTail_Advance_EndingPosition; i>=Servo_Val.FinTail_Advance_StartingPosition; i -= Servo_Val.FinTail_Advance_EachCCR) 	
	{
		TIM_SetCompare2(TIM8, i);
		delay_ms(Servo_Val.FinTail_Advance_DelayTime);
	}
	
	//左侧划水舵机的运动
	//向下拍水
	for (i=Servo_Val.FinLeft_Thrash_StartingPosition; i<=Servo_Val.FinLeft_Thrash_EndingPosition; i += Servo_Val.FinLeft_Thrash_Down_EachCCR) 	
	{
		TIM_SetCompare2(TIM1, i);
		delay_ms(Servo_Val.FinLeft_Thrash_Down_DelayTime);
	}
	//向上拍水
	for (i=Servo_Val.FinLeft_Thrash_EndingPosition; i>=Servo_Val.FinLeft_Thrash_StartingPosition; i -= Servo_Val.FinLeft_Thrash_Up_EachCCR) 	
	{
		TIM_SetCompare2(TIM1, i);
		delay_ms(Servo_Val.FinLeft_Thrash_Up_DelayTime);
	}
	
	//右侧划水舵机的运动
	//向下拍水
	for (i=Servo_Val.FinRight_Thrash_StartingPosition; i<=Servo_Val.FinRight_Thrash_EndingPosition; i += Servo_Val.FinRight_Thrash_Down_EachCCR) 	
	{
		TIM_SetCompare1(TIM1, i);
		delay_ms(Servo_Val.FinRight_Thrash_Down_DelayTime);
	}
	//向上拍水
	for (i=Servo_Val.FinRight_Thrash_EndingPosition; i>=Servo_Val.FinRight_Thrash_StartingPosition; i -= Servo_Val.FinRight_Thrash_Up_EachCCR) 	
	{
		TIM_SetCompare1(TIM1, i);
		delay_ms(Servo_Val.FinRight_Thrash_Up_DelayTime);
	}
}
