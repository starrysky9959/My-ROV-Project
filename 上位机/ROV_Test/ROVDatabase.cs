using System;


namespace ROV_Test
{
    /// <summary>
    /// 所有ROV相关的数据结构体都声明在这里
    /// </summary>
    public class ROVDatabase 
    {
        //控制模式选择
        public struct ModeSelection
        {
            public int ControlMode;         //0 表示自由操控模式 ；1 表示PID闭环控制模式；2 表示对象追踪模式
            //0 表示不可调；1 表示可调
            //前三个PID控制至多选一个
            public int PitchMode;           
            public int AngleSpeedYMode;
            public int DepthMode;
            public int AccelerationYMode;
        }
        public ModeSelection Mode = new ModeSelection();

        //姿态传感器数据 JY901
        public struct JY901
        {
            public float AccelerationX;     //X轴加速度  
            public float AccelerationY;     //Y轴加速度  
            public float AccelerationZ;     //Z轴加速度  
            public float PitchAngle;        //俯仰角
            public float YawAngle;          //偏航角
            public float RollAngle;         //翻滚角
            public float AngleSpeedX;       //X轴角速度      
            public float AngleSpeedY;       //Y轴角速度              
            public float AngleSpeedZ;       //Z轴角速度

        };
        public JY901 JY901Data = new JY901();


        //深度传感器数据 MS5837
        public struct MS5837
        {
            public float Pressure;          //压力
            public float Depth;             //深度
            public float Temperature;       //温度
            public float Offset;            //水深修正补偿值
        };
        public MS5837 MS5837Data = new MS5837();


        //舵机数据  
        public struct SERVO
        {
            public UInt16 FinTail_Front_StartingPosition;  //尾部舵机(前) 起始位置
            public UInt16 FinTail_Front_EndingPosition;    //尾部舵机(前) 终止位置
            public UInt16 FinTail_Front_EachCCR;           //尾部舵机(前) 每次改变的占空比
            public UInt16 FinTail_Front_DelayTime;         //尾部舵机(前) 延时长度

            public UInt16 FinTail_Rear_StartingPosition;  //尾部舵机(后) 起始位置
            public UInt16 FinTail_Rear_EndingPosition;    //尾部舵机(后) 终止位置
            public UInt16 FinTail_Rear_EachCCR;           //尾部舵机(后) 每次改变的占空比
            public UInt16 FinTail_Rear_DelayTime;         //尾部舵机(后) 延时长度

            public UInt16 Camera_Position;                   //摄像机云台舵机   终止位置    
            public UInt16 Pulse_Num;                         //脉冲数
        };
        public SERVO ServoData = new SERVO();


        public struct PID
        {
            public float Kp;
            public float Ki;
            public float Kd;
            public float Target;
        };
        public PID pidData_Depth = new PID();
        public PID pidData_Pitch = new PID();
        public PID pidData_Yaw = new PID();
        public PID pidData_AccelerationY = new PID();

 
    }

}
