using System;
using System.Collections.Generic;
using static ROV_Test.Data;



namespace ROV_Test
{
    /// <summary>
    /// 用于接收发送数据的相关处理
    /// </summary>
    class Data_TX_RX
    {

#region 接收数据包相关常量定义
        //接收数据包校验位
        public static byte RX_CheckBit              = 0x00;     

        //数据长度
        public const int RX_JY901_BUFF_LEN          = 36;        //JY901 参数数据包长度
        public const int RX_MS5837_BUFF_LEN         = 16;        //MS5837 参数数据包长度
        public const int RX_SERVO_BUFF_LEN          = 38;        //舵机参数数据包长度
        public const int RX_PID_BUFF_LEN            = 64;   	 //PID系数数据包长度

        //数据头，数据类型位
        public const byte RX_StartBit_JY901         = 0xAA;      //接收JY901姿态传感器数据
        public const byte RX_StartBit_MS5837        = 0xAB;		 //接收MS5837深度传感器数据
        public const byte RX_StartBit_SERVO         = 0xAC;      //接收舵机数据
        public const byte RX_StartBit_PID           = 0xAD;      //接收PID系数数据
#endregion


#region 发送数据包相关常量定义
        //数据长度
        public const int TX_MODE_BUFF_LEN           = 20;      //操作模式变更指令数据包长度
        public const int TX_SERVO_BUFF_LEN          = 38;     //舵机指令数据包长度
        public const int TX_PID_BUFF_LEN            = 64;     //PID指令数据包长度

        //数据头，数据类型位
        public const byte TX_StartBit_MODE          = 0xAB;      //向下位机传输操作模式变更指令
        public const byte TX_StartBit_SERVO         = 0xAC;		 //向下位机传输舵机指令
        public const byte TX_StartBit_PID           = 0xAD;      //向下位机传输PID指令
#endregion


        static List<byte> List_RxBuffer = new List<byte>(); //用于接收数据的集合
        /// <summary>
        /// 接收数据并校验
        /// </summary>
        /// <param name="data">一个数据位</param>
        public static void ReceiveAndCheck(byte data)
        {
            //添加新数据至集合
            List_RxBuffer.Add(data);

            //数据头不匹配，舍去
            if (List_RxBuffer[0] != RX_StartBit_JY901 &&
                List_RxBuffer[0] != RX_StartBit_MS5837 &&
                List_RxBuffer[0] != RX_StartBit_SERVO )
            {
                List_RxBuffer.Clear();
                return;
            }
            
            //数据包未接受完，返回继续接收
            if ((List_RxBuffer.Count < RX_JY901_BUFF_LEN + 2 && List_RxBuffer[0] == RX_StartBit_JY901) ||
                (List_RxBuffer.Count < RX_MS5837_BUFF_LEN + 2 && List_RxBuffer[0] == RX_StartBit_MS5837)||
                (List_RxBuffer.Count < RX_SERVO_BUFF_LEN + 2 && List_RxBuffer[0] == RX_StartBit_SERVO) ||
                (List_RxBuffer.Count < RX_PID_BUFF_LEN + 2 && List_RxBuffer[0] == RX_StartBit_PID))
                return;

            //完整的数据包接收完成，进行数据校验
            for (int i = 0; i < List_RxBuffer.Count - 1; i++)
                RX_CheckBit ^= List_RxBuffer[i];

            //校验位不匹配，舍弃数据
            if (RX_CheckBit != List_RxBuffer[List_RxBuffer.Count - 1])
            {
                List_RxBuffer.Clear();
                RX_CheckBit = 0x00;
                return;
            }
            //MessageBox.Show("解包成功");
            //数据包正确接收，开始解包
            DataRX_Handler(List_RxBuffer, ref MyRov);

            //集合，校验位归零，准备接受新的数据包
            List_RxBuffer.Clear();
            RX_CheckBit = 0x00;
        }


        /// <summary>
        /// 对接收到的下位机传来的数据包进行解包
        /// </summary>
        /// <param name="Buffer">数据包</param>
        /// <param name="MyRov">ROV数据结构体</param>
        public static void DataRX_Handler(List<byte> Buffer, ref ROVDatabase MyRov)
        {
            byte[] RxBuffer = Buffer.ToArray(); //数据包数组
            switch(RxBuffer[0])
            {
                case (RX_StartBit_JY901):  //表示待解析的是JY901姿态传感器的数据包
                    {
                        MyRov.JY901Data.AccelerationX = BitConverter.ToSingle(RxBuffer, 1);
                        MyRov.JY901Data.AccelerationY = BitConverter.ToSingle(RxBuffer, 5);
                        MyRov.JY901Data.AccelerationZ = BitConverter.ToSingle(RxBuffer, 9);
                        MyRov.JY901Data.PitchAngle    = BitConverter.ToSingle(RxBuffer, 13);
                        MyRov.JY901Data.YawAngle      = BitConverter.ToSingle(RxBuffer, 17);
                        MyRov.JY901Data.RollAngle     = BitConverter.ToSingle(RxBuffer, 21);
                        MyRov.JY901Data.AngleSpeedX   = BitConverter.ToSingle(RxBuffer, 25);
                        MyRov.JY901Data.AngleSpeedY   = BitConverter.ToSingle(RxBuffer, 29);
                        MyRov.JY901Data.AngleSpeedZ   = BitConverter.ToSingle(RxBuffer, 33);
                        break;
                    }

                case (RX_StartBit_MS5837):  //表示待解析的是MS5837深度传感器的数据包
                    {
                        MyRov.MS5837Data.Pressure    = BitConverter.ToSingle(RxBuffer, 1);
                        MyRov.MS5837Data.Depth       = BitConverter.ToSingle(RxBuffer, 5);
                        MyRov.MS5837Data.Temperature = BitConverter.ToSingle(RxBuffer, 9);
                        MyRov.MS5837Data.Offset      = BitConverter.ToSingle(RxBuffer, 13);
                        break;
                    }

                case (RX_StartBit_SERVO):  //表示待解析的是舵机的数据包
                    {         
                        MyRov.ServoData.FinTail_Advance_StartingPosition = BitConverter.ToUInt16(RxBuffer, 1); //尾部推进舵机 起始位置
                        MyRov.ServoData.FinTail_Advance_EndingPosition   = BitConverter.ToUInt16(RxBuffer, 3); //尾部推进舵机 终止位置
                        MyRov.ServoData.FinTail_Advance_EachCCR          = BitConverter.ToUInt16(RxBuffer, 5); //尾部推进舵机 每次改变的占空比
                        MyRov.ServoData.FinTail_Advance_DelayTime        = BitConverter.ToUInt16(RxBuffer, 7);//尾部推进舵机 延时长度

                        MyRov.ServoData.FinLeft_Attitude_Position        = BitConverter.ToUInt16(RxBuffer, 9);//左侧鱼鳍姿态舵机 终止位置

                        MyRov.ServoData.FinLeft_Thrash_StartingPosition  = BitConverter.ToUInt16(RxBuffer, 11);//左侧鱼鳍划水舵机 起始位置
                        MyRov.ServoData.FinLeft_Thrash_EndingPosition    = BitConverter.ToUInt16(RxBuffer, 13);//左侧鱼鳍划水舵机 终止位置
                        MyRov.ServoData.FinLeft_Thrash_Down_EachCCR      = BitConverter.ToUInt16(RxBuffer, 15);//左侧鱼鳍划水舵机 向下拍水时 每次改变的占空比
                        MyRov.ServoData.FinLeft_Thrash_Down_DelayTime    = BitConverter.ToUInt16(RxBuffer, 17);//左侧鱼鳍划水舵机 向下拍水时 延时长度
                        MyRov.ServoData.FinLeft_Thrash_Up_EachCCR        = BitConverter.ToUInt16(RxBuffer, 19);//左侧鱼鳍划水舵机 向上拍水时 每次改变的占空比
                        MyRov.ServoData.FinLeft_Thrash_Up_DelayTime      = BitConverter.ToUInt16(RxBuffer, 21);//左侧鱼鳍划水舵机 向上拍水时 延时长度        

                        MyRov.ServoData.FinRight_Attitude_Position       = BitConverter.ToUInt16(RxBuffer, 23);//右侧鱼鳍姿态舵机 终止位置

                        MyRov.ServoData.FinRight_Thrash_StartingPosition = BitConverter.ToUInt16(RxBuffer, 25);//右侧鱼鳍划水舵机 起始位置
                        MyRov.ServoData.FinRight_Thrash_EndingPosition   = BitConverter.ToUInt16(RxBuffer, 27);//右侧鱼鳍划水舵机 终止位置
                        MyRov.ServoData.FinRight_Thrash_Down_EachCCR     = BitConverter.ToUInt16(RxBuffer, 29);//右侧鱼鳍划水舵机 向下拍水时 每次改变的占空比
                        MyRov.ServoData.FinRight_Thrash_Down_DelayTime   = BitConverter.ToUInt16(RxBuffer, 31);//右侧鱼鳍划水舵机 向下拍水时 延时长度
                        MyRov.ServoData.FinRight_Thrash_Up_EachCCR       = BitConverter.ToUInt16(RxBuffer, 33);//右侧鱼鳍划水舵机 向上拍水时 每次改变的占空比
                        MyRov.ServoData.FinRight_Thrash_Up_DelayTime     = BitConverter.ToUInt16(RxBuffer, 35);//右侧鱼鳍划水舵机 向上拍水时 延时长度    

                        MyRov.ServoData.Camera_Position = BitConverter.ToUInt16(RxBuffer, 37);//摄像机云台舵机 位置   
                        break;
                    }
                case (RX_StartBit_PID):  //表示待解析的是PID系数的数据包
                    {
                        MyRov.pidData_Depth.Kp     = BitConverter.ToSingle(RxBuffer, 1);
                        MyRov.pidData_Depth.Ki     = BitConverter.ToSingle(RxBuffer, 5);
                        MyRov.pidData_Depth.Kd     = BitConverter.ToSingle(RxBuffer, 9);
                        MyRov.pidData_Depth.Target = BitConverter.ToSingle(RxBuffer, 13);

                        MyRov.pidData_Pitch.Kp     = BitConverter.ToSingle(RxBuffer, 17);
                        MyRov.pidData_Pitch.Ki     = BitConverter.ToSingle(RxBuffer, 21);
                        MyRov.pidData_Pitch.Kd     = BitConverter.ToSingle(RxBuffer, 25);
                        MyRov.pidData_Pitch.Target = BitConverter.ToSingle(RxBuffer, 29);

                        MyRov.pidData_Yaw.Kp     = BitConverter.ToSingle(RxBuffer, 33);
                        MyRov.pidData_Yaw.Ki     = BitConverter.ToSingle(RxBuffer, 37);
                        MyRov.pidData_Yaw.Kd     = BitConverter.ToSingle(RxBuffer, 41);
                        MyRov.pidData_Yaw.Target = BitConverter.ToSingle(RxBuffer, 45);


                        MyRov.pidData_AccelerationY.Kp     = BitConverter.ToSingle(RxBuffer, 49);
                        MyRov.pidData_AccelerationY.Ki     = BitConverter.ToSingle(RxBuffer, 53);
                        MyRov.pidData_AccelerationY.Kd     = BitConverter.ToSingle(RxBuffer, 57);
                        MyRov.pidData_AccelerationY.Target = BitConverter.ToSingle(RxBuffer, 61);

                        break;
                    }
            }

        }


        /// <summary>
        /// 向下位机发送数据包
        /// </summary>
        /// <param name="startbit"></param>
        /// <param name="MyRov"></param>
        /// <returns></returns>
        public static byte[] DataTX_Handler(byte startbit, ROVDatabase MyRov)
        {
            byte CheckBit_TX = 0x00;    //数据发送校验位
            //初始化存储发送数据的集合，添加数据头
            List<byte> List_TxBuffer = new List<byte>
                {
                    startbit
                };
            switch(startbit)
            {
                case (TX_StartBit_MODE):    //表示发送的是控制模式
                    {
                        List_TxBuffer.AddRange(BitConverter.GetBytes(MyRov.Mode.ControlMode));
                        List_TxBuffer.AddRange(BitConverter.GetBytes(MyRov.Mode.PitchMode));
                        List_TxBuffer.AddRange(BitConverter.GetBytes(MyRov.Mode.AngleSpeedYMode));
                        List_TxBuffer.AddRange(BitConverter.GetBytes(MyRov.Mode.DepthMode));
                        List_TxBuffer.AddRange(BitConverter.GetBytes(MyRov.Mode.AccelerationYMode));
                        break;
                    }
                case (TX_StartBit_SERVO):   //表示发送的是舵机相关的指令
                    {
                        List_TxBuffer.AddRange(BitConverter.GetBytes(MyRov.ServoData.FinTail_Advance_StartingPosition));
                        List_TxBuffer.AddRange(BitConverter.GetBytes(MyRov.ServoData.FinTail_Advance_EndingPosition));
                        List_TxBuffer.AddRange(BitConverter.GetBytes(MyRov.ServoData.FinTail_Advance_EachCCR));
                        List_TxBuffer.AddRange(BitConverter.GetBytes(MyRov.ServoData.FinTail_Advance_DelayTime));

                        List_TxBuffer.AddRange(BitConverter.GetBytes(MyRov.ServoData.FinLeft_Attitude_Position));

                        List_TxBuffer.AddRange(BitConverter.GetBytes(MyRov.ServoData.FinLeft_Thrash_StartingPosition));
                        List_TxBuffer.AddRange(BitConverter.GetBytes(MyRov.ServoData.FinLeft_Thrash_EndingPosition));
                        List_TxBuffer.AddRange(BitConverter.GetBytes(MyRov.ServoData.FinLeft_Thrash_Down_EachCCR));                      
                        List_TxBuffer.AddRange(BitConverter.GetBytes(MyRov.ServoData.FinLeft_Thrash_Down_DelayTime));
                        List_TxBuffer.AddRange(BitConverter.GetBytes(MyRov.ServoData.FinLeft_Thrash_Up_EachCCR));                      
                        List_TxBuffer.AddRange(BitConverter.GetBytes(MyRov.ServoData.FinLeft_Thrash_Up_DelayTime));
                
                        List_TxBuffer.AddRange(BitConverter.GetBytes(MyRov.ServoData.FinRight_Attitude_Position));

                        List_TxBuffer.AddRange(BitConverter.GetBytes(MyRov.ServoData.FinRight_Thrash_StartingPosition));
                        List_TxBuffer.AddRange(BitConverter.GetBytes(MyRov.ServoData.FinRight_Thrash_EndingPosition));
                        List_TxBuffer.AddRange(BitConverter.GetBytes(MyRov.ServoData.FinRight_Thrash_Down_EachCCR));                    
                        List_TxBuffer.AddRange(BitConverter.GetBytes(MyRov.ServoData.FinRight_Thrash_Down_DelayTime));
                        List_TxBuffer.AddRange(BitConverter.GetBytes(MyRov.ServoData.FinRight_Thrash_Up_EachCCR));                       
                        List_TxBuffer.AddRange(BitConverter.GetBytes(MyRov.ServoData.FinRight_Thrash_Up_DelayTime));

                        List_TxBuffer.AddRange(BitConverter.GetBytes(MyRov.ServoData.Camera_Position));
                        break;
                    }
                case (TX_StartBit_PID):
                    {
                        List_TxBuffer.AddRange(BitConverter.GetBytes(MyRov.pidData_Depth.Kp));
                        List_TxBuffer.AddRange(BitConverter.GetBytes(MyRov.pidData_Depth.Ki));
                        List_TxBuffer.AddRange(BitConverter.GetBytes(MyRov.pidData_Depth.Kd));
                        List_TxBuffer.AddRange(BitConverter.GetBytes(MyRov.pidData_Depth.Target));

                        List_TxBuffer.AddRange(BitConverter.GetBytes(MyRov.pidData_Pitch.Kp));
                        List_TxBuffer.AddRange(BitConverter.GetBytes(MyRov.pidData_Pitch.Ki));
                        List_TxBuffer.AddRange(BitConverter.GetBytes(MyRov.pidData_Pitch.Kd));
                        List_TxBuffer.AddRange(BitConverter.GetBytes(MyRov.pidData_Pitch.Target));

                        List_TxBuffer.AddRange(BitConverter.GetBytes(MyRov.pidData_Yaw.Kp));
                        List_TxBuffer.AddRange(BitConverter.GetBytes(MyRov.pidData_Yaw.Ki));
                        List_TxBuffer.AddRange(BitConverter.GetBytes(MyRov.pidData_Yaw.Kd));
                        List_TxBuffer.AddRange(BitConverter.GetBytes(MyRov.pidData_Yaw.Target));

                        List_TxBuffer.AddRange(BitConverter.GetBytes(MyRov.pidData_AccelerationY.Kp));
                        List_TxBuffer.AddRange(BitConverter.GetBytes(MyRov.pidData_AccelerationY.Ki));
                        List_TxBuffer.AddRange(BitConverter.GetBytes(MyRov.pidData_AccelerationY.Kd));
                        List_TxBuffer.AddRange(BitConverter.GetBytes(MyRov.pidData_AccelerationY.Target));
                        break;
                    }
            }

            for (int i = 0; i < List_TxBuffer.Count; i++)
            {
                CheckBit_TX ^= List_TxBuffer[i];
            }
            List_TxBuffer.Add(CheckBit_TX);
            byte[] TxBuffer = List_TxBuffer.ToArray();
            return TxBuffer;
        }

    }
}
