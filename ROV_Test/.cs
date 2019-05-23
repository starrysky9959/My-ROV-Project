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
using OpenCvSharp.Aruco;
using OpenCvSharp.Blob;
using OpenCvSharp.Cuda;
using OpenCvSharp.Detail;
using OpenCvSharp.Dnn;
using OpenCvSharp.Extensions;
using OpenCvSharp.Face;
using OpenCvSharp.Flann;
using OpenCvSharp.ImgHash;
using OpenCvSharp.ML;
using OpenCvSharp.OptFlow;
using OpenCvSharp.Text;
using OpenCvSharp.Tracking;
using OpenCvSharp.UserInterface;
using OpenCvSharp.Util;
using OpenCvSharp.XFeatures2D;
using OpenCvSharp.XImgProc;
using OpenCvSharp.XPhoto;
using OpenCvSharp;

namespace ROV_Test
{
    public partial class 网络摄像头设置: Form
    {
        public 网络摄像头设置()
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


        //public string CameraIP;
        //public string PortName;
        //public string UserName;
        //public string Password;


        public Thread th;

        Mat VideoSource = new Mat(); // 初始化一个保存视频信息的矩阵
        public string VideoPath = "";            //视频地址路径
        public int IsOpen = 0;

        /// <summary>
        /// 读取存档，完成网络摄像头各项参数初始化。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 网络摄像头设置_Shown(object sender, EventArgs e)
        {
            MessageBox.Show("网络摄像头初始化中,请稍等。。。", "Waiting");

            //读取存档
            Txt_CameraIP.Text = ReadIni("NetworkCamera", "CameraIP", "");
            Txt_PortName.Text = ReadIni("NetworkCamera", "PortName", "");
            Txt_UserName.Text = ReadIni("NetworkCamera", "UserName", "");
            Txt_Password.Text = ReadIni("NetworkCamera", "Password", "");

            //主码流 参考具体网络摄像头视频地址格式
            VideoPath = "rtsp://" + Txt_UserName.Text + ":" + Txt_Password.Text + "@" + Txt_CameraIP.Text + "/mpeg4";

            for (int i = 0; i < 10000; i++) ;
            MessageBox.Show("网络摄像头初始化完成，可以开始使用", "Success", MessageBoxButtons.OK);
        }


        /// <summary>
        /// 保存当前网络摄像头设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Preservation_Click(object sender, EventArgs e)
        {
            MessageBox.Show("保存数据中,请稍等。。。", "Waiting");

            //存档
            WriteIni("NetworkCamera", "CameraIP", Txt_CameraIP.Text);
            WriteIni("NetworkCamera", "PortName", Txt_PortName.Text);
            WriteIni("NetworkCamera", "UserName", Txt_UserName.Text);
            WriteIni("NetworkCamera", "Password", Txt_Password.Text);

            //更新视频地址
            VideoPath = "rtsp://" + Txt_UserName.Text + ":" + Txt_Password.Text + "@" + Txt_CameraIP.Text + "/mpeg4";

            for (int i = 0; i < 10000; i++) ;
            MessageBox.Show("数据保存成功，请重启程序以更新设置", "Success",MessageBoxButtons.OK);
        }


        /// <summary>
        /// 获取视频信息并更新
        /// </summary>
        public void Cap_Run()
        {
            //实例化一个cap 用于获取视频 视频路径
            VideoCapture cap = new VideoCapture(VideoPath);
            while (true)
            {
                try
                {
                    //获取视频信息以矩阵形式保存到VideoSource
                    cap.Read(VideoSource);
                    //将矩阵信息转换成图像
                    (this.Owner as MainForm).PicBox_Video.Image = BitmapConverter.ToBitmap(VideoSource);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }


        /// <summary>
        /// 按下取消按钮，不进行任何操作，关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Btn_Connect_Click(object sender, EventArgs e)
        {
            //创建连接
            th = new Thread(Cap_Run);
            IsOpen = 1;
            th.Start();
        }
    }
}
