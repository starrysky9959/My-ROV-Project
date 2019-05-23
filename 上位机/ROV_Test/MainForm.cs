using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.IO.Ports;
using Microsoft.Win32;
using System.Runtime.InteropServices;
//using SpeechLib;
using System.Threading;
using static ROV_Test.Data_TX_RX;
using static ROV_Test.Data;
using static ROV_Test.MessageBoxHandler;
namespace ROV_Test
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 主函数
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            Camera_Init.Owner = this;
            //禁止主窗体对跨线程调用检查  为了能在其他线程调用本线程的控件
            CheckForIllegalCrossThreadCalls = false;
        }

        //实例化一个SerialPort




        #region 读写INI文件部分
        /// <summary>
        /// 声明写入INI文件的API函数 
        /// </summary>
        /// <param name="section">INI文件中的一个字段名，可以有很多个</param>
        /// <param name="key">section下的一个键名，也就是里面具体的变量名</param>
        /// <param name="val">键值,也就是数据</param>
        /// <param name="filePath">INI文件的路径</param>
        /// <returns></returns>
        [DllImport("kernel32")]
        private static extern bool WritePrivateProfileString(string section, string key, string val, string filePath);

        /// <summary>
        /// 声明读取INI文件的API函数 
        /// </summary>
        /// <param name="section">INI文件中的一个字段名，可以有很多个</param>
        /// <param name="key">section下的一个键名，也就是里面具体的变量名</param>
        /// <param name="def">如果retVal为空,则把个变量赋给retVal</param>
        /// <param name="retVal">存放键值的指针变量,用于接收INI文件中键值(数据)的接收缓冲区</param>
        /// <param name="size">retVal的缓冲区大小</param>
        /// <param name="filePath">INI文件的路径</param>
        /// <returns></returns>
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, byte[] retVal, int size, string filePath);

        //设置读写文件的路径
        static string FileName = Application.StartupPath + "\\Config.ini";

        /// <summary>
        /// 读取存档（string类型）
        /// </summary>
        /// <param name="Section">INI文件中的字段名</param>
        /// <param name="Ident">Section下一个键名，即具体的变量名</param>
        /// <param name="Default">如果为空的返回值</param>
        /// <returns></returns>
        public string ReadIni_string(string Section, string Ident, string Default)
        {
            Byte[] Buffer = new Byte[65535];
            int bufLen = GetPrivateProfileString(Section, Ident, Default, Buffer, Buffer.GetUpperBound(0), FileName);
            string s = Encoding.GetEncoding(0).GetString(Buffer);
            s = s.Substring(0, bufLen);
            return s.Trim();
        }


        /// <summary>
        /// 更新存档
        /// </summary>
        /// <param name="Section">INI文件中的字段名</param>
        /// <param name="Ident">Section下一个键名，即具体的变量名</param>
        /// <param name="Value">键值,也就是数据</param>
        public void WriteIni(string Section, string Ident, string Value)
        {
            if (!WritePrivateProfileString(Section, Ident, Value, FileName))
            {
                throw (new ApplicationException("写入配置文件出错"));
            }
        }
        #endregion



        //public MainForm Mycontrol = new MainForm();
        /// <summary>
        /// 主函数初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            string[] portList = SerialPort.GetPortNames();
            if (portList.Length > 0)
            {
                ComDevice.PortName = portList[0];
            }
            ComDevice.BaudRate = 115200;
            ComDevice.Parity = Parity.None;
            ComDevice.DataBits = 8;
            ComDevice.StopBits = StopBits.One;
            Lab_Flag.BackColor = Color.Red;
            //绑定事件
            ComDevice.DataReceived += new SerialDataReceivedEventHandler(Com_DataReceived);
            //MyRov.ServoData.FinLeft_Attitude_Position = 50;

            Timer_UpdateData.Start();   //数据更新定时器使能
            //初始化为自由操控模式
            RadBtn_FreeMode.Checked = true;
            MyRov.Mode.ControlMode = 0;
            IsWorking = true;
            

        }

        //窗体实例化
        网络摄像头 Camera_Init = new 网络摄像头();
        PID系数 PID_Parameter = new PID系数();

        /// <summary>
        /// 在文本框显示消息
        /// </summary>
        /// <param name="message">待输出的消息内容</param>
        void ShowMsg(string message)
        {
            Txt_Info.AppendText(message+"\r\n");
        }


        private DateTime TimeStart = DateTime.Now;  //用于显示当前系统时间
        /// <summary>
        /// 数据更新   20Hz
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayRefresh(object sender, EventArgs e)
        {

            Lab_Time.Text = DateTime.Now.ToLongTimeString() + "\r\n";//系统时间

            //SetProcessValue_Depth((Int16)MyRov.MS5837Data.Depth);
            //SetProcessValue_Pressure((Int16)MyRov.MS5837Data.Pressure);
            Lab_Val_Temperature.Text = MyRov.MS5837Data.Temperature.ToString();

            Lab_Val_AccelerationX.Text = MyRov.JY901Data.AccelerationX.ToString();//X轴加速度
            Lab_Val_AccelerationY.Text = MyRov.JY901Data.AccelerationY.ToString();//Y轴加速度
            Lab_Val_AccelerationZ.Text = MyRov.JY901Data.AccelerationZ.ToString();//Z轴加速度

            Hud.pitch = MyRov.JY901Data.PitchAngle;
            Hud.SSA   = MyRov.JY901Data.YawAngle;
            Hud.roll  = MyRov.JY901Data.RollAngle;

            Lab_Val_AngleSpeedX.Text = MyRov.JY901Data.AngleSpeedX.ToString();//X轴角速度
            Lab_Val_AngleSpeedY.Text = MyRov.JY901Data.AngleSpeedX.ToString();//Y轴角速度
            Lab_Val_AngleSpeedZ.Text = MyRov.JY901Data.AngleSpeedX.ToString();//Z轴角速度

            // ShowMsg(MyRov.MS5837Data.Depth.ToString());
            //ShowMsg(MyRov.MS5837Data.Pressure.ToString());
            //ShowMsg(MyRov.MS5837Data.Temperature.ToString());
        }


    #region Socket部分（暂时不用）
        ////创建一个Socket
        //Socket socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        ////创建一个新线程
        //Thread th;

        ///// <summary>
        ///// 与客户端连接
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void Btn_Connect_Click(object sender, EventArgs e)
        //{
        //    if (Btn_Connect.Text == "连接")
        //    {
        //        //把ip地址字符串转换为IPAddress类型的实例
        //        IPAddress ipAddr = IPAddress.Parse(PC_IpAddress.ToString());
        //        //用指定的端口和ip初始化IPEndPoint类的新实例
        //        IPEndPoint ipe = new IPEndPoint(ipAddr, Convert.ToInt32(Port.ToString()));
        //        //创建socket并开始监听
        //        socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //        //连接到服务器
        //        try
        //        {
        //            socketWatch.Connect(ipe);
        //        }
        //        catch (Exception ex)
        //        {
        //            ShowMsg(ex.Message);
        //        }

        //        ShowMsg("连接成功！");
        //        //开启一个新线程，接收各传感器数据，后台执行
        //        th = new Thread(ReceiveData);
        //        th.IsBackground = true;
        //        th.Start();
        //    }
        //    else if (Btn_Connect.Text=="断开")
        //    {
        //        //终止线程
        //        th.Abort();
        //        socketWatch.Close();
        //        Btn_Connect.Text = "连接";
        //    }
        //}

        ///// <summary>
        ///// 接收数据并更新
        ///// </summary>
        ///// <param name="buffer">接收数据的数组</param>
        ///// <param name="n">将数据读入缓冲区</param>
        ///// <param name="CheckBit">数据校验位</param>
        ///// <param name="i">循环控制量</param>
        //void ReceiveData()
        //{
        //    try
        //    {
        //        //定义用于接收数据的byte数组buffer
        //        byte[] buffer = new byte[100];
        //        //将数据读入缓冲区
        //        int n = socketWatch.Receive(buffer, 21, 0);
        //        //数据校验位
        //        byte CheckBit = 0X77;
        //        //和前20位数据异或，进行数据校验
        //        for (int i = 0; i < 20; i++)
        //        {
        //            CheckBit ^= buffer[i];
        //        }
        //        //数据类型位=1，数据长度位=21，校验位相同，数据合法
        //        if ((buffer[0] == 1) && (buffer[1] == 21) && (buffer[20] == CheckBit))
        //        {
        //            //传感器参数结构体数据更新
        //            SensorData.Pressure = BitConverter.ToInt16(buffer, 2);
        //            SensorData.Depth = BitConverter.ToInt16(buffer, 4);
        //            SensorData.Temperature = BitConverter.ToInt16(buffer, 6);
        //            SensorData.PitchAngle = BitConverter.ToInt16(buffer, 8);
        //            SensorData.YawAngle = BitConverter.ToInt16(buffer, 10);
        //            SensorData.RollAngle = BitConverter.ToInt16(buffer, 12);
        //            SensorData.AngleSpeedX = BitConverter.ToInt16(buffer, 14);
        //            SensorData.AngleSpeedX = BitConverter.ToInt16(buffer, 16);
        //            SensorData.AngleSpeedX = BitConverter.ToInt16(buffer, 18);
        //            //UI界面数据更新
        //            Lab_Val_Pressure.Text = SensorData.Pressure.ToString();
        //            Lab_Val_Depth.Text = SensorData.Depth.ToString();
        //            Lab_Val_Temperature.Text = SensorData.Temperature.ToString();
        //            //Lab_Val_PitchAngle.Text = SensorData.PitchAngle.ToString();
        //            Hud.pitch = SensorData.PitchAngle;
        //            //Lab_Val_YawAngle.Text = SensorData.YawAngle.ToString();
        //            Hud.SSA = SensorData.YawAngle;
        //            //Lab_Val_RollAngle.Text = SensorData.RollAngle.ToString();
        //            Hud.roll = SensorData.RollAngle;
        //            Lab_Val_AngleSpeedX.Text = SensorData.AngleSpeedX.ToString();
        //            Lab_Val_AngleSpeedY.Text = SensorData.AngleSpeedX.ToString();
        //            Lab_Val_AngleSpeedZ.Text = SensorData.AngleSpeedX.ToString();
        //            Hsi.Heading = SensorData.YawAngle;
        //            ShowMsg("传感器数据更新成功！");
        //        }
        //    }
        //    catch(Exception e)
        //    {
        //        ShowMsg(e.Message);
        //    }
        //}
        #endregion


    #region 串口部分代码

        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Open_Click(object sender, EventArgs e)
        {
            if (ComDevice.IsOpen == false)
            {
                try
                {
                    string[] portList = SerialPort.GetPortNames();
                    if (portList.Length > 0)
                    {
                        ComDevice.PortName = portList[0];
                    }
                    ComDevice.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                Btn_Open.Text = "关闭串口";
                Lab_Flag.BackColor = Color.Green;   //标志显示绿色，表示串口已成功打开
            }
            else
            {
                try
                {
                    ComDevice.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Btn_Open.Text = "打开串口";
                Lab_Flag.BackColor = Color.Red;     //标识显示红色，表示串口未打开
            }
        }

        /// <summary>
        /// 串口接收中断处理函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (ComDevice.IsOpen)
            {
                try
                {
                    //ShowMsg("接收成功");
                    int Rx_Length = ComDevice.BytesToRead;//要接收的数据长度
                    byte[] RxBuffer = new byte[Rx_Length];//接收数据数组
                    ComDevice.Read(RxBuffer, 0, Rx_Length);
                    for (int i = 0; i < Rx_Length; i++)
                    {
                        ReceiveAndCheck(RxBuffer[i]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        #endregion



        /// <summary>
        /// 菜单打开网络摄像头设置界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 视频传输设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Camera_Init.Show();
        }


        /// <summary>
        /// 菜单打开PID系数设置界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PID系数设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PID_Parameter.Show();
        }


        /// <summary>
        /// 打开舵机参数设置界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Servo_Click(object sender, EventArgs e)
        {
            Servo参数 Servo_Parameter = new Servo参数();
            Servo_Parameter.Show();
        }

        /// <summary>
        /// 发送鱼体启动指令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Start_Click(object sender, EventArgs e)
        {
            if (ComDevice.IsOpen)
            {
                try
                {
                    MyRov.ServoData.FinLeft_Attitude_Position = 100;

                    //MyRov.ServoData.FinLeft_Thrash_StartingPosition = 120;
                    //MyRov.ServoData.FinLeft_Thrash_EndingPosition = 230;
                    //MyRov.ServoData.FinLeft_Thrash_Down_EachCCR = 2;
                    //MyRov.ServoData.FinLeft_Thrash_Down_DelayTime = 5;
                    
                    //MyRov.ServoData.FinLeft_Thrash_Up_EachCCR = 5;
                    //MyRov.ServoData.FinLeft_Thrash_Up_DelayTime = 15;

                    SendCommand(TX_StartBit_SERVO, MyRov);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("串口未打开");
            }
        }

        

    #region 更新进度条百分比数据显示部分

        /// <summary>
        /// 实现深度进度条的百分比显示
        /// </summary>
        /// <param name="value">百分比数值</param>
        public void SetProcessValue_Depth(int value)
        {
            string str = value.ToString() + "cm";
            Font font = new Font("Times New Roman", (float)11, FontStyle.Regular);
            PointF pt = new PointF(this.VertProgressBar_Depth.Width / 2 - 10, this.VertProgressBar_Depth.Height / 2 - 10);
            this.VertProgressBar_Depth.CreateGraphics().DrawString(str, font, Brushes.Red, pt);
            this.VertProgressBar_Depth.Value = value;
        }


        /// <summary>
        /// 实现压力进度条的百分比显示
        /// </summary>
        /// <param name="value">百分比数值</param>
        public void SetProcessValue_Pressure(int value)
        {
            string str = value.ToString() + "pa";
            Font font = new Font("Times New Roman", (float)11, FontStyle.Regular);
            PointF pt = new PointF(this.VertProgressBar_Pressure.Width / 2 - 10, this.VertProgressBar_Pressure.Height / 2 - 10);
            this.VertProgressBar_Pressure.CreateGraphics().DrawString(str, font, Brushes.Red, pt);
            this.VertProgressBar_Pressure.Value = value;
        }
        #endregion







#region 控制模式选择

        /// <summary>
        /// 选择自由操控模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadBtn_FreeMode_CheckedChanged(object sender, EventArgs e)
        {
            Lab_ControlMode.Text = "你选择了自由操控模式";
            MyRov.Mode.ControlMode = 0;
            SendCommand(TX_StartBit_MODE, MyRov);
        }


        /// <summary>
        /// 选择PID闭环控制模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadBtn_PIDMode_CheckedChanged(object sender, EventArgs e)
        {
            Lab_ControlMode.Text = "你选择了PID闭环控制模式";
            MyRov.Mode.ControlMode = 1;
            SendCommand(TX_StartBit_MODE, MyRov);
        }


#endregion




#region 键盘控制部分
        /// <summary>
        /// 按下键盘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (MyRov.Mode.ControlMode == 0)
            {
                switch (e.KeyCode)
                {
                    case (Keys.W):
                        {
                            Btn_KeyPressW.BackColor = Color.Red;
                            break;
                        }
                    case (Keys.A):
                        {
                            Btn_KeyPressA.BackColor = Color.Red;
                            break;
                        }
                    case (Keys.S):
                        {
                            Btn_KeyPressS.BackColor = Color.Red;
                            break;
                        }
                    case (Keys.D):
                        {
                            Btn_KeyPressD.BackColor = Color.Red;
                            break;
                        }
                }
            }
            else
            {
                MessageBox.Show("当前非自由操控模式，禁用键盘！！！");
            }
        }


        /// <summary>
        /// 松开键盘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {         
            if (MyRov.Mode.ControlMode == 0)
            {
                switch (e.KeyCode)
                {
                    case (Keys.W):
                        {
                            Btn_KeyPressW.BackColor = Color.White;
                            break;
                        }
                    case (Keys.A):
                        {
                            Btn_KeyPressA.BackColor = Color.White;
                            break;
                        }
                    case (Keys.S):
                        {
                            Btn_KeyPressS.BackColor = Color.White;
                            break;
                        }
                    case (Keys.D):
                        {
                            Btn_KeyPressD.BackColor = Color.White;
                            break;
                        }
                }
            }
            else
            {
                MessageBox.Show("当前非自由操控模式，禁用键盘！！！");
            }
        }


        #endregion

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
            if (Camera_Init.Isopen == 1)
            {
                Camera_Init.th.Abort();
            }
        }


        /// <summary>
        /// 停止命令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Stop_Click(object sender, EventArgs e)
        {
            if (ComDevice.IsOpen)
            {
                try
                {
                    MyRov.ServoData.FinTail_Advance_StartingPosition = 100;
                    MyRov.ServoData.FinTail_Advance_EndingPosition = 100;

                    //MyRov.ServoData.FinLeft_Thrash_StartingPosition = 120;
                    //MyRov.ServoData.FinLeft_Thrash_EndingPosition = 230;
                    //MyRov.ServoData.FinLeft_Thrash_Down_EachCCR = 2;
                    //MyRov.ServoData.FinLeft_Thrash_Down_DelayTime = 5;
                    
                    //MyRov.ServoData.FinLeft_Thrash_Up_EachCCR = 5;
                    //MyRov.ServoData.FinLeft_Thrash_Up_DelayTime = 15;

                    SendCommand(TX_StartBit_SERVO, MyRov);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("串口未打开");
            }
        }
    }





    public static class Data
    {
        public static ROVDatabase MyRov = new ROVDatabase();
        public static SerialPort ComDevice = new SerialPort();
        /// <summary>
        /// 向下位机发送指令
        /// </summary>
        /// <param name="startbit">起始位</param>
        /// <param name="MyRov">参数结构体</param>
        public static void SendCommand(byte startbit, ROVDatabase MyRov)
        {
            byte[] TXData = DataTX_Handler(startbit, MyRov);

            if (ComDevice.IsOpen)
            {
                try
                {
                    ComDevice.Write(TXData, 0, TXData.Length);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
    }
}
