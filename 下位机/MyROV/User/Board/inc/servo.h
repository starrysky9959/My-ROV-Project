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

//通道1 控制摄像机云台位置的舵机
#define FinTail_Advance_GPIO_PIN          			GPIO_Pin_6            
#define FinTail_Advance_GPIO_PORT       				GPIOC                      
#define FinTail_Advance_GPIO_PINSOURCE					GPIO_PinSource6
#define FinTail_Advance_GPIO_AF									GPIO_AF_TIM8

//通道2 控制尾部推进的舵机
#define Camera_Position_GPIO_PIN          			GPIO_Pin_7            
#define Camera_Position_GPIO_PORT       				GPIOC                      
#define Camera_Position_GPIO_PINSOURCE					GPIO_PinSource7
#define Camera_Position_GPIO_AF									GPIO_AF_TIM8



/********************************************舵机数据结构体********************************************/
typedef struct
{
  uint16_t FinTail_Advance_StartingPosition;  //尾部推进舵机 起始位置
  uint16_t FinTail_Advance_EndingPosition;    //尾部推进舵机 终止位置
  uint16_t FinTail_Advance_EachCCR;           //尾部推进舵机 每次改变的占空比
  uint16_t FinTail_Advance_DelayTime;         //尾部推进舵机 延时长度

	uint16_t FinLeft_Attitude_Position;   			//左侧鱼鳍姿态舵机 终止位置

	uint16_t FinLeft_Thrash_StartingPosition;   //左侧鱼鳍划水舵机 起始位置
  uint16_t FinLeft_Thrash_EndingPosition;     //左侧鱼鳍划水舵机 终止位置
  uint16_t FinLeft_Thrash_Down_EachCCR;       //左侧鱼鳍划水舵机 向下拍水时 每次改变的占空比
  uint16_t FinLeft_Thrash_Down_DelayTime;     //左侧鱼鳍划水舵机 向下拍水时 延时长度
  uint16_t FinLeft_Thrash_Up_EachCCR;         //左侧鱼鳍划水舵机 向上拍水时 每次改变的占空比
  uint16_t FinLeft_Thrash_Up_DelayTime;       //左侧鱼鳍划水舵机 向上拍水时 延时长度        

  uint16_t FinRight_Attitude_Position;  			//右侧鱼鳍姿态舵机 终止位置

  uint16_t FinRight_Thrash_StartingPosition;  //右侧鱼鳍划水舵机 起始位置
  uint16_t FinRight_Thrash_EndingPosition;    //右侧鱼鳍划水舵机 终止位置
  uint16_t FinRight_Thrash_Down_EachCCR;      //右侧鱼鳍划水舵机 向下拍水时 每次改变的占空比
  uint16_t FinRight_Thrash_Down_DelayTime;    //右侧鱼鳍划水舵机 向下拍水时 延时长度
  uint16_t FinRight_Thrash_Up_EachCCR;        //右侧鱼鳍划水舵机 向上拍水时 每次改变的占空比
  uint16_t FinRight_Thrash_Up_DelayTime;      //右侧鱼鳍划水舵机 向上拍水时 延时长度    

  uint16_t Camera_Position;                   //摄像机云台舵机 位置  
}SERVO_ValTypedef;

extern SERVO_ValTypedef Servo_Val;

typedef struct
{
	int Left[120];
	int Right[120];
	int Len_Left;
	int Len_Left_Down;
	int Len_Left_Up;
	int Len_Right;
	int Len_Right_Down;
	int Len_Right_Up;
}STEP_ValTypedef;

extern STEP_ValTypedef Step_Val;

/********************************************函数声明********************************************/
extern void TIM1_Init(void);
extern void TIM8_Init(void);
extern void Servo_PositionSet(void);
extern void Servo_WorkingLoop(void);
extern void Servo_Reset(void);
extern void Servo_Calculation(void);
#endif
