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
            Txt_FinTail_Advance_StartingPosition.Text = ReadIni("舵机参数—尾部推进舵机", "起始位置", "0");
            Txt_FinTail_Advance_EndingPosition.Text   = ReadIni("舵机参数—尾部推进舵机", "终止位置", "0");
            Txt_FinTail_Advance_EachCCR.Text          = ReadIni("舵机参数—尾部推进舵机", "每次改变的占空比", "100");            
            Txt_FinTail_Advance_DelayTime.Text        = ReadIni("舵机参数—尾部推进舵机", "延时长度", "0");

            Txt_FinLeft_Attitude_Position.Text        = ReadIni("舵机参数—左侧鱼鳍姿态舵机", "终止位置", "0");

            Txt_FinLeft_Thrash_StartingPosition.Text  = ReadIni("舵机参数—左侧鱼鳍划水舵机", "起始位置", "0");
            Txt_FinLeft_Thrash_EndingPosition.Text    = ReadIni("舵机参数—左侧鱼鳍划水舵机", "终止位置", "0");
            Txt_FinLeft_Thrash_Down_EachCCR.Text      = ReadIni("舵机参数—左侧鱼鳍划水舵机", "向下拍水时 每次改变的占空比", "100");          
            Txt_FinLeft_Thrash_Down_DelayTime.Text    = ReadIni("舵机参数—左侧鱼鳍划水舵机", "向下拍水时 延时长度", "0");
            Txt_FinLeft_Thrash_Up_EachCCR.Text        = ReadIni("舵机参数—左侧鱼鳍划水舵机", "向上拍水时 每次改变的占空比", "100");            
            Txt_FinLeft_Thrash_Up_DelayTime.Text      = ReadIni("舵机参数—左侧鱼鳍划水舵机", "向上拍水时 延时长度", "0");

            Txt_FinRight_Attitude_Position.Text       = ReadIni("舵机参数—右侧鱼鳍姿态舵机", "终止位置", "0");

            Txt_FinRight_Thrash_StartingPosition.Text = ReadIni("舵机参数—右侧鱼鳍划水舵机", "起始位置", "0");
            Txt_FinRight_Thrash_EndingPosition.Text   = ReadIni("舵机参数—右侧鱼鳍划水舵机", "终止位置", "0");
            Txt_FinRight_Thrash_Down_EachCCR.Text     = ReadIni("舵机参数—右侧鱼鳍划水舵机", "向下拍水时 每次改变的占空比", "100");            
            Txt_FinRight_Thrash_Down_DelayTime.Text   = ReadIni("舵机参数—右侧鱼鳍划水舵机", "向下拍水时 延时长度", "0");
            Txt_FinRight_Thrash_Up_EachCCR.Text       = ReadIni("舵机参数—右侧鱼鳍划水舵机", "向上拍水时 每次改变的占空比", "100");            
            Txt_FinRight_Thrash_Up_DelayTime.Text     = ReadIni("舵机参数—右侧鱼鳍划水舵机", "向上拍水时 延时长度", "0");

            Txt_Camera_Position.Text = ReadIni("舵机参数—摄像机云台舵机", "终止位置", "0");
            
        }



        /// <summary>
        /// 保存数据并发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Preservation_Click(object sender, EventArgs e)
        {
          
            //存档
            WriteIni("舵机参数—尾部推进舵机", "起始位置", Txt_FinTail_Advance_StartingPosition.Text);
            WriteIni("舵机参数—尾部推进舵机", "终止位置", Txt_FinTail_Advance_EndingPosition.Text);
            WriteIni("舵机参数—尾部推进舵机", "每次改变的占空比", Txt_FinTail_Advance_EachCCR.Text);
            WriteIni("舵机参数—尾部推进舵机", "延时长度", Txt_FinTail_Advance_DelayTime.Text);
            MyRov.ServoData.FinTail_Advance_StartingPosition = Convert.ToUInt16(Txt_FinTail_Advance_StartingPosition.Text);
            MyRov.ServoData.FinTail_Advance_EndingPosition   = Convert.ToUInt16(Txt_FinTail_Advance_EndingPosition.Text);
            MyRov.ServoData.FinTail_Advance_EachCCR          = Convert.ToUInt16(Txt_FinTail_Advance_EachCCR.Text);
            MyRov.ServoData.FinTail_Advance_DelayTime        = Convert.ToUInt16(Txt_FinTail_Advance_DelayTime.Text);

            WriteIni("舵机参数—左侧鱼鳍姿态舵机", "终止位置", Txt_FinLeft_Attitude_Position.Text);
            MyRov.ServoData.FinLeft_Attitude_Position = Convert.ToUInt16(Txt_FinLeft_Attitude_Position.Text);

            WriteIni("舵机参数—左侧鱼鳍划水舵机", "起始位置", Txt_FinLeft_Thrash_StartingPosition.Text);
            WriteIni("舵机参数—左侧鱼鳍划水舵机", "终止位置", Txt_FinLeft_Thrash_EndingPosition.Text);
            WriteIni("舵机参数—左侧鱼鳍划水舵机", "向下拍水时 每次改变的占空比", Txt_FinLeft_Thrash_Down_EachCCR.Text);            
            WriteIni("舵机参数—左侧鱼鳍划水舵机", "向下拍水时 延时长度", Txt_FinLeft_Thrash_Down_DelayTime.Text);
            WriteIni("舵机参数—左侧鱼鳍划水舵机", "向上拍水时 每次改变的占空比", Txt_FinLeft_Thrash_Up_EachCCR.Text);            
            WriteIni("舵机参数—左侧鱼鳍划水舵机", "向上拍水时 延时长度  ", Txt_FinLeft_Thrash_Up_DelayTime.Text);
            MyRov.ServoData.FinLeft_Thrash_StartingPosition = Convert.ToUInt16(Txt_FinLeft_Thrash_StartingPosition.Text);
            MyRov.ServoData.FinLeft_Thrash_EndingPosition   = Convert.ToUInt16(Txt_FinLeft_Thrash_EndingPosition.Text);
            MyRov.ServoData.FinLeft_Thrash_Down_EachCCR     = Convert.ToUInt16(Txt_FinLeft_Thrash_Down_EachCCR.Text);            
            MyRov.ServoData.FinLeft_Thrash_Down_DelayTime   = Convert.ToUInt16(Txt_FinLeft_Thrash_Down_DelayTime.Text);
            MyRov.ServoData.FinLeft_Thrash_Up_EachCCR       = Convert.ToUInt16(Txt_FinLeft_Thrash_Up_EachCCR.Text);            
            MyRov.ServoData.FinLeft_Thrash_Up_DelayTime     = Convert.ToUInt16(Txt_FinLeft_Thrash_Up_DelayTime.Text);

            WriteIni("舵机参数—右侧鱼鳍姿态舵机", "终止位置", Txt_FinRight_Attitude_Position.Text);
            MyRov.ServoData.FinRight_Attitude_Position = Convert.ToUInt16(Txt_FinRight_Attitude_Position.Text);

            WriteIni("舵机参数—右侧鱼鳍划水舵机", "起始位置", Txt_FinRight_Thrash_StartingPosition.Text);
            WriteIni("舵机参数—右侧鱼鳍划水舵机", "终止位置", Txt_FinRight_Thrash_EndingPosition.Text);
            WriteIni("舵机参数—右侧鱼鳍划水舵机", "向下拍水时 每次改变的占空比", Txt_FinRight_Thrash_Down_EachCCR.Text);            
            WriteIni("舵机参数—右侧鱼鳍划水舵机", "向下拍水时 延时长度", Txt_FinRight_Thrash_Down_DelayTime.Text);
            WriteIni("舵机参数—右侧鱼鳍划水舵机", "向上拍水时 每次改变的占空比", Txt_FinRight_Thrash_Up_EachCCR.Text);           
            WriteIni("舵机参数—右侧鱼鳍划水舵机", "向上拍水时 延时长度  ", Txt_FinRight_Thrash_Up_DelayTime.Text);
            MyRov.ServoData.FinRight_Thrash_StartingPosition = Convert.ToUInt16(Txt_FinRight_Thrash_StartingPosition.Text);
            MyRov.ServoData.FinRight_Thrash_EndingPosition   = Convert.ToUInt16(Txt_FinRight_Thrash_EndingPosition.Text);
            MyRov.ServoData.FinRight_Thrash_Down_EachCCR     = Convert.ToUInt16(Txt_FinRight_Thrash_Down_EachCCR.Text);          
            MyRov.ServoData.FinRight_Thrash_Down_DelayTime   = Convert.ToUInt16(Txt_FinRight_Thrash_Down_DelayTime.Text);
            MyRov.ServoData.FinRight_Thrash_Up_EachCCR       = Convert.ToUInt16(Txt_FinRight_Thrash_Up_EachCCR.Text);            
            MyRov.ServoData.FinRight_Thrash_Up_DelayTime     = Convert.ToUInt16(Txt_FinRight_Thrash_Up_DelayTime.Text);

            WriteIni("舵机参数—摄像机云台舵机", "终止位置 ", Txt_Camera_Position.Text);
            MyRov.ServoData.Camera_Position = Convert.ToUInt16(Txt_Camera_Position.Text);
 
                SendCommand(TX_StartBit_SERVO, MyRov);
            SendCommand(TX_StartBit_SERVO, MyRov);
            SendCommand(TX_StartBit_SERVO, MyRov);
            SendCommand(TX_StartBit_SERVO, MyRov);
            SendCommand(TX_StartBit_SERVO, MyRov);
            SendCommand(TX_StartBit_SERVO, MyRov);

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
    }
}
