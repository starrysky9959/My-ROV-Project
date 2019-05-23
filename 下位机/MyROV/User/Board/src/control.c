#include "control.h"
#include "JY901.h"
#include "MS5837.h"

struct PID PID_Depth;
struct PID PID_Pitch;
struct PID PID_AngleSpeedY;
struct PID PID_AccelerationY;
struct TS TimeSlice;

/*****************************************************
 * @brief  PID±Õ»·¿ØÖÆ	
 * @param  
 * @retval 
 * @addition
******************************************************/
void ClosedLoop_Control(void)
{
	if (Mode_Val.DepthMode==1)
	{
		PID_Depth.CurrentValue = MS5837_Val.depth;
		Calculate(&PID_Depth);
		DebugPID(&PID_Depth, "PID");
		//balabala
	}
}
