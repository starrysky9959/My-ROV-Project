#ifndef __USART1_H
#define	__USART1_H

#include "stm32f4xx.h"
#include <stdio.h>

/********************************************宏定义********************************************/

/* 不同的串口挂载的总线不一样，时钟使能函数也不一样，移植时要注意 
 * 串口1和6是      RCC_APB2PeriphClockCmd
 * 串口2/3/4/5/7是 RCC_APB1PeriphClockCmd
 */
#define	USART1_RCC_ENABLE									 RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOB, ENABLE);\
																					 RCC_APB2PeriphClockCmd(RCC_APB2Periph_USART1, ENABLE)
																					 
#define USART1_TX_GPIO_PORT                GPIOB
#define USART1_TX_PIN                      GPIO_Pin_6
#define USART1_TX_AF                       GPIO_AF_USART1
#define USART1_TX_SOURCE                   GPIO_PinSource6

#define USART1_RX_GPIO_PORT                GPIOB
#define USART1_RX_PIN                      GPIO_Pin_7
#define USART1_RX_AF                       GPIO_AF_USART1
#define USART1_RX_SOURCE                   GPIO_PinSource7


/********************************************函数声明********************************************/
extern void USART1_Init(int baudrate);
extern void USART1_PutChar(char ch);

#endif 
