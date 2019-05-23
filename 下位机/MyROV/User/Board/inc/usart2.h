#ifndef __USART2_H
#define	__USART2_H

#include "stm32f4xx.h"
#include <stdio.h>

/********************************************宏定义********************************************/

/* 不同的串口挂载的总线不一样，时钟使能函数也不一样，移植时要注意 
 * 串口1和6是      RCC_APB2PeriphClockCmd
 * 串口2/3/4/5/7是 RCC_APB1PeriphClockCmd
 */
#define	USART2_RCC_ENABLE									 RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOD, ENABLE);\
																					 RCC_APB1PeriphClockCmd(RCC_APB1Periph_USART2, ENABLE)
																					 
#define USART2_TX_GPIO_PORT                GPIOD
#define USART2_TX_GPIO_CLK                 RCC_AHB1Periph_GPIOD
#define USART2_TX_PIN                      GPIO_Pin_5
#define USART2_TX_AF                       GPIO_AF_USART2
#define USART2_TX_SOURCE                   GPIO_PinSource5

#define USART2_RX_GPIO_PORT                GPIOD
#define USART2_RX_GPIO_CLK                 RCC_AHB1Periph_GPIOD
#define USART2_RX_PIN                      GPIO_Pin_6
#define USART2_RX_AF                       GPIO_AF_USART2
#define USART2_RX_SOURCE                   GPIO_PinSource6


/********************************************函数声明********************************************/
extern void USART2_Init(int baudrate);
extern void USART2_PutChar(char ch);

#endif 
