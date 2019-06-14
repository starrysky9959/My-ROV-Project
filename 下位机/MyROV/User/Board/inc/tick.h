#ifndef __TICK_H
#define __TICK_H

#include "stm32f4xx.h"
/********************************************宏定义********************************************/
//通用定时器TIM4
#define TICK_TIM_RCC_ENABLE       		   		RCC_APB1PeriphClockCmd(RCC_APB1Periph_TIM4, ENABLE);																				
#define TICK_TIM           		    					TIM4

#define TICK_TIM_Period											(1000-1)
#define TICK_TIM_Prescaler 									(1800-1)

/********************************************函数声明********************************************/
extern void TICK_TIM_Init(void);

#endif
