/******************************************************************************
  * @file    stepper.c
  * @author  陆展
  * @version V1.0
  * @date    2019-7-23
  * @brief   定时器相关代码
	* @attention 调用 Stepper_Init(); 完成初始化
*******************************************************************************/
#include "stm32f4xx.h"  
#include "stepper.h"
#include "systick.h"

extern int32_t current_pos;
/**************************************************************
 *@brief	与驱动器 EN、DIR相连的IO口初始化
 *@param
 *@retval
 *@addition	PC0：EN+  电机脱机控制正。
						PC1：DIR+ 电机正、反转控制正。
						打开脱机功能后，电机转子处于自由不锁定状态，可以轻松转动，此时输入脉冲信号不响应，关闭此信号后电机接受脉冲信号正常运转。
**************************************************************/
void Stepper_Init()
{
	GPIO_InitTypeDef GPIO_InitStructure; 
	
	STEPPER_RCC_ENABLE;
	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_9 | GPIO_Pin_10; 	  //配置GPIO管脚
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_OUT;				//输出模式
	GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;			//推挽输出
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;		//50M
	GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_UP;				//上拉
	GPIO_Init(GPIOA, &GPIO_InitStructure); 										//初始化GPIO
	
	GPIO_SetBits(GPIOA, GPIO_Pin_9);													//输出高电平 顺时针旋转
	GPIO_SetBits(GPIOA, GPIO_Pin_10);	
}


/**************************************************************
 *@brief	输出指定数量脉冲使步进电机朝指定方向旋转
 *@param	dir：方向
					num：脉冲数
 *@retval
 *@addition	
**************************************************************/
void Direction(int32_t dir, int32_t num)
{
	int32_t i;
	switch (dir)
	{
		case (ACW):	//逆时针
		{
			GPIO_SetBits(GPIOA, GPIO_Pin_9);			//逆时针
			for(i = 0; i < num; i++) 						// 1000 个脉冲
			{
				GPIO_ResetBits(GPIOA, GPIO_Pin_10);  //输出低电平
				delay_us(30);
				GPIO_SetBits(GPIOA, GPIO_Pin_10);		//输出高电平
				delay_us(30);
			}
			current_pos -= num;
			GPIO_ResetBits(GPIOA, GPIO_Pin_10); 		//暂停
			break;
		}
		
		case (CW):	//顺时针
		{
			GPIO_ResetBits(GPIOA, GPIO_Pin_9);			//顺时针
			for(i = 0; i < num; i++) 						// 1000 个脉冲
			{
				GPIO_ResetBits(GPIOA, GPIO_Pin_10);  //输出低电平
				delay_us(30);
				GPIO_SetBits(GPIOA, GPIO_Pin_10);		//输出高电平
				delay_us(30);
			}
			current_pos += num;
			GPIO_ResetBits(GPIOA, GPIO_Pin_10); 		//暂停
			break;
		}	
	}
}


/**************************************************************
 *@brief	使电机转动到指定位置
 *@param	
 *@retval
 *@addition	
**************************************************************/
void AbsPosition(int32_t pos)
{
	if (pos < current_pos)
	{
		Direction(ACW, current_pos - pos);
	}else
	{
		Direction(CW, pos - current_pos);
	}
}
