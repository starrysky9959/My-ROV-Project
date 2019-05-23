#ifndef __SYSTICK_H
#define __SYSTICK_H

#include "stm32f4xx.h"

/********************************************函数声明********************************************/
void SysTick_Init(void);
void delay_us(__IO u32 nTime);
#define delay_ms(x) delay_us(100*x)	 //单位ms

#endif
