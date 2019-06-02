#ifndef  __MS5837_H
#define  __MS5837_H

#include "stm32f4xx.h"
#include "I2C.h"

/********************************************宏定义********************************************/
#define MS5837_ADDRESS		0xec

#define 		MS5837_ReadBuffer			I2C_ReadBuffer//宏定义本.c文件中IIC读取为I2C_simu.c文件中读取函数
#define			MS5837_WriteBuffer		I2C_WriteBuffer//宏定义本.c文件中IIC读取为I2C_simu.c文件中读取函数
#define			MS5837_ReadByte				I2C_Single_Read//宏定义本.c文件中IIC读取为I2C_simu.c文件中读取函数
#define			MS5837_WriteByte			I2C_Single_Write//宏定义本.c文件中IIC读取为I2C_simu.c文件中读取函数

/********************************************MS5837数据结构体********************************************/
typedef struct 
{
	float depth;
	float temp;
	float pressure;
	float offset;
}MS5837_ValueTypeDef;
extern MS5837_ValueTypeDef MS5837_Val;

/********************************************函数声明********************************************/
extern void MS5837_Init(void);
extern void MS5837_Read(void);
extern float MS5837_pressure(float conversion);
extern float MS5837_temperature(void);
extern float MS5837_depth(void);
extern void MS5837_SetOffset(float offset);
#endif

