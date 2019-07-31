#ifndef __SERVO_H
#define	__SERVO_H

#include "stm32f4xx.h"

/********************************************宏定义********************************************/
//TIM1 定时器 
#define TIM1_RCC_ENABLE  												RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOA, ENABLE);\
																								RCC_APB2PeriphClockCmd(RCC_APB2Periph_TIM1, ENABLE)																		

#define TIM1_Period															(20000-1)
#define TIM1_Prescaler 													(180-1)

//通道1 右侧控制划水的鱼鳍舵机
#define FinLeft_Attitude_GPIO_PIN          			GPIO_Pin_8             
#define FinLeft_Attitude_GPIO_PORT       				GPIOA                      
#define FinLeft_Attitude_GPIO_PINSOURCE					GPIO_PinSource8
#define FinLeft_Attitude_GPIO_AF								GPIO_AF_TIM1

//通道2 左侧控制划水的鱼鳍舵机
#define FinLeft_Thrash_GPIO_PIN          				GPIO_Pin_9             
#define FinLeft_Thrash_GPIO_PORT       					GPIOA                      
#define FinLeft_Thrash_GPIO_PINSOURCE						GPIO_PinSource9
#define FinLeft_Thrash_GPIO_AF									GPIO_AF_TIM1

//通道3 右侧控制姿态的鱼鳍舵机
#define FinRight_Attitude_GPIO_PIN          		GPIO_Pin_10            
#define FinRight_Attitude_GPIO_PORT       			GPIOA                  
#define FinRight_Attitude_GPIO_PINSOURCE				GPIO_PinSource10
#define FinRight_Attitude_GPIO_AF								GPIO_AF_TIM1

//通道4 左侧控制姿态的鱼鳍舵机
#define FinRight_Thrash_GPIO_PIN          			GPIO_Pin_11          
#define FinRight_Thrash_GPIO_PORT       				GPIOA                      
#define FinRight_Thrash_GPIO_PINSOURCE					GPIO_PinSource11
#define FinRight_Thrash_GPIO_AF									GPIO_AF_TIM1


//TIM8 定时器
#define TIM8_RCC_ENABLE       		   						RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOC , ENABLE);\
																								RCC_APB2PeriphClockCmd(RCC_APB2Periph_TIM8, ENABLE);																				

#define TIM8_Period															(20000-1)
#define TIM8_Prescaler 													(180-1)

//通道2 控制摄像机云台位置的舵机
#define Camera_Position_GPIO_PIN          			GPIO_Pin_7           
#define Camera_Position_GPIO_PORT       				GPIOC                      
#define Camera_Position_GPIO_PINSOURCE					GPIO_PinSource7
#define Camera_Position_GPIO_AF									GPIO_AF_TIM8

//通道3 控制尾部舵机（前）
#define FinTail_Front_GPIO_PIN          				GPIO_Pin_8       
#define FinTail_Front_GPIO_PORT       					GPIOC                      
#define FinTail_Front_GPIO_PINSOURCE						GPIO_PinSource8
#define FinTail_Front_GPIO_AF										GPIO_AF_TIM8

//通道4 控制尾部舵机（后）
#define FinTail_Rear_GPIO_PIN          					GPIO_Pin_9            
#define FinTail_Rear_GPIO_PORT       						GPIOC                      
#define FinTail_Rear_GPIO_PINSOURCE							GPIO_PinSource9
#define FinTail_Rear_GPIO_AF										GPIO_AF_TIM8

/********************************************舵机数据结构体********************************************/
typedef struct
{
	uint16_t FinTail_Front_StartingPosition;  		//尾部舵机（前） 起始位置
  uint16_t FinTail_Front_EndingPosition;    		//尾部舵机（前） 终止位置
  uint16_t FinTail_Front_EachCCR;           		//尾部舵机（前） 每次改变的占空比
  uint16_t FinTail_Front_DelayTime;         		//尾部舵机（前） 延时长度
		
	uint16_t FinTail_Rear_StartingPosition; 	 		//尾部舵机（后） 起始位置
  uint16_t FinTail_Rear_EndingPosition;    			//尾部舵机（后） 终止位置
  uint16_t FinTail_Rear_EachCCR;           			//尾部舵机（后） 每次改变的占空比
  uint16_t FinTail_Rear_DelayTime;         			//尾部舵机（后） 延时长度
	
  uint16_t Camera_Position;                   //摄像机云台舵机 位置 
	uint16_t Pulse_Num;                         	//脉冲数
}SERVO_ValTypedef;

extern SERVO_ValTypedef Servo_Val;


/********************************************函数声明********************************************/
extern void TIM1_Init(void);
extern void TIM8_Init(void);
extern void Servo_PositionSet(void);
extern void Servo_WorkingLoop(void);
extern void Servo_Reset(void);
#endif
