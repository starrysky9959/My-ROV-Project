#ifndef __CONTROL_H
#define __CONTROL_H

#include "stm32f4xx.h"
#include "PID.h"
#include "timeslice.h"

/*****************************************结构体声明***********************************************/
typedef struct 
{
	int Control_mode;
	int DepthMode;
	int PitchMode;           
	int AngleSpeedYMode;
	int AccelerationYMode;
}Mode_ValTypedef;

extern Mode_ValTypedef Mode_Val;

extern struct PID PID_Depth;
extern struct PID PID_Pitch;
extern struct PID PID_AngleSpeedY;
extern struct PID PID_AccelerationY;
extern struct TS TimeSlice;

/************************************************函数声明*********************************************/
extern void ClosedLoop_Control(void);

#endif
