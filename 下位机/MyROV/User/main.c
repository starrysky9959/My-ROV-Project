/******************************************************************************
  * @file    main.c
  * @author  陆展
  * @version V1.0
  * @date    2019-4-24
  * @brief   空白工程模板
	* @attention 有串口，延时，LED灯，PWM输出
*******************************************************************************/
  
#include "stm32f4xx.h"
#include "led.h" 
#include "usart1.h" 
#include "usart2.h"
#include "systick.h"
#include "servo.h"
#include "JY901.h"
#include "tick.h"
#include "MS5837.h"
#include "timeslice.h"
#include "control.h"

SERVO_ValTypedef 	 Servo_Val={0};
JY901_ValTypedef	 JY901_Val={0};
Mode_ValTypedef 	 Mode_Val={0};

/**************************************************************
 *@brief	主函数
 *@param
 *@retval
 *@addition
**************************************************************/
int main(void)
{	
	//int i=0;
	NVIC_PriorityGroupConfig(NVIC_PriorityGroup_2); //设置NVIC中断分组2:2位抢占优先级，2位响应优先级
	SysTick_Init();	//延时函数初始化
  //LED_Init();			//初始化RGB彩灯
	//LED1_ON;
  USART1_Init(115200);  //初始化USART3 下位机<——>PC端
	USART2_Init(9600);		//初始化USART2	JY901——>下位机
	TIM1_Init();
	TIM8_Init();
	TICK_TIM_Init();
	MS5837_Init();
	while (1)
	{
		Servo_WorkingLoop();	//舵机摆动
		SpecialAction();			//按时序做特殊动作
	}

}
