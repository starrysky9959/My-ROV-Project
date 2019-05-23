/******************************************************************************
  * @file    led.c
  * @author  陆展
  * @version V1.0
  * @date    2019-4-34
  * @brief   LED灯相关代码
	* @attention 调用LED_Init();完成初始化
							 具体控制灯参见led.h
*******************************************************************************/
#include "led.h"   

/**************************************************************
 *@brief	LED灯初始化
 *@param	
 *@retval
 *@addition	
**************************************************************/
void LED_Init(void)
{		
	GPIO_InitTypeDef GPIO_InitStructure;
	
	//开启LED相关的GPIO外设时钟
	RCC_AHB1PeriphClockCmd ( LED1_GPIO_CLK | LED2_GPIO_CLK | LED3_GPIO_CLK, ENABLE); 
														   
	GPIO_InitStructure.GPIO_Pin = LED1_PIN;							//选择要控制的GPIO引脚
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_OUT;   		//设置引脚模式为输出模式
  GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;	    //设置引脚的输出类型为推挽输出
  GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_UP;			  //设置引脚为上拉模式 
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_2MHz;  //设置引脚速率为2MHz

	GPIO_Init(LED1_GPIO_PORT, &GPIO_InitStructure);	//调用库函数，使用上面配置的GPIO_InitStructure初始化GPIO
  
	//同理配置LED2，LED3										   
	GPIO_InitStructure.GPIO_Pin = LED2_PIN;	
  GPIO_Init(LED2_GPIO_PORT, &GPIO_InitStructure);	
														   
	GPIO_InitStructure.GPIO_Pin = LED3_PIN;	
  GPIO_Init(LED3_GPIO_PORT, &GPIO_InitStructure);	
	//关灯
	LED1_OFF;
	LED2_OFF;
	LED3_OFF;	
}
