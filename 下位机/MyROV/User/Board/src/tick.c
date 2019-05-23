/******************************************************************************
  * @file    tick.c
  * @author  陆展
  * @version V1.0
  * @date    2019-4-27
  * @brief   定时器相关代码
	* @attention 调用 TICK_TIM_Init(); 完成初始化
*******************************************************************************/

#include "tick.h"
#include "control.h"
#include "usart1.h"

/**************************************************************
 *@brief	高级定时器 工作模式与中断 配置
 *@param	
 *@retval
 *@addition	
**************************************************************/
void TICK_TIM_Init(void)
{
	TIM_TimeBaseInitTypeDef  TIM_TimeBaseStructure;
	NVIC_InitTypeDef NVIC_InitStructure; 
	
	//开启定时器相关的外设时钟
	TICK_TIM_RCC_ENABLE;

	//周期
  TIM_TimeBaseStructure.TIM_Period = TICK_TIM_Period;
	//预分频系数
  TIM_TimeBaseStructure.TIM_Prescaler = TICK_TIM_Period;	
  // 采样时钟分频
  TIM_TimeBaseStructure.TIM_ClockDivision=TIM_CKD_DIV1;
  // 计数方式
  TIM_TimeBaseStructure.TIM_CounterMode=TIM_CounterMode_Up;
  // 重复计数器
  TIM_TimeBaseStructure.TIM_RepetitionCounter=0;	
	// 初始化定时器TIM4
	TIM_TimeBaseInit(TICK_TIM, &TIM_TimeBaseStructure);
	//清除中断标志位 
	TIM_ClearFlag(TICK_TIM, TIM_FLAG_Update); 
	//使能指定的TIM中断   ：更新中断源 触发中断源
	TIM_ITConfig(TICK_TIM, TIM_IT_Update , ENABLE);         
	
	NVIC_InitStructure.NVIC_IRQChannel = TIM4_IRQn;
	NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority=0;	//抢占优先级0
	NVIC_InitStructure.NVIC_IRQChannelSubPriority = 0;				//子优先级0
	NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;			//IRQ通道使能
	NVIC_Init(&NVIC_InitStructure);	//根据指定的参数初始化VIC寄存器
		
	// 使能定时器
	TIM_Cmd(TICK_TIM, ENABLE);	
}

/***************************************************************
 *@brief TIM8 中断处理函数
 *@param
 *@retval
 *@addition
****************************************************************/
void TIM4_IRQHandler(void)
{
	if(TIM_GetITStatus(TICK_TIM, TIM_IT_Update) != RESET)
  {
		//添加你想要的内容
		TimeSlice.Count_20ms += 10;
		TimeSlice.Count_50ms += 10;
		TimeSlice.Count_100ms += 10;
		TimeSlice.Count_200ms += 10;
		TimeSlice.Count_5000ms += 10;
		TIM_ClearITPendingBit(TICK_TIM, TIM_IT_Update);
  }
}
