/******************************************************************************
  * @file    main.c
  * @author  陆展
  * @version V1.0
  * @date    2019-4-24
  * @brief   我的ROV下位机主程序完成一切初始化，接受发送数据，按指令行动
	* @attention 有串口，延时，JY901姿态传感器，MS5837深度传感器，定时器
*******************************************************************************/
  
#include "stm32f4xx.h"
#include "usart1.h" 
#include "usart2.h"
#include "systick.h"
#include "servo.h"
#include "JY901.h"
#include "tick.h"
#include "MS5837.h"
#include "timeslice.h"
#include "control.h"
#include "datapocket.h"

SERVO_ValTypedef 	 Servo_Val={0};
JY901_ValTypedef	 JY901_Val={0};
Mode_ValTypedef 	 Mode_Val={0};
STEP_ValTypedef 	 Step_Val={0};
struct TS TimeSclice={0};
/**************************************************************
 * @brief	主函数
 * @param
 * @retval
 * @addition
**************************************************************/
int main(void)
{	
	NVIC_PriorityGroupConfig(NVIC_PriorityGroup_2); //设置NVIC中断分组2:2位抢占优先级，2位响应优先级
	SysTick_Init();	//延时函数初始化
  USART1_Init(115200);  //初始化USART1 下位机<——>PC端
	USART2_Init(9600);		//初始化USART2	JY901——>下位机
	TIM1_Init();					//舵机相关定时器初始化
	TIM8_Init();					//舵机相关定时器初始化
	MS5837_Init();				//深度传感器初始化
	Servo_Reset();				//舵机位置初始化
	//Servo_Calculation();  //舵机步进值计算
	TICK_TIM_Init();			//计时的定时器初始化

	//动起来
	while (1)
	{				
//		TIM_SetCompare2(TIM1,  3400);
//			delay_ms(1000);
//		TIM_SetCompare1(TIM1, 4400);
//		delay_ms(1000);
		//Servo_PositionSet();	//舵机位置更新
		Servo_WorkingLoop();	//舵机摆动
	}
}
