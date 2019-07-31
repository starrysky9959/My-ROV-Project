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
using OpenCvSharp.Extensions;
using OpenCvSharp;
using OpenCvSharp.Tracking;
using static ROV_Test.Data_TX_RX;
using static ROV_Test.Data;
using static ROV_Test.MessageBoxHandler;
namespace ROV_Test
{
    public partial class MainForm : Form
    {


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
        /// 读取存档
        /// </summary>
        /// <param name="Section">INI文件中的字段名</param>
        /// <param name="Ident">Section下一个键名，即具体的变量名</param>
        /// <param name="Default">如果为空的返回值</param>
        /// <returns></returns>
        public string ReadIni(string Section, string Ident, string Default)
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


        public int current_pos = 0;
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

            Timer_UpdateData.Start();   //数据更新定时器使能
            //初始化为自由操控模式
            RadBtn_FreeMode.Checked = true;
            MyRov.Mode.ControlMode = 0;
            IsWorking = true;
            Path = "rtsp://" + UserName + ":" + Password + "@" + IPAddress + "/Streaming/Channels/0"; //设置图传路径
        }


        /// <summary>
        /// 预加载时读取存档
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Shown(object sender, EventArgs e)
        {
            MyRov.ServoData.FinTail_Front_StartingPosition = Convert.ToUInt16(ReadIni("舵机参数—尾部舵机(前)", "起始位置", "0"));
            MyRov.ServoData.FinTail_Front_EndingPosition   = Convert.ToUInt16(ReadIni("舵机参数—尾部舵机(前)", "终止位置", "0"));
            MyRov.ServoData.FinTail_Front_EachCCR          = Convert.ToUInt16(ReadIni("舵机参数—尾部舵机(前)", "每次改变的占空比", "100"));
            MyRov.ServoData.FinTail_Front_DelayTime        = Convert.ToUInt16(ReadIni("舵机参数—尾部舵机(前)", "延时长度", "50"));

            MyRov.ServoData.FinTail_Rear_StartingPosition = Convert.ToUInt16(ReadIni("舵机参数—尾部舵机(后)", "起始位置", "0"));
            MyRov.ServoData.FinTail_Rear_EndingPosition   = Convert.ToUInt16(ReadIni("舵机参数—尾部舵机(后)", "终止位置", "0"));
            MyRov.ServoData.FinTail_Rear_EachCCR          = Convert.ToUInt16(ReadIni("舵机参数—尾部舵机(后)", "每次改变的占空比", "100"));
            MyRov.ServoData.FinTail_Rear_DelayTime        = Convert.ToUInt16(ReadIni("舵机参数—尾部舵机(后)", "延时长度", "50"));

            //MyRov.ServoData.FinLeft_Attitude_Position        = Convert.ToUInt16(ReadIni("舵机参数—左侧鱼鳍姿态舵机", "终止位置", "0"));

            //MyRov.ServoData.FinLeft_Thrash_StartingPosition  = Convert.ToUInt16(ReadIni("舵机参数—左侧鱼鳍划水舵机", "起始位置", "0"));
            //MyRov.ServoData.FinLeft_Thrash_EndingPosition    = Convert.ToUInt16(ReadIni("舵机参数—左侧鱼鳍划水舵机", "终止位置", "0"));
            //MyRov.ServoData.FinLeft_Thrash_Down_EachCCR      = Convert.ToUInt16(ReadIni("舵机参数—左侧鱼鳍划水舵机", "向下拍水时 每次改变的占空比", "100"));
            //MyRov.ServoData.FinLeft_Thrash_Down_DelayTime    = Convert.ToUInt16(ReadIni("舵机参数—左侧鱼鳍划水舵机", "向下拍水时 延时长度", "0"));
            //MyRov.ServoData.FinLeft_Thrash_Up_EachCCR        = Convert.ToUInt16(ReadIni("舵机参数—左侧鱼鳍划水舵机", "向上拍水时 每次改变的占空比", "100"));
            //MyRov.ServoData.FinLeft_Thrash_Up_DelayTime      = Convert.ToUInt16(ReadIni("舵机参数—左侧鱼鳍划水舵机", "向上拍水时 延时长度", "0"));

            //MyRov.ServoData.FinRight_Attitude_Position       = Convert.ToUInt16(ReadIni("舵机参数—右侧鱼鳍姿态舵机", "终止位置", "0"));

            //MyRov.ServoData.FinRight_Thrash_StartingPosition = Convert.ToUInt16(ReadIni("舵机参数—右侧鱼鳍划水舵机", "起始位置", "0"));
            //MyRov.ServoData.FinRight_Thrash_EndingPosition   = Convert.ToUInt16(ReadIni("舵机参数—右侧鱼鳍划水舵机", "终止位置", "0"));
            //MyRov.ServoData.FinRight_Thrash_Down_EachCCR     = Convert.ToUInt16(ReadIni("舵机参数—右侧鱼鳍划水舵机", "向下拍水时 每次改变的占空比", "100"));
            //MyRov.ServoData.FinRight_Thrash_Down_DelayTime   = Convert.ToUInt16(ReadIni("舵机参数—右侧鱼鳍划水舵机", "向下拍水时 延时长度", "0"));
            //MyRov.ServoData.FinRight_Thrash_Up_EachCCR       = Convert.ToUInt16(ReadIni("舵机参数—右侧鱼鳍划水舵机", "向上拍水时 每次改变的占空比", "100"));
            //MyRov.ServoData.FinRight_Thrash_Up_DelayTime     = Convert.ToUInt16(ReadIni("舵机参数—右侧鱼鳍划水舵机", "向上拍水时 延时长度", "0"));

            MyRov.ServoData.Camera_Position = Convert.ToUInt16(ReadIni("舵机参数—摄像机云台舵机", "终止位置", "0"));
            MyRov.ServoData.Pulse_Num = Convert.ToUInt16(ReadIni("步进电机参数", "脉冲数 ", "0"));
        }



        //窗体实例化
        网络摄像头 Camera_Init = new 网络摄像头();



        /// <summary>
        /// 在文本框显示消息
        /// </summary>
        /// <param name="message">待输出的消息内容</param>
        void ShowMsg(string message)
        {
            Txt_Info.AppendText(message+"\r\n");
        }



        #region 后台子线程发送指令
        //创建一个子线程
        public Thread COMMAND;

        /// <summary>
        /// 在子线程中发送指令
        /// </summary>
        /// <param name="o"></param>
        public void Send_CommandLoop()
        {
            while (b)
            {                
                SendCommand(TX_StartBit_MODE, MyRov);               
                SendCommand(TX_StartBit_SERVO, MyRov);
                SendCommand(TX_StartBit_SERVO, MyRov);
                SendCommand(TX_StartBit_SERVO, MyRov);
                SendCommand(TX_StartBit_SERVO, MyRov);
                SendCommand(TX_StartBit_SERVO, MyRov);
                SendCommand(TX_StartBit_SERVO, MyRov);
                SendCommand(TX_StartBit_PID, MyRov);
                Delay(160); 
            }
        }
        //Delay function
        public static void Delay(int milliSecond)
        {
            int start = Environment.TickCount;
            while (Math.Abs(Environment.TickCount - start) < milliSecond)
            {
                Application.DoEvents();
            }
        }
        bool b = false;
        private void Btn_Send_Click(object sender, EventArgs e)
        {
            if (b==false)
            {
                b = true;
                Btn_Send.Text = "停止";
                //新开一个后台线程，启动
                COMMAND = new Thread(Send_CommandLoop);
                COMMAND.IsBackground = true;
                COMMAND.Start();                
            }
            else
            {
                b = false;
                Btn_Send.Text = "传输";
            }
        }
#endregion



        /// <summary>
        /// 数据更新   20Hz
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayRefresh(object sender, EventArgs e)
        {
            SetProcessValue_Depth((Int16)MyRov.MS5837Data.Depth);
            SetProcessValue_Pressure((Int16)MyRov.MS5837Data.Pressure);
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

            ShowMsg(MyRov.MS5837Data.Depth.ToString() + "      " + MyRov.MS5837Data.Pressure.ToString() + "      " + MyRov.MS5837Data.Temperature.ToString());

        }



        #region 摄像头与对象追踪

        //摄像头获取图像相关
        public string Path = "";
        Mat src = new Mat();                            //源mat
        public Thread th;
        public UInt16 Isopen = 0;
        public string UserName = "admin";
        public string Password = "123456";
        public string IPAddress = "169.254.200.254";

        //对象追踪相关
        int ptX = 150;                                  //目标左上角在画面中的坐标
        int ptY = 150;
        int bboxSize = 150;                             //选择框大小
        int tgtSize = 150;                              //跟踪目标大小
        int videoW = 640;                               //视频尺寸
        int videoH = 480;
        System.Drawing.Point target = new System.Drawing.Point();   //目标中心坐标
        Mat roi = new Mat(100, 100, new MatType());     //roi
        Rect2d bbox;                                    //选择框
        Rect2d tgt;                                     //跟踪框
        Rect _bbox;
        Rect _tgt;
        bool trackStatus = false;                       //在不在跟踪
        bool cal = false;                               //在不在解算
        TrackerMOSSE Tracker;                           //追踪算法


        /// <summary>
        /// 更新跟踪目标
        /// </summary>
        public void updateTracker()             
        {
            while (cal) ;                           //等
            tgt = bbox;                             //设置跟踪框
            if (Tracker != null) Tracker.Dispose();  //毙了之前的进程
            GC.Collect();                           //资源回收
            Tracker = TrackerMOSSE.Create();        //设置新的跟踪进程
            Tracker.Init(src, tgt);                 //初始化
        }



        /// <summary>
        /// 鼠标点击图像 开始新的跟踪
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PicBox_Video_MouseClick(object sender, MouseEventArgs e)
        {
            updateTracker();
        }



        /// <summary>
        /// 鼠标左键设置跟踪目标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PicBox_Video_MouseMove(object sender, MouseEventArgs e)
        {
            ptX = e.X * 5 / 2;
            ptY = e.Y * 5 / 2;
            ptX = ptX > (bboxSize / 2) ? (ptX - (bboxSize / 2)) : 0;
            ptY = ptY > (bboxSize / 2) ? (ptY - (bboxSize / 2)) : 0;
            ptX = (ptX + bboxSize) > src.Cols ? (src.Cols - bboxSize) : ptX;
            ptY = (ptY + bboxSize) > src.Rows ? (src.Rows - bboxSize) : ptY;
        }



        /// <summary>       
        /// 鼠标滚轮改变跟踪框尺寸       
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PicBox_Video_MouseWheel(object sender, MouseEventArgs e)          //
        {
            if (e.Delta > 0)
            {
                bboxSize = bboxSize < 200 ? (bboxSize + 5) : 200;
            }
            if (e.Delta < 0)
            {
                bboxSize = bboxSize > 50 ? (bboxSize - 5) : 50;
            }
        }


        /// <summary>
        /// 获取图像
        /// </summary>
        public void Cap_Run(object o)
        {
            VideoCapture cap = new VideoCapture(Path);
            cap.Read(src);
            double timer = 0;
            double fps = 0;
            while (true)
            {
                cal = true;
                fps = Cv2.GetTickFrequency() / (Cv2.GetTickCount() - timer);
                timer = Cv2.GetTickCount();
                cap.Read(src);                                          //读画面和参数
                bbox = new Rect2d(ptX, ptY, bboxSize, bboxSize);        //更新选择框
                if (Tracker != null && !Tracker.IsDisposed)             //在跟踪？
                {
                    trackStatus = Tracker.Update(src, ref tgt);         //更新跟踪参数
                    _tgt = tgt.ToRect();                                //冗余但懒得改的转换
                    Cv2.Rectangle(src, _tgt, Scalar.Lime, 2);           //画跟踪框
                    Rect roiRect = tgt.ToRect();                        //roi
                    target.X = (int)(2 * tgt.X + tgt.Width) / 2;        //目标坐标
                    target.Y = (int)(2 * tgt.Y + tgt.Height) / 2;
                    tgtSize = (int)tgt.Width;
                    try
                    {
                        Mat _roi = new Mat(src, roiRect);               //roi显示在小窗里，窗被我删了
                        _roi.CopyTo(roi);
                    }
                    catch
                    {
                    }
                }
                _bbox = bbox.ToRect();                                  //冗余但懒得改的转换
                Cv2.Rectangle(src, _bbox, Scalar.Red, 1);               //画选择框
                if (trackStatus)                                        //正在跟踪的画面指示
                {
                    Cv2.Line(src, target.X - tgtSize / 2, target.Y, target.X, target.Y + tgtSize / 2, Scalar.Lime, 2);
                    Cv2.Line(src, target.X, target.Y + tgtSize / 2, target.X + tgtSize / 2, target.Y, Scalar.Lime, 2);
                    Cv2.Line(src, target.X + tgtSize / 2, target.Y, target.X, target.Y - tgtSize / 2, Scalar.Lime, 2);
                    Cv2.Line(src, target.X, target.Y - tgtSize / 2, target.X - tgtSize / 2, target.Y, Scalar.Lime, 2);
                    Cv2.PutText(src, "X:" + target.X.ToString() + "|" + "Y:" + target.Y.ToString(), new OpenCvSharp.Point(tgt.X, tgt.Y - 5),
                    HersheyFonts.HersheyPlain, 3, Scalar.Lime, 3);
                }
                Cv2.PutText(src, "FPS:" + ((int)fps).ToString(), new OpenCvSharp.Point(1, videoH - 9), HersheyFonts.HersheyPlain, 2, Scalar.Black, 2);
                Cv2.PutText(src, "FPS:" + ((int)fps).ToString(), new OpenCvSharp.Point(0, videoH - 10), HersheyFonts.HersheyPlain, 2, Scalar.Lime, 2);
                
                PicBox_Video.Image = BitmapConverter.ToBitmap(src);
                cal = false;
                GC.Collect();
                //Cv2.WaitKey(50);
                if (MyRov.Mode.ControlMode == 2)
                {
                    if (target.X < 600)
                    {
                        TurnLeft();
                    }
                    if (target.X > 1000)
                    {
                        TurnRight();
                    }
                    if (target.Y < 400)
                    {
                        Up();
                    }
                    if (target.Y > 700)
                    {
                        Down();
                    }
                    if (target.X>=600 && target.X<=1000 && target.Y>=400 && target.Y<=700)
                    {
                        Advance();
                    }
                }
            }
            if (Isopen == 0) this.th.Abort();
        }


        /// <summary>
        /// 打开摄像头传输图像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Parameter_Click(object sender, EventArgs e)
        {
            th = new Thread(Cap_Run);
            Isopen = 1;
            th.Start();
            bbox = new Rect2d(0, 0, bboxSize, bboxSize);
        }
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
                    //打开串口
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
            PID系数 PID_Parameter = new PID系数();
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


        #region 动作
        public void TurnLeft()
        {
            MyRov.ServoData.FinTail_Front_StartingPosition = 1900;
            MyRov.ServoData.FinTail_Front_EndingPosition = 1900;
            MyRov.ServoData.FinTail_Front_EachCCR = 50;
            MyRov.ServoData.FinTail_Front_DelayTime = 30;
            for (int i = 0; i < 5; i++) SendCommand(TX_StartBit_SERVO, MyRov);
        }
        public void TurnRight()
        {
            MyRov.ServoData.FinTail_Front_StartingPosition = 1200;
            MyRov.ServoData.FinTail_Front_EndingPosition = 1200;
            MyRov.ServoData.FinTail_Front_EachCCR = 50;
            MyRov.ServoData.FinTail_Front_DelayTime = 30;
            for (int i = 0; i < 5; i++) SendCommand(TX_StartBit_SERVO, MyRov);
        }
        public void Up()
        {
            if (MyRov.ServoData.Pulse_Num <= 15000) return;
            MyRov.ServoData.Pulse_Num -= 800;            
            for (int i = 0; i < 5; i++) SendCommand(TX_StartBit_SERVO, MyRov);
        }
        public void Down()
        {            
            if (MyRov.ServoData.Pulse_Num >= 35000) return;
            MyRov.ServoData.Pulse_Num += 800;
            for (int i = 0; i < 5; i++) SendCommand(TX_StartBit_SERVO, MyRov);
        }
        public void Advance()
        {
            MyRov.ServoData.FinTail_Rear_StartingPosition = 1100;
            MyRov.ServoData.FinTail_Rear_EndingPosition = 1900;
            MyRov.ServoData.FinTail_Rear_EachCCR = 50;
            MyRov.ServoData.FinTail_Rear_DelayTime = 20;
            for (int i = 0; i < 5; i++) SendCommand(TX_StartBit_SERVO, MyRov);
        }
        public void Stop()
        {
            MyRov.ServoData.FinTail_Rear_StartingPosition = 1450;
            MyRov.ServoData.FinTail_Rear_EndingPosition = 1450;
            MyRov.ServoData.FinTail_Rear_EachCCR = 100;
            MyRov.ServoData.FinTail_Rear_DelayTime = 40;
            for (int i = 0; i < 5; i++) SendCommand(TX_StartBit_SERVO, MyRov);
        }

        #endregion



        #region 鱼体特殊指令

        /// <summary>
        /// 启动指令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Start_Click(object sender, EventArgs e)
        {
            if (ComDevice.IsOpen)
            {
                try
                {
                    MyRov.ServoData.FinTail_Front_StartingPosition = 1100;
                    MyRov.ServoData.FinTail_Front_EndingPosition = 1100;
                    MyRov.ServoData.FinTail_Rear_StartingPosition = 1100;
                    MyRov.ServoData.FinTail_Rear_EndingPosition = 1800;
                    MyRov.ServoData.FinTail_Rear_EachCCR = 50;
                    MyRov.ServoData.FinTail_Rear_DelayTime = 20;
                    
                    MyRov.ServoData.Camera_Position = 1000;

                    for (int i = 0; i < 10; i++) SendCommand(TX_StartBit_SERVO, MyRov);
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
                    MyRov.ServoData.FinTail_Front_StartingPosition = 1450;
                    MyRov.ServoData.FinTail_Front_EndingPosition = 1450;
                    MyRov.ServoData.FinTail_Rear_StartingPosition = 1450;
                    MyRov.ServoData.FinTail_Rear_EndingPosition = 1450;
                    MyRov.ServoData.FinTail_Rear_EachCCR = 50;
                    MyRov.ServoData.FinTail_Rear_DelayTime = 20;


                    MyRov.ServoData.Camera_Position = 1000;

                    for (int i = 0; i < 10; i++) SendCommand(TX_StartBit_SERVO, MyRov);
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


        /// <summary>
        /// 左转弯
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_TurnLeft_Click(object sender, EventArgs e)
        {
            if (ComDevice.IsOpen)
            {
                try
                {
                    TurnLeft();
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


        /// <summary>
        /// 右拐弯
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_TurnRight_Click(object sender, EventArgs e)
        {
            if (ComDevice.IsOpen)
            {
                try
                {
                    for (int i = 0; i < 10; i++) SendCommand(TX_StartBit_SERVO, MyRov);
                    Delay(1000);
                    TurnRight();
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
        private void Btn_SpeedLv1_Click(object sender, EventArgs e)
        {
            if (ComDevice.IsOpen)
            {
                try
                {
                    MyRov.ServoData.FinTail_Rear_StartingPosition =1100;
                    MyRov.ServoData.FinTail_Rear_EndingPosition   =1800;
                    MyRov.ServoData.FinTail_Rear_EachCCR          =100;
                    MyRov.ServoData.FinTail_Rear_DelayTime        =20;
                    
                    MyRov.ServoData.Camera_Position = 1000;

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


        /// <summary>
        /// 调整鱼体重心，上浮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Up_Click(object sender, EventArgs e)
        {
            MyRov.ServoData.Pulse_Num = 0;
            for (int i = 0; i < 10; i++) SendCommand(TX_StartBit_SERVO, MyRov);
        }
        #endregion



        #region 摄像头云台升降
        private void Btn_HeadUp_Click(object sender, EventArgs e)
        {
            if (MyRov.ServoData.Camera_Position >= 1800) return;
            MyRov.ServoData.Camera_Position += 100;
            SendCommand(RX_StartBit_SERVO, MyRov);
        }

        private void Btn_HeadDown_Click(object sender, EventArgs e)
        {
            if (MyRov.ServoData.Camera_Position <= 400) return;
            MyRov.ServoData.Camera_Position -= 100;
            SendCommand(RX_StartBit_SERVO, MyRov);
        }
#endregion



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

        private void RadBtn_ObjectTrack_CheckedChanged(object sender, EventArgs e)
        {
            Lab_ControlMode.Text = "你选择了对象追踪模式";
            MyRov.Mode.ControlMode = 2;
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
            if (MyRov.Mode.ControlMode != 1)
            {
                switch (e.KeyCode)
                {
                    case (Keys.W):
                        {
                            Advance();
                            Btn_KeyPressW.BackColor = Color.Red;
                            break;
                        }
                    case (Keys.A):
                        {
                            TurnLeft();                            
                            Btn_KeyPressA.BackColor = Color.Red;
                            break;
                        }
                    case (Keys.S):
                        {
                            Stop();
                            Btn_KeyPressS.BackColor = Color.Red;
                            break;
                        }
                    case (Keys.D):
                        {
                            TurnRight();
                            Btn_KeyPressD.BackColor = Color.Red;
                            break;
                        }
                    case (Keys.Up):
                        {
                            Up();
                            Btn_KeyPressUP.BackColor = Color.Red;
                            break;
                        }
                    case (Keys.Down):
                        {
                            Down();
                            Btn_KeyPressDOWN.BackColor = Color.Red;
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
            if (MyRov.Mode.ControlMode != 1)
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
                    case (Keys.Up):
                        {
                            Btn_KeyPressUP.BackColor = Color.White;
                            break;
                        }
                    case (Keys.Down):
                        {
                            Btn_KeyPressDOWN.BackColor = Color.White;
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

        
        
        /// <summary>
        /// 关闭前结束所以进程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
            //电机复位
            MyRov.ServoData.Pulse_Num = 25000;
            for (int i = 0; i < 10; i++) SendCommand(TX_StartBit_SERVO, MyRov);

            if (Camera_Init.Isopen == 1)
            {
                Camera_Init.th.Abort();
            }
            Camera_Init.Close();
        }

    }




    /// <summary>
    /// 方便其他程序调用 发送接收数据包
    /// </summary>
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
