/******************************************************************************
  * @file    systick.c
  * @author  陆展
  * @version V1.0
  * @date    2019-4-34
  * @brief   系统定时器相关代码
	* @attention SysTick_Init(); 调用即可
*******************************************************************************/

#include "systick.h"

static __IO u32 TimingDelay;
 
/*****************************************************
 * @brief  启动系统滴答定时器 SysTick
 * @param  
 * @retval 
 * @addition
******************************************************/
void SysTick_Init(void)
{
	/* SystemFrequency / 1000    1ms中断一次
	 * SystemFrequency / 100000	 10us中断一次
	 * SystemFrequency / 1000000 1us中断一次
	 */
	if (SysTick_Config(SystemCoreClock / 100000))
	{ 
		/* Capture error */ 
		while (1);
	}
}


/*****************************************************
 * @brief  us延时程序,10us为一个单位
 * @param  
	 	 @arg	 nTime: Delay_us( 1 ) 则实现的延时为 1 * 10us = 10us
 * @retval 
 * @addition
******************************************************/
void delay_us(__IO u32 nTime)
{ 
	TimingDelay = nTime;	

	while(TimingDelay != 0);
}


/*****************************************************
 * @brief  获取节拍程序
 * @param  
 * @retval 
 * @addition	在 SysTick 中断函数 SysTick_Handler()调用
******************************************************/
void TimingDelay_Decrement(void)
{
	if (TimingDelay != 0x00)
	{ 
		TimingDelay--;
	}
}
