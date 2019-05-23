using System;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using OpenCvSharp.Extensions;
using OpenCvSharp;
using static ROV_Test.MessageBoxHandler;


namespace ROV_Test
{
    public partial class 网络摄像头 : Form
    {
        public 网络摄像头()
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


        public string Path = "";
        Mat Source = new Mat();
        public Thread th;
        public UInt16 Isopen = 0;

        public string UserName;
        public string Password;
        public string IPAddress;
        
        /// <summary>
        /// 读档，数据初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 网络摄像头_Shown(object sender, EventArgs e)
        {
            //读档
            Txt_UserName.Text = ReadIni("网络摄像头设置", "用户名", "");
            Txt_Password.Text = ReadIni("网络摄像头设置", "密码", "");
            Txt_IPAddress.Text = ReadIni("网络摄像头设置", "IP地址", "");
            UserName = Txt_UserName.Text;
            Password = Txt_Password.Text;
            IPAddress = Txt_IPAddress.Text;

            Path = "rtsp://" + UserName + ":" + Password + "@" + IPAddress + "/Streaming/Channels/0";

            MessageBox.Show("网络摄像头设置初始化完成", "Success");
            FindAndKillWindow();
        }



        /// <summary>
        /// 保存数据并发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Preservation_Click(object sender, EventArgs e)
        {
            MessageBox.Show("保存数据中,请稍等。。。", "Waiting");

            //存档
            WriteIni("网络摄像头设置", "用户名", Txt_UserName.Text);
            WriteIni("网络摄像头设置", "密码", Txt_Password.Text);
            WriteIni("网络摄像头设置", "IP地址", Txt_IPAddress.Text);

            UserName = Txt_UserName.Text;
            Password = Txt_Password.Text;
            IPAddress = Txt_IPAddress.Text;

            Path = "rtsp://" + UserName + ":" + Password + "@" + IPAddress + "/Streaming/Channels/0";

            MessageBox.Show("数据保存成功", "Success");
            FindAndKillWindow();

        }



        /// <summary>
        /// 按取消键，不进行任何操作，关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        ////定义一个代理
        //public delegate void CallBackDelegate(string message);

        

        /// <summary>
        /// 获取图像
        /// </summary>
        public void Cap_Run(object o)
        {
            VideoCapture cap = new VideoCapture(Path);
            while (true)
            {
                cap.Read(Source);
                try
                {
                    (this.Owner as MainForm).PicBox_Video.Image = BitmapConverter.ToBitmap(Source);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }


        }

        private void CallBack(string message)
        {
            MessageBox.Show(message);
        }


        /// <summary>
        /// 连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Connect_Click(object sender, EventArgs e)
        {
            th = new Thread(Cap_Run);
            Isopen = 1;
            th.Start();
        }

        private void 网络摄像头_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();    
        }
    }
}
