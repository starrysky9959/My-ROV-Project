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
    public partial class PID系数 : Form
    {
        public PID系数()
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
        /// 读档，完成数据初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PID系数_Shown(object sender, EventArgs e)
        {
            //读取存档
            Txt_Depth_Kp.Text = ReadIni("PID系数—深度", "Kp", "0");
            Txt_Depth_Ki.Text = ReadIni("PID系数—深度", "Ki", "0");
            Txt_Depth_Kd.Text = ReadIni("PID系数—深度", "Kd", "0");
            Txt_Depth_Target.Text = ReadIni("PID系数—深度", "Target", "0");

            Txt_Pitch_Kp.Text = ReadIni("PID系数—俯仰角", "Kp", "0");
            Txt_Pitch_Ki.Text = ReadIni("PID系数—俯仰角", "Ki", "0");
            Txt_Pitch_Kd.Text = ReadIni("PID系数—俯仰角", "Kd", "0");
            Txt_Pitch_Target.Text = ReadIni("PID系数—俯仰角", "Target", "0");

            Txt_AngleSpeedY_Kp.Text = ReadIni("PID系数—Y轴角速度", "Kp", "0");
            Txt_AngleSpeedY_Ki.Text = ReadIni("PID系数—Y轴角速度", "Ki", "0");
            Txt_AngleSpeedY_Kd.Text = ReadIni("PID系数—Y轴角速度", "Kd", "0");
            Txt_AngleSpeedY_Target.Text = ReadIni("PID系数—Y轴角速度", "Target", "0");

            Txt_AccelerationY_Kp.Text = ReadIni("PID系数—Y轴加速度", "Kp", "0");
            Txt_AccelerationY_Ki.Text = ReadIni("PID系数—Y轴加速度", "Ki", "0");
            Txt_AccelerationY_Kd.Text = ReadIni("PID系数—Y轴加速度", "Kd", "0");
            Txt_AccelerationY_Target.Text = ReadIni("PID系数—Y轴加速度", "Target", "0");

            RadBtn_None.Checked = true;

            MessageBox.Show("PID系数初始化完成", "Success");
            FindAndKillWindow();
        }


        /// <summary>
        /// 存档并发送指令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Preservation_Click(object sender, EventArgs e)
        {
            MessageBox.Show("保存数据中,请稍等。。。", "Waiting");
            //存档
            WriteIni("PID系数—深度", "Kp", Txt_Depth_Kp.Text);
            WriteIni("PID系数—深度", "Ki", Txt_Depth_Ki.Text);
            WriteIni("PID系数—深度", "Kd", Txt_Depth_Kd.Text);
            WriteIni("PID系数—深度", "Target", Txt_Depth_Target.Text);
            MyRov.pidData_Depth.Kp = Convert.ToSingle(Txt_Depth_Kp.Text);
            MyRov.pidData_Depth.Ki = Convert.ToSingle(Txt_Depth_Ki.Text);
            MyRov.pidData_Depth.Kd = Convert.ToSingle(Txt_Depth_Kd.Text);
            MyRov.pidData_Depth.Target = Convert.ToSingle(Txt_Depth_Target.Text);

            WriteIni("PID系数—俯仰角", "Kp", Txt_Pitch_Kp.Text);
            WriteIni("PID系数—俯仰角", "Ki", Txt_Pitch_Ki.Text);
            WriteIni("PID系数—俯仰角", "Kd", Txt_Pitch_Kd.Text);
            WriteIni("PID系数—俯仰角", "Target", Txt_Pitch_Target.Text);
            MyRov.pidData_Pitch.Kp = Convert.ToSingle(Txt_Pitch_Kp.Text);
            MyRov.pidData_Pitch.Ki = Convert.ToSingle(Txt_Pitch_Ki.Text);
            MyRov.pidData_Pitch.Kd = Convert.ToSingle(Txt_Pitch_Kd.Text);
            MyRov.pidData_Pitch.Target = Convert.ToSingle(Txt_Pitch_Target.Text);

            WriteIni("PID系数—Y轴角速度", "Kp", Txt_AngleSpeedY_Kp.Text);
            WriteIni("PID系数—Y轴角速度", "Ki", Txt_AngleSpeedY_Ki.Text);
            WriteIni("PID系数—Y轴角速度", "Kd", Txt_AngleSpeedY_Kd.Text);
            WriteIni("PID系数—Y轴角速度", "Target", Txt_AngleSpeedY_Target.Text);
            MyRov.pidData_Yaw.Kp = Convert.ToSingle(Txt_AngleSpeedY_Kp.Text);
            MyRov.pidData_Yaw.Ki = Convert.ToSingle(Txt_AngleSpeedY_Ki.Text);
            MyRov.pidData_Yaw.Kd = Convert.ToSingle(Txt_AngleSpeedY_Kd.Text);
            MyRov.pidData_Yaw.Target = Convert.ToSingle(Txt_AngleSpeedY_Target.Text);

            WriteIni("PID系数—Y轴加速度", "Kp", Txt_AccelerationY_Kp.Text);
            WriteIni("PID系数—Y轴加速度", "Ki", Txt_AccelerationY_Ki.Text);
            WriteIni("PID系数—Y轴加速度", "Kd", Txt_AccelerationY_Kd.Text);
            WriteIni("PID系数—Y轴加速度", "Target", Txt_AccelerationY_Target.Text);
            MyRov.pidData_AccelerationY.Kp = Convert.ToSingle(Txt_AccelerationY_Kp.Text);
            MyRov.pidData_AccelerationY.Ki = Convert.ToSingle(Txt_AccelerationY_Ki.Text);
            MyRov.pidData_AccelerationY.Kd = Convert.ToSingle(Txt_AccelerationY_Kd.Text);
            MyRov.pidData_AccelerationY.Target = Convert.ToSingle(Txt_AccelerationY_Target.Text);

            SendCommand(TX_StartBit_PID, MyRov);

            FindAndKillWindow();
        }


        /// <summary>
        /// 按取消键，不进行任何操作，关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// 改为调试深度的模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadBtn_Depth_CheckedChanged(object sender, EventArgs e)
        {
            MyRov.Mode.DepthMode = 1;
            MyRov.Mode.PitchMode = 0;
            MyRov.Mode.AngleSpeedYMode = 0;
            SendCommand(TX_StartBit_MODE, MyRov);
        }


        /// <summary>
        /// 改为调试俯仰角的模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadBtn_Pitch_CheckedChanged(object sender, EventArgs e)
        {
            MyRov.Mode.DepthMode = 0;
            MyRov.Mode.PitchMode = 1;
            MyRov.Mode.AngleSpeedYMode = 0;
            SendCommand(TX_StartBit_MODE, MyRov);
        }


        /// <summary>
        /// 改为调试Y轴角速度的模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadBtn_AngleSpeedY_CheckedChanged(object sender, EventArgs e)
        {
            MyRov.Mode.DepthMode = 0;
            MyRov.Mode.PitchMode = 0;
            MyRov.Mode.AngleSpeedYMode = 1;
            SendCommand(TX_StartBit_MODE, MyRov);
        }


        /// <summary>
        /// 改为都不调的模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadBtn_None_CheckedChanged(object sender, EventArgs e)
        {
            MyRov.Mode.DepthMode = 0;
            MyRov.Mode.PitchMode = 0;
            MyRov.Mode.AngleSpeedYMode = 0;
            SendCommand(TX_StartBit_MODE, MyRov);
        }


        /// <summary>
        /// 改为调试Y轴加速度的模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkBox.Checked)
            {
                MyRov.Mode.AccelerationYMode = 1;
            }
            else
            {
                MyRov.Mode.AccelerationYMode = 0;
            }
            SendCommand(TX_StartBit_MODE, MyRov);
        }

        private void PID系数_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }
    }
}
