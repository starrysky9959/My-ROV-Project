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

namespace ROV_Test
{
    public partial class Servo参数 : Form
    {
        public Servo参数()
        {
            InitializeComponent();
        }

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
        /// 读档，数据初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Servo参数_Shown(object sender, EventArgs e)
        {
            //读档
            Txt_FinTail_Front_StartingPosition.Text = ReadIni("舵机参数—尾部舵机(前)", "起始位置", "0");
            Txt_FinTail_Front_EndingPosition.Text   = ReadIni("舵机参数—尾部舵机(前)", "终止位置", "0");
            Txt_FinTail_Front_EachCCR.Text          = ReadIni("舵机参数—尾部舵机(前)", "每次改变的占空比", "100");            
            Txt_FinTail_Front_DelayTime.Text        = ReadIni("舵机参数—尾部舵机(前)", "延时长度", "20");

            Txt_FinTail_Rear_StartingPosition.Text = ReadIni("舵机参数—尾部舵机(后)", "起始位置", "0");
            Txt_FinTail_Rear_EndingPosition.Text   = ReadIni("舵机参数—尾部舵机(后)", "终止位置", "0");
            Txt_FinTail_Rear_EachCCR.Text          = ReadIni("舵机参数—尾部舵机(后)", "每次改变的占空比", "100");
            Txt_FinTail_Rear_DelayTime.Text        = ReadIni("舵机参数—尾部舵机(后)", "延时长度", "20");

            Txt_Camera_Position.Text = ReadIni("舵机参数—摄像机云台舵机", "终止位置", "0");

            Txt_Stepper_Pulse.Text = ReadIni("步进电机参数", "脉冲数 ", "0");
        }



        /// <summary>
        /// 保存数据并发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Preservation_Click(object sender, EventArgs e)
        {
          
            //存档
            WriteIni("舵机参数—尾部舵机(前)", "起始位置", Txt_FinTail_Front_StartingPosition.Text);
            WriteIni("舵机参数—尾部舵机(前)", "终止位置", Txt_FinTail_Front_EndingPosition.Text);
            WriteIni("舵机参数—尾部舵机(前)", "每次改变的占空比", Txt_FinTail_Front_EachCCR.Text);
            WriteIni("舵机参数—尾部舵机(前)", "延时长度", Txt_FinTail_Front_DelayTime.Text);
            MyRov.ServoData.FinTail_Front_StartingPosition = Convert.ToUInt16(Txt_FinTail_Front_StartingPosition.Text);
            MyRov.ServoData.FinTail_Front_EndingPosition   = Convert.ToUInt16(Txt_FinTail_Front_EndingPosition.Text);
            MyRov.ServoData.FinTail_Front_EachCCR          = Convert.ToUInt16(Txt_FinTail_Front_EachCCR.Text);
            MyRov.ServoData.FinTail_Front_DelayTime        = Convert.ToUInt16(Txt_FinTail_Front_DelayTime.Text);

            WriteIni("舵机参数—尾部舵机(后)", "起始位置", Txt_FinTail_Rear_StartingPosition.Text);
            WriteIni("舵机参数—尾部舵机(后)", "终止位置", Txt_FinTail_Rear_EndingPosition.Text);
            WriteIni("舵机参数—尾部舵机(后)", "每次改变的占空比", Txt_FinTail_Rear_EachCCR.Text);
            WriteIni("舵机参数—尾部舵机(后)", "延时长度", Txt_FinTail_Rear_DelayTime.Text);
            MyRov.ServoData.FinTail_Rear_StartingPosition = Convert.ToUInt16(Txt_FinTail_Rear_StartingPosition.Text);
            MyRov.ServoData.FinTail_Rear_EndingPosition   = Convert.ToUInt16(Txt_FinTail_Rear_EndingPosition.Text);
            MyRov.ServoData.FinTail_Rear_EachCCR          = Convert.ToUInt16(Txt_FinTail_Rear_EachCCR.Text);
            MyRov.ServoData.FinTail_Rear_DelayTime        = Convert.ToUInt16(Txt_FinTail_Rear_DelayTime.Text);

            WriteIni("舵机参数—摄像机云台舵机", "终止位置 ", Txt_Camera_Position.Text);
            MyRov.ServoData.Camera_Position = Convert.ToUInt16(Txt_Camera_Position.Text);
          
            WriteIni("步进电机参数", "脉冲数 ", Txt_Stepper_Pulse.Text);
            MyRov.ServoData.Pulse_Num = Convert.ToUInt16(Txt_Stepper_Pulse.Text);

            for (int i = 0; i < 7; i++) SendCommand(TX_StartBit_SERVO, MyRov);
        }



        /// <summary>
        /// 按取消键，不进行任何操作，关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Servo参数_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        private void Btn_Reset_Click(object sender, EventArgs e)
        {
            WriteIni("步进电机参数", "脉冲数 ", "25000");
            MyRov.ServoData.Pulse_Num = 25000;
            Txt_Stepper_Pulse.Text = "25000";
            for (int i = 0; i < 7; i++) SendCommand(TX_StartBit_SERVO, MyRov);
        }
    }
}