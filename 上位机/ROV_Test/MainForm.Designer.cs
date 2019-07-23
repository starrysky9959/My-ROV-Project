namespace ROV_Test
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.GroupBox_Init = new System.Windows.Forms.GroupBox();
            this.Btn_Servo = new System.Windows.Forms.Button();
            this.Txt_Info = new System.Windows.Forms.TextBox();
            this.Lab_Flag = new System.Windows.Forms.Label();
            this.Btn_Start = new System.Windows.Forms.Button();
            this.Btn_Stop = new System.Windows.Forms.Button();
            this.Btn_Send = new System.Windows.Forms.Button();
            this.Btn_Parameter = new System.Windows.Forms.Button();
            this.Btn_Open = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Lab_Val_Depth = new System.Windows.Forms.Label();
            this.Lab_Val_Pressure = new System.Windows.Forms.Label();
            this.Lab_Pressure = new System.Windows.Forms.Label();
            this.Lab_AngleSpeedY = new System.Windows.Forms.Label();
            this.Lab_AngleSpeedX = new System.Windows.Forms.Label();
            this.Lab_AngleSpeedZ = new System.Windows.Forms.Label();
            this.Lab_Temperature = new System.Windows.Forms.Label();
            this.Lab_Depth = new System.Windows.Forms.Label();
            this.Lab_Val_AngleSpeedY = new System.Windows.Forms.Label();
            this.Lab_Val_AngleSpeedX = new System.Windows.Forms.Label();
            this.Lab_Val_Temperature = new System.Windows.Forms.Label();
            this.Lab_Val_AngleSpeedZ = new System.Windows.Forms.Label();
            this.PicBox_Video = new System.Windows.Forms.PictureBox();
            this.Btn_TurnLeft = new System.Windows.Forms.Button();
            this.Btn_Down = new System.Windows.Forms.Button();
            this.Btn_Hover = new System.Windows.Forms.Button();
            this.Btn_SpeedLv3 = new System.Windows.Forms.Button();
            this.Btn_SpeedLv2 = new System.Windows.Forms.Button();
            this.Btn_SpeedLv1 = new System.Windows.Forms.Button();
            this.Btn_TurnRight = new System.Windows.Forms.Button();
            this.Btn_Up = new System.Windows.Forms.Button();
            this.GroupBox_KeyBoard = new System.Windows.Forms.GroupBox();
            this.Btn_KeyPressW = new System.Windows.Forms.Button();
            this.Btn_KeyPressA = new System.Windows.Forms.Button();
            this.Btn_KeyPressS = new System.Windows.Forms.Button();
            this.Btn_KeyPressD = new System.Windows.Forms.Button();
            this.MySerialPort = new System.IO.Ports.SerialPort(this.components);
            this.GroupBox_Command = new System.Windows.Forms.GroupBox();
            this.menuStrip_设置 = new System.Windows.Forms.MenuStrip();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.视频传输设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PID系数设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Timer_UpdateData = new System.Windows.Forms.Timer(this.components);
            this.GroupBox_AngleSpeed = new System.Windows.Forms.GroupBox();
            this.GroupBox_Temperature = new System.Windows.Forms.GroupBox();
            this.VertProgressBar_Pressure = new MissionPlanner.Controls.VerticalProgressBar();
            this.VertProgressBar_Depth = new MissionPlanner.Controls.VerticalProgressBar();
            this.GroupBox_Acceleration = new System.Windows.Forms.GroupBox();
            this.Lab_Val_AccelerationZ = new System.Windows.Forms.Label();
            this.Lab_AccelerationY = new System.Windows.Forms.Label();
            this.Lab_AccelerationX = new System.Windows.Forms.Label();
            this.Lab_AccelerationZ = new System.Windows.Forms.Label();
            this.Lab_Val_AccelerationY = new System.Windows.Forms.Label();
            this.Lab_Val_AccelerationX = new System.Windows.Forms.Label();
            this.GroupBox_压力深度 = new System.Windows.Forms.GroupBox();
            this.RadBtn_FreeMode = new System.Windows.Forms.RadioButton();
            this.RadBtn_PIDMode = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RadBtn_ObjectTrack = new System.Windows.Forms.RadioButton();
            this.Lab_ControlMode = new System.Windows.Forms.Label();
            this.Hud = new MissionPlanner.Controls.HUD();
            this.Btn_HeadUp = new System.Windows.Forms.Button();
            this.Btn_HeadDown = new System.Windows.Forms.Button();
            this.Btn_KeyPressE = new System.Windows.Forms.Button();
            this.Btn_KeyPressQ = new System.Windows.Forms.Button();
            this.GroupBox_Init.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox_Video)).BeginInit();
            this.GroupBox_KeyBoard.SuspendLayout();
            this.GroupBox_Command.SuspendLayout();
            this.menuStrip_设置.SuspendLayout();
            this.GroupBox_AngleSpeed.SuspendLayout();
            this.GroupBox_Temperature.SuspendLayout();
            this.GroupBox_Acceleration.SuspendLayout();
            this.GroupBox_压力深度.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox_Init
            // 
            this.GroupBox_Init.Controls.Add(this.Btn_Servo);
            this.GroupBox_Init.Controls.Add(this.Txt_Info);
            this.GroupBox_Init.Controls.Add(this.Lab_Flag);
            this.GroupBox_Init.Controls.Add(this.Btn_Start);
            this.GroupBox_Init.Controls.Add(this.Btn_Stop);
            this.GroupBox_Init.Controls.Add(this.Btn_Send);
            this.GroupBox_Init.Controls.Add(this.Btn_Parameter);
            this.GroupBox_Init.Controls.Add(this.Btn_Open);
            this.GroupBox_Init.Controls.Add(this.groupBox3);
            this.GroupBox_Init.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GroupBox_Init.Location = new System.Drawing.Point(10, 31);
            this.GroupBox_Init.Name = "GroupBox_Init";
            this.GroupBox_Init.Size = new System.Drawing.Size(284, 322);
            this.GroupBox_Init.TabIndex = 0;
            this.GroupBox_Init.TabStop = false;
            // 
            // Btn_Servo
            // 
            this.Btn_Servo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Btn_Servo.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Servo.ForeColor = System.Drawing.Color.Black;
            this.Btn_Servo.Location = new System.Drawing.Point(5, 150);
            this.Btn_Servo.Name = "Btn_Servo";
            this.Btn_Servo.Size = new System.Drawing.Size(90, 50);
            this.Btn_Servo.TabIndex = 31;
            this.Btn_Servo.Text = "舵机";
            this.Btn_Servo.UseVisualStyleBackColor = false;
            this.Btn_Servo.Click += new System.EventHandler(this.Btn_Servo_Click);
            // 
            // Txt_Info
            // 
            this.Txt_Info.Location = new System.Drawing.Point(5, 206);
            this.Txt_Info.Multiline = true;
            this.Txt_Info.Name = "Txt_Info";
            this.Txt_Info.Size = new System.Drawing.Size(273, 110);
            this.Txt_Info.TabIndex = 7;
            // 
            // Lab_Flag
            // 
            this.Lab_Flag.BackColor = System.Drawing.Color.Red;
            this.Lab_Flag.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Lab_Flag.Location = new System.Drawing.Point(121, 95);
            this.Lab_Flag.Name = "Lab_Flag";
            this.Lab_Flag.Size = new System.Drawing.Size(35, 35);
            this.Lab_Flag.TabIndex = 6;
            // 
            // Btn_Start
            // 
            this.Btn_Start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Btn_Start.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Start.ForeColor = System.Drawing.Color.Black;
            this.Btn_Start.Location = new System.Drawing.Point(5, 85);
            this.Btn_Start.Name = "Btn_Start";
            this.Btn_Start.Size = new System.Drawing.Size(90, 50);
            this.Btn_Start.TabIndex = 5;
            this.Btn_Start.Text = "启动";
            this.Btn_Start.UseVisualStyleBackColor = false;
            this.Btn_Start.Click += new System.EventHandler(this.Btn_Start_Click);
            // 
            // Btn_Stop
            // 
            this.Btn_Stop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Btn_Stop.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Stop.ForeColor = System.Drawing.Color.Black;
            this.Btn_Stop.Location = new System.Drawing.Point(180, 85);
            this.Btn_Stop.Name = "Btn_Stop";
            this.Btn_Stop.Size = new System.Drawing.Size(90, 50);
            this.Btn_Stop.TabIndex = 4;
            this.Btn_Stop.Text = "停止";
            this.Btn_Stop.UseVisualStyleBackColor = false;
            this.Btn_Stop.Click += new System.EventHandler(this.Btn_Stop_Click);
            // 
            // Btn_Send
            // 
            this.Btn_Send.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Btn_Send.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Send.ForeColor = System.Drawing.Color.Black;
            this.Btn_Send.Location = new System.Drawing.Point(180, 150);
            this.Btn_Send.Name = "Btn_Send";
            this.Btn_Send.Size = new System.Drawing.Size(90, 50);
            this.Btn_Send.TabIndex = 2;
            this.Btn_Send.Text = "传输";
            this.Btn_Send.UseVisualStyleBackColor = false;
            this.Btn_Send.Click += new System.EventHandler(this.Btn_Send_Click);
            // 
            // Btn_Parameter
            // 
            this.Btn_Parameter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Btn_Parameter.Font = new System.Drawing.Font("微软雅黑", 12.5F, System.Drawing.FontStyle.Bold);
            this.Btn_Parameter.ForeColor = System.Drawing.Color.Black;
            this.Btn_Parameter.Location = new System.Drawing.Point(180, 20);
            this.Btn_Parameter.Name = "Btn_Parameter";
            this.Btn_Parameter.Size = new System.Drawing.Size(90, 50);
            this.Btn_Parameter.TabIndex = 1;
            this.Btn_Parameter.Text = "摄像头";
            this.Btn_Parameter.UseVisualStyleBackColor = false;
            this.Btn_Parameter.Click += new System.EventHandler(this.Btn_Parameter_Click);
            // 
            // Btn_Open
            // 
            this.Btn_Open.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Btn_Open.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.Btn_Open.ForeColor = System.Drawing.Color.Black;
            this.Btn_Open.Location = new System.Drawing.Point(5, 20);
            this.Btn_Open.Name = "Btn_Open";
            this.Btn_Open.Size = new System.Drawing.Size(90, 50);
            this.Btn_Open.TabIndex = 0;
            this.Btn_Open.Text = "打开串口";
            this.Btn_Open.UseVisualStyleBackColor = false;
            this.Btn_Open.Click += new System.EventHandler(this.Btn_Open_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Lab_Val_Depth);
            this.groupBox3.Controls.Add(this.Lab_Val_Pressure);
            this.groupBox3.Location = new System.Drawing.Point(17, 322);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(286, 140);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // Lab_Val_Depth
            // 
            this.Lab_Val_Depth.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Lab_Val_Depth.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Val_Depth.Location = new System.Drawing.Point(104, 55);
            this.Lab_Val_Depth.Name = "Lab_Val_Depth";
            this.Lab_Val_Depth.Size = new System.Drawing.Size(70, 45);
            this.Lab_Val_Depth.TabIndex = 17;
            // 
            // Lab_Val_Pressure
            // 
            this.Lab_Val_Pressure.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Lab_Val_Pressure.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Val_Pressure.Location = new System.Drawing.Point(4, 55);
            this.Lab_Val_Pressure.Name = "Lab_Val_Pressure";
            this.Lab_Val_Pressure.Size = new System.Drawing.Size(70, 45);
            this.Lab_Val_Pressure.TabIndex = 2;
            // 
            // Lab_Pressure
            // 
            this.Lab_Pressure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Lab_Pressure.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lab_Pressure.Location = new System.Drawing.Point(8, 21);
            this.Lab_Pressure.Name = "Lab_Pressure";
            this.Lab_Pressure.Size = new System.Drawing.Size(55, 45);
            this.Lab_Pressure.TabIndex = 1;
            this.Lab_Pressure.Text = "压力";
            this.Lab_Pressure.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lab_AngleSpeedY
            // 
            this.Lab_AngleSpeedY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Lab_AngleSpeedY.Font = new System.Drawing.Font("黑体", 10.7F, System.Drawing.FontStyle.Bold);
            this.Lab_AngleSpeedY.Location = new System.Drawing.Point(6, 79);
            this.Lab_AngleSpeedY.Name = "Lab_AngleSpeedY";
            this.Lab_AngleSpeedY.Size = new System.Drawing.Size(70, 45);
            this.Lab_AngleSpeedY.TabIndex = 3;
            this.Lab_AngleSpeedY.Text = " Y轴   角速度";
            this.Lab_AngleSpeedY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lab_AngleSpeedX
            // 
            this.Lab_AngleSpeedX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Lab_AngleSpeedX.Font = new System.Drawing.Font("黑体", 10.7F, System.Drawing.FontStyle.Bold);
            this.Lab_AngleSpeedX.Location = new System.Drawing.Point(6, 21);
            this.Lab_AngleSpeedX.Name = "Lab_AngleSpeedX";
            this.Lab_AngleSpeedX.Size = new System.Drawing.Size(70, 45);
            this.Lab_AngleSpeedX.TabIndex = 4;
            this.Lab_AngleSpeedX.Text = " X轴   角速度";
            this.Lab_AngleSpeedX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lab_AngleSpeedZ
            // 
            this.Lab_AngleSpeedZ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Lab_AngleSpeedZ.Font = new System.Drawing.Font("黑体", 10.7F, System.Drawing.FontStyle.Bold);
            this.Lab_AngleSpeedZ.Location = new System.Drawing.Point(6, 138);
            this.Lab_AngleSpeedZ.Name = "Lab_AngleSpeedZ";
            this.Lab_AngleSpeedZ.Size = new System.Drawing.Size(70, 45);
            this.Lab_AngleSpeedZ.TabIndex = 8;
            this.Lab_AngleSpeedZ.Text = " Z轴   角速度";
            this.Lab_AngleSpeedZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lab_Temperature
            // 
            this.Lab_Temperature.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Lab_Temperature.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lab_Temperature.Location = new System.Drawing.Point(6, 23);
            this.Lab_Temperature.Name = "Lab_Temperature";
            this.Lab_Temperature.Size = new System.Drawing.Size(59, 45);
            this.Lab_Temperature.TabIndex = 9;
            this.Lab_Temperature.Text = "温度";
            this.Lab_Temperature.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lab_Depth
            // 
            this.Lab_Depth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Lab_Depth.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lab_Depth.Location = new System.Drawing.Point(69, 21);
            this.Lab_Depth.Name = "Lab_Depth";
            this.Lab_Depth.Size = new System.Drawing.Size(54, 45);
            this.Lab_Depth.TabIndex = 10;
            this.Lab_Depth.Text = "深度";
            this.Lab_Depth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lab_Val_AngleSpeedY
            // 
            this.Lab_Val_AngleSpeedY.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Lab_Val_AngleSpeedY.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Val_AngleSpeedY.Location = new System.Drawing.Point(93, 79);
            this.Lab_Val_AngleSpeedY.Name = "Lab_Val_AngleSpeedY";
            this.Lab_Val_AngleSpeedY.Size = new System.Drawing.Size(166, 45);
            this.Lab_Val_AngleSpeedY.TabIndex = 11;
            this.Lab_Val_AngleSpeedY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Lab_Val_AngleSpeedX
            // 
            this.Lab_Val_AngleSpeedX.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Lab_Val_AngleSpeedX.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Val_AngleSpeedX.Location = new System.Drawing.Point(93, 21);
            this.Lab_Val_AngleSpeedX.Name = "Lab_Val_AngleSpeedX";
            this.Lab_Val_AngleSpeedX.Size = new System.Drawing.Size(166, 45);
            this.Lab_Val_AngleSpeedX.TabIndex = 12;
            this.Lab_Val_AngleSpeedX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Lab_Val_Temperature
            // 
            this.Lab_Val_Temperature.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Lab_Val_Temperature.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Val_Temperature.Location = new System.Drawing.Point(71, 23);
            this.Lab_Val_Temperature.Name = "Lab_Val_Temperature";
            this.Lab_Val_Temperature.Size = new System.Drawing.Size(72, 45);
            this.Lab_Val_Temperature.TabIndex = 16;
            this.Lab_Val_Temperature.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lab_Val_AngleSpeedZ
            // 
            this.Lab_Val_AngleSpeedZ.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Lab_Val_AngleSpeedZ.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Val_AngleSpeedZ.Location = new System.Drawing.Point(93, 138);
            this.Lab_Val_AngleSpeedZ.Name = "Lab_Val_AngleSpeedZ";
            this.Lab_Val_AngleSpeedZ.Size = new System.Drawing.Size(166, 45);
            this.Lab_Val_AngleSpeedZ.TabIndex = 18;
            this.Lab_Val_AngleSpeedZ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PicBox_Video
            // 
            this.PicBox_Video.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PicBox_Video.Image = ((System.Drawing.Image)(resources.GetObject("PicBox_Video.Image")));
            this.PicBox_Video.Location = new System.Drawing.Point(313, 254);
            this.PicBox_Video.Name = "PicBox_Video";
            this.PicBox_Video.Size = new System.Drawing.Size(741, 498);
            this.PicBox_Video.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBox_Video.TabIndex = 19;
            this.PicBox_Video.TabStop = false;
            this.PicBox_Video.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PicBox_Video_MouseClick);
            this.PicBox_Video.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PicBox_Video_MouseMove);
            this.PicBox_Video.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.PicBox_Video_MouseWheel);
            // 
            // Btn_TurnLeft
            // 
            this.Btn_TurnLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Btn_TurnLeft.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_TurnLeft.ForeColor = System.Drawing.Color.Black;
            this.Btn_TurnLeft.Location = new System.Drawing.Point(10, 24);
            this.Btn_TurnLeft.Name = "Btn_TurnLeft";
            this.Btn_TurnLeft.Size = new System.Drawing.Size(90, 50);
            this.Btn_TurnLeft.TabIndex = 20;
            this.Btn_TurnLeft.Text = "左转弯";
            this.Btn_TurnLeft.UseVisualStyleBackColor = false;
            this.Btn_TurnLeft.Click += new System.EventHandler(this.Btn_TurnLeft_Click);
            // 
            // Btn_Down
            // 
            this.Btn_Down.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Btn_Down.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Down.ForeColor = System.Drawing.Color.Black;
            this.Btn_Down.Location = new System.Drawing.Point(225, 90);
            this.Btn_Down.Name = "Btn_Down";
            this.Btn_Down.Size = new System.Drawing.Size(90, 50);
            this.Btn_Down.TabIndex = 21;
            this.Btn_Down.Text = "下潜";
            this.Btn_Down.UseVisualStyleBackColor = false;
            // 
            // Btn_Hover
            // 
            this.Btn_Hover.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Btn_Hover.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Hover.ForeColor = System.Drawing.Color.Black;
            this.Btn_Hover.Location = new System.Drawing.Point(116, 160);
            this.Btn_Hover.Name = "Btn_Hover";
            this.Btn_Hover.Size = new System.Drawing.Size(90, 50);
            this.Btn_Hover.TabIndex = 22;
            this.Btn_Hover.Text = "悬停";
            this.Btn_Hover.UseVisualStyleBackColor = false;
            // 
            // Btn_SpeedLv3
            // 
            this.Btn_SpeedLv3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Btn_SpeedLv3.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_SpeedLv3.ForeColor = System.Drawing.Color.Black;
            this.Btn_SpeedLv3.Location = new System.Drawing.Point(10, 160);
            this.Btn_SpeedLv3.Name = "Btn_SpeedLv3";
            this.Btn_SpeedLv3.Size = new System.Drawing.Size(90, 50);
            this.Btn_SpeedLv3.TabIndex = 23;
            this.Btn_SpeedLv3.Text = "三档速";
            this.Btn_SpeedLv3.UseVisualStyleBackColor = false;
            // 
            // Btn_SpeedLv2
            // 
            this.Btn_SpeedLv2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Btn_SpeedLv2.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_SpeedLv2.ForeColor = System.Drawing.Color.Black;
            this.Btn_SpeedLv2.Location = new System.Drawing.Point(116, 90);
            this.Btn_SpeedLv2.Name = "Btn_SpeedLv2";
            this.Btn_SpeedLv2.Size = new System.Drawing.Size(90, 50);
            this.Btn_SpeedLv2.TabIndex = 24;
            this.Btn_SpeedLv2.Text = "二档速";
            this.Btn_SpeedLv2.UseVisualStyleBackColor = false;
            // 
            // Btn_SpeedLv1
            // 
            this.Btn_SpeedLv1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Btn_SpeedLv1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_SpeedLv1.ForeColor = System.Drawing.Color.Black;
            this.Btn_SpeedLv1.Location = new System.Drawing.Point(10, 90);
            this.Btn_SpeedLv1.Name = "Btn_SpeedLv1";
            this.Btn_SpeedLv1.Size = new System.Drawing.Size(90, 50);
            this.Btn_SpeedLv1.TabIndex = 25;
            this.Btn_SpeedLv1.Text = "一档速";
            this.Btn_SpeedLv1.UseVisualStyleBackColor = false;
            this.Btn_SpeedLv1.Click += new System.EventHandler(this.Btn_SpeedLv1_Click);
            // 
            // Btn_TurnRight
            // 
            this.Btn_TurnRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Btn_TurnRight.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_TurnRight.ForeColor = System.Drawing.Color.Black;
            this.Btn_TurnRight.Location = new System.Drawing.Point(116, 25);
            this.Btn_TurnRight.Name = "Btn_TurnRight";
            this.Btn_TurnRight.Size = new System.Drawing.Size(90, 50);
            this.Btn_TurnRight.TabIndex = 26;
            this.Btn_TurnRight.Text = "右转弯";
            this.Btn_TurnRight.UseVisualStyleBackColor = false;
            this.Btn_TurnRight.Click += new System.EventHandler(this.Btn_TurnRight_Click);
            // 
            // Btn_Up
            // 
            this.Btn_Up.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Btn_Up.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Up.ForeColor = System.Drawing.Color.Black;
            this.Btn_Up.Location = new System.Drawing.Point(225, 25);
            this.Btn_Up.Name = "Btn_Up";
            this.Btn_Up.Size = new System.Drawing.Size(90, 50);
            this.Btn_Up.TabIndex = 28;
            this.Btn_Up.Text = "漂浮";
            this.Btn_Up.UseVisualStyleBackColor = false;
            // 
            // GroupBox_KeyBoard
            // 
            this.GroupBox_KeyBoard.Controls.Add(this.Btn_KeyPressE);
            this.GroupBox_KeyBoard.Controls.Add(this.Btn_KeyPressQ);
            this.GroupBox_KeyBoard.Controls.Add(this.Btn_KeyPressW);
            this.GroupBox_KeyBoard.Controls.Add(this.Btn_KeyPressA);
            this.GroupBox_KeyBoard.Controls.Add(this.Btn_KeyPressS);
            this.GroupBox_KeyBoard.Controls.Add(this.Btn_KeyPressD);
            this.GroupBox_KeyBoard.Location = new System.Drawing.Point(1119, 603);
            this.GroupBox_KeyBoard.Name = "GroupBox_KeyBoard";
            this.GroupBox_KeyBoard.Size = new System.Drawing.Size(246, 171);
            this.GroupBox_KeyBoard.TabIndex = 29;
            this.GroupBox_KeyBoard.TabStop = false;
            // 
            // Btn_KeyPressW
            // 
            this.Btn_KeyPressW.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Btn_KeyPressW.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_KeyPressW.Location = new System.Drawing.Point(83, 12);
            this.Btn_KeyPressW.Name = "Btn_KeyPressW";
            this.Btn_KeyPressW.Size = new System.Drawing.Size(80, 80);
            this.Btn_KeyPressW.TabIndex = 31;
            this.Btn_KeyPressW.Text = "W";
            this.Btn_KeyPressW.UseVisualStyleBackColor = false;
            // 
            // Btn_KeyPressA
            // 
            this.Btn_KeyPressA.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Btn_KeyPressA.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_KeyPressA.Location = new System.Drawing.Point(3, 92);
            this.Btn_KeyPressA.Name = "Btn_KeyPressA";
            this.Btn_KeyPressA.Size = new System.Drawing.Size(80, 80);
            this.Btn_KeyPressA.TabIndex = 32;
            this.Btn_KeyPressA.Text = "A";
            this.Btn_KeyPressA.UseVisualStyleBackColor = false;
            // 
            // Btn_KeyPressS
            // 
            this.Btn_KeyPressS.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Btn_KeyPressS.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_KeyPressS.Location = new System.Drawing.Point(83, 92);
            this.Btn_KeyPressS.Name = "Btn_KeyPressS";
            this.Btn_KeyPressS.Size = new System.Drawing.Size(80, 80);
            this.Btn_KeyPressS.TabIndex = 33;
            this.Btn_KeyPressS.Text = "S";
            this.Btn_KeyPressS.UseVisualStyleBackColor = false;
            // 
            // Btn_KeyPressD
            // 
            this.Btn_KeyPressD.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Btn_KeyPressD.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_KeyPressD.Location = new System.Drawing.Point(163, 92);
            this.Btn_KeyPressD.Name = "Btn_KeyPressD";
            this.Btn_KeyPressD.Size = new System.Drawing.Size(80, 80);
            this.Btn_KeyPressD.TabIndex = 30;
            this.Btn_KeyPressD.Text = "D";
            this.Btn_KeyPressD.UseVisualStyleBackColor = false;
            // 
            // GroupBox_Command
            // 
            this.GroupBox_Command.Controls.Add(this.Btn_Up);
            this.GroupBox_Command.Controls.Add(this.Btn_TurnRight);
            this.GroupBox_Command.Controls.Add(this.Btn_SpeedLv1);
            this.GroupBox_Command.Controls.Add(this.Btn_SpeedLv2);
            this.GroupBox_Command.Controls.Add(this.Btn_SpeedLv3);
            this.GroupBox_Command.Controls.Add(this.Btn_Hover);
            this.GroupBox_Command.Controls.Add(this.Btn_Down);
            this.GroupBox_Command.Controls.Add(this.Btn_TurnLeft);
            this.GroupBox_Command.Location = new System.Drawing.Point(320, 29);
            this.GroupBox_Command.Name = "GroupBox_Command";
            this.GroupBox_Command.Size = new System.Drawing.Size(321, 217);
            this.GroupBox_Command.TabIndex = 31;
            this.GroupBox_Command.TabStop = false;
            this.GroupBox_Command.Text = "特殊动作";
            // 
            // menuStrip_设置
            // 
            this.menuStrip_设置.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip_设置.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置ToolStripMenuItem});
            this.menuStrip_设置.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_设置.Name = "menuStrip_设置";
            this.menuStrip_设置.Size = new System.Drawing.Size(1371, 28);
            this.menuStrip_设置.TabIndex = 32;
            this.menuStrip_设置.Text = "menuStrip1";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.视频传输设置ToolStripMenuItem,
            this.PID系数设置ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // 视频传输设置ToolStripMenuItem
            // 
            this.视频传输设置ToolStripMenuItem.Name = "视频传输设置ToolStripMenuItem";
            this.视频传输设置ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.视频传输设置ToolStripMenuItem.Text = "视频传输设置";
            this.视频传输设置ToolStripMenuItem.Click += new System.EventHandler(this.视频传输设置ToolStripMenuItem_Click);
            // 
            // PID系数设置ToolStripMenuItem
            // 
            this.PID系数设置ToolStripMenuItem.Name = "PID系数设置ToolStripMenuItem";
            this.PID系数设置ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.PID系数设置ToolStripMenuItem.Text = "PID系数设置";
            this.PID系数设置ToolStripMenuItem.Click += new System.EventHandler(this.PID系数设置ToolStripMenuItem_Click);
            // 
            // Timer_UpdateData
            // 
            this.Timer_UpdateData.Tick += new System.EventHandler(this.DisplayRefresh);
            // 
            // GroupBox_AngleSpeed
            // 
            this.GroupBox_AngleSpeed.Controls.Add(this.Lab_Val_AngleSpeedZ);
            this.GroupBox_AngleSpeed.Controls.Add(this.Lab_AngleSpeedY);
            this.GroupBox_AngleSpeed.Controls.Add(this.Lab_AngleSpeedX);
            this.GroupBox_AngleSpeed.Controls.Add(this.Lab_AngleSpeedZ);
            this.GroupBox_AngleSpeed.Controls.Add(this.Lab_Val_AngleSpeedY);
            this.GroupBox_AngleSpeed.Controls.Add(this.Lab_Val_AngleSpeedX);
            this.GroupBox_AngleSpeed.ForeColor = System.Drawing.Color.Blue;
            this.GroupBox_AngleSpeed.Location = new System.Drawing.Point(10, 558);
            this.GroupBox_AngleSpeed.Name = "GroupBox_AngleSpeed";
            this.GroupBox_AngleSpeed.Size = new System.Drawing.Size(265, 194);
            this.GroupBox_AngleSpeed.TabIndex = 43;
            this.GroupBox_AngleSpeed.TabStop = false;
            this.GroupBox_AngleSpeed.Text = "三轴角速度";
            // 
            // GroupBox_Temperature
            // 
            this.GroupBox_Temperature.Controls.Add(this.Lab_Temperature);
            this.GroupBox_Temperature.Controls.Add(this.Lab_Val_Temperature);
            this.GroupBox_Temperature.Location = new System.Drawing.Point(1119, 300);
            this.GroupBox_Temperature.Name = "GroupBox_Temperature";
            this.GroupBox_Temperature.Size = new System.Drawing.Size(146, 82);
            this.GroupBox_Temperature.TabIndex = 44;
            this.GroupBox_Temperature.TabStop = false;
            this.GroupBox_Temperature.Text = "温度";
            // 
            // VertProgressBar_Pressure
            // 
            this.VertProgressBar_Pressure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.VertProgressBar_Pressure.DrawLabel = true;
            this.VertProgressBar_Pressure.Label = null;
            this.VertProgressBar_Pressure.Location = new System.Drawing.Point(7, 69);
            this.VertProgressBar_Pressure.maxline = 0;
            this.VertProgressBar_Pressure.minline = 0;
            this.VertProgressBar_Pressure.Name = "VertProgressBar_Pressure";
            this.VertProgressBar_Pressure.Size = new System.Drawing.Size(55, 153);
            this.VertProgressBar_Pressure.TabIndex = 18;
            this.VertProgressBar_Pressure.Value = 40;
            // 
            // VertProgressBar_Depth
            // 
            this.VertProgressBar_Depth.DrawLabel = true;
            this.VertProgressBar_Depth.Label = null;
            this.VertProgressBar_Depth.Location = new System.Drawing.Point(68, 69);
            this.VertProgressBar_Depth.maxline = 0;
            this.VertProgressBar_Depth.minline = 0;
            this.VertProgressBar_Depth.Name = "VertProgressBar_Depth";
            this.VertProgressBar_Depth.Size = new System.Drawing.Size(54, 153);
            this.VertProgressBar_Depth.TabIndex = 47;
            this.VertProgressBar_Depth.Value = 60;
            // 
            // GroupBox_Acceleration
            // 
            this.GroupBox_Acceleration.Controls.Add(this.Lab_Val_AccelerationZ);
            this.GroupBox_Acceleration.Controls.Add(this.Lab_AccelerationY);
            this.GroupBox_Acceleration.Controls.Add(this.Lab_AccelerationX);
            this.GroupBox_Acceleration.Controls.Add(this.Lab_AccelerationZ);
            this.GroupBox_Acceleration.Controls.Add(this.Lab_Val_AccelerationY);
            this.GroupBox_Acceleration.Controls.Add(this.Lab_Val_AccelerationX);
            this.GroupBox_Acceleration.ForeColor = System.Drawing.Color.Chocolate;
            this.GroupBox_Acceleration.Location = new System.Drawing.Point(10, 359);
            this.GroupBox_Acceleration.Name = "GroupBox_Acceleration";
            this.GroupBox_Acceleration.Size = new System.Drawing.Size(263, 186);
            this.GroupBox_Acceleration.TabIndex = 48;
            this.GroupBox_Acceleration.TabStop = false;
            this.GroupBox_Acceleration.Text = "三轴加速度";
            // 
            // Lab_Val_AccelerationZ
            // 
            this.Lab_Val_AccelerationZ.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Lab_Val_AccelerationZ.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Val_AccelerationZ.Location = new System.Drawing.Point(90, 130);
            this.Lab_Val_AccelerationZ.Name = "Lab_Val_AccelerationZ";
            this.Lab_Val_AccelerationZ.Size = new System.Drawing.Size(167, 45);
            this.Lab_Val_AccelerationZ.TabIndex = 18;
            this.Lab_Val_AccelerationZ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Lab_AccelerationY
            // 
            this.Lab_AccelerationY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Lab_AccelerationY.Font = new System.Drawing.Font("黑体", 10.7F, System.Drawing.FontStyle.Bold);
            this.Lab_AccelerationY.Location = new System.Drawing.Point(6, 75);
            this.Lab_AccelerationY.Name = "Lab_AccelerationY";
            this.Lab_AccelerationY.Size = new System.Drawing.Size(70, 45);
            this.Lab_AccelerationY.TabIndex = 3;
            this.Lab_AccelerationY.Text = " Y轴   加速度";
            this.Lab_AccelerationY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lab_AccelerationX
            // 
            this.Lab_AccelerationX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Lab_AccelerationX.Font = new System.Drawing.Font("黑体", 10.7F, System.Drawing.FontStyle.Bold);
            this.Lab_AccelerationX.Location = new System.Drawing.Point(7, 21);
            this.Lab_AccelerationX.Name = "Lab_AccelerationX";
            this.Lab_AccelerationX.Size = new System.Drawing.Size(70, 45);
            this.Lab_AccelerationX.TabIndex = 4;
            this.Lab_AccelerationX.Text = " X轴   加速度";
            this.Lab_AccelerationX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lab_AccelerationZ
            // 
            this.Lab_AccelerationZ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Lab_AccelerationZ.Font = new System.Drawing.Font("黑体", 10.7F, System.Drawing.FontStyle.Bold);
            this.Lab_AccelerationZ.Location = new System.Drawing.Point(6, 130);
            this.Lab_AccelerationZ.Name = "Lab_AccelerationZ";
            this.Lab_AccelerationZ.Size = new System.Drawing.Size(70, 45);
            this.Lab_AccelerationZ.TabIndex = 8;
            this.Lab_AccelerationZ.Text = " Z轴   加速度";
            this.Lab_AccelerationZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lab_Val_AccelerationY
            // 
            this.Lab_Val_AccelerationY.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Lab_Val_AccelerationY.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Val_AccelerationY.Location = new System.Drawing.Point(90, 75);
            this.Lab_Val_AccelerationY.Name = "Lab_Val_AccelerationY";
            this.Lab_Val_AccelerationY.Size = new System.Drawing.Size(167, 45);
            this.Lab_Val_AccelerationY.TabIndex = 11;
            this.Lab_Val_AccelerationY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Lab_Val_AccelerationX
            // 
            this.Lab_Val_AccelerationX.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Lab_Val_AccelerationX.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Val_AccelerationX.Location = new System.Drawing.Point(90, 21);
            this.Lab_Val_AccelerationX.Name = "Lab_Val_AccelerationX";
            this.Lab_Val_AccelerationX.Size = new System.Drawing.Size(167, 45);
            this.Lab_Val_AccelerationX.TabIndex = 12;
            this.Lab_Val_AccelerationX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GroupBox_压力深度
            // 
            this.GroupBox_压力深度.Controls.Add(this.Lab_Depth);
            this.GroupBox_压力深度.Controls.Add(this.Lab_Pressure);
            this.GroupBox_压力深度.Controls.Add(this.VertProgressBar_Pressure);
            this.GroupBox_压力深度.Controls.Add(this.VertProgressBar_Depth);
            this.GroupBox_压力深度.ForeColor = System.Drawing.Color.Blue;
            this.GroupBox_压力深度.Location = new System.Drawing.Point(1217, 44);
            this.GroupBox_压力深度.Name = "GroupBox_压力深度";
            this.GroupBox_压力深度.Size = new System.Drawing.Size(135, 230);
            this.GroupBox_压力深度.TabIndex = 50;
            this.GroupBox_压力深度.TabStop = false;
            this.GroupBox_压力深度.Text = "压力深度条";
            // 
            // RadBtn_FreeMode
            // 
            this.RadBtn_FreeMode.AutoSize = true;
            this.RadBtn_FreeMode.Font = new System.Drawing.Font("幼圆", 10F, System.Drawing.FontStyle.Bold);
            this.RadBtn_FreeMode.Location = new System.Drawing.Point(6, 26);
            this.RadBtn_FreeMode.Name = "RadBtn_FreeMode";
            this.RadBtn_FreeMode.Size = new System.Drawing.Size(143, 21);
            this.RadBtn_FreeMode.TabIndex = 56;
            this.RadBtn_FreeMode.TabStop = true;
            this.RadBtn_FreeMode.Text = "自由操控模式";
            this.RadBtn_FreeMode.UseVisualStyleBackColor = true;
            this.RadBtn_FreeMode.CheckedChanged += new System.EventHandler(this.RadBtn_FreeMode_CheckedChanged);
            // 
            // RadBtn_PIDMode
            // 
            this.RadBtn_PIDMode.AutoSize = true;
            this.RadBtn_PIDMode.Font = new System.Drawing.Font("幼圆", 10F, System.Drawing.FontStyle.Bold);
            this.RadBtn_PIDMode.Location = new System.Drawing.Point(6, 64);
            this.RadBtn_PIDMode.Name = "RadBtn_PIDMode";
            this.RadBtn_PIDMode.Size = new System.Drawing.Size(173, 21);
            this.RadBtn_PIDMode.TabIndex = 57;
            this.RadBtn_PIDMode.TabStop = true;
            this.RadBtn_PIDMode.Text = "PID闭环控制模式";
            this.RadBtn_PIDMode.UseVisualStyleBackColor = true;
            this.RadBtn_PIDMode.CheckedChanged += new System.EventHandler(this.RadBtn_PIDMode_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RadBtn_ObjectTrack);
            this.groupBox1.Controls.Add(this.Lab_ControlMode);
            this.groupBox1.Controls.Add(this.RadBtn_PIDMode);
            this.groupBox1.Controls.Add(this.RadBtn_FreeMode);
            this.groupBox1.Location = new System.Drawing.Point(1122, 399);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 198);
            this.groupBox1.TabIndex = 58;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "控制模式选择";
            // 
            // RadBtn_ObjectTrack
            // 
            this.RadBtn_ObjectTrack.AutoSize = true;
            this.RadBtn_ObjectTrack.Font = new System.Drawing.Font("幼圆", 10F, System.Drawing.FontStyle.Bold);
            this.RadBtn_ObjectTrack.Location = new System.Drawing.Point(6, 101);
            this.RadBtn_ObjectTrack.Name = "RadBtn_ObjectTrack";
            this.RadBtn_ObjectTrack.Size = new System.Drawing.Size(105, 21);
            this.RadBtn_ObjectTrack.TabIndex = 59;
            this.RadBtn_ObjectTrack.TabStop = true;
            this.RadBtn_ObjectTrack.Text = "对象追踪";
            this.RadBtn_ObjectTrack.UseVisualStyleBackColor = true;
            this.RadBtn_ObjectTrack.CheckedChanged += new System.EventHandler(this.RadBtn_ObjectTrack_CheckedChanged);
            // 
            // Lab_ControlMode
            // 
            this.Lab_ControlMode.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Lab_ControlMode.Font = new System.Drawing.Font("楷体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lab_ControlMode.ForeColor = System.Drawing.Color.Red;
            this.Lab_ControlMode.Location = new System.Drawing.Point(6, 137);
            this.Lab_ControlMode.Name = "Lab_ControlMode";
            this.Lab_ControlMode.Size = new System.Drawing.Size(192, 43);
            this.Lab_ControlMode.TabIndex = 58;
            this.Lab_ControlMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Hud
            // 
            this.Hud.airspeed = 0F;
            this.Hud.alt = 0F;
            this.Hud.altunit = null;
            this.Hud.AOA = 0F;
            this.Hud.BackColor = System.Drawing.Color.Black;
            this.Hud.batterylevel = 0F;
            this.Hud.batteryremaining = 0F;
            this.Hud.bgimage = null;
            this.Hud.connected = false;
            this.Hud.critAOA = 25F;
            this.Hud.critSSA = 30F;
            this.Hud.current = 0F;
            this.Hud.datetime = new System.DateTime(((long)(0)));
            this.Hud.displayAOASSA = false;
            this.Hud.disttowp = 0F;
            this.Hud.distunit = null;
            this.Hud.ekfstatus = 0F;
            this.Hud.failsafe = false;
            this.Hud.gpsfix = 0F;
            this.Hud.gpsfix2 = 0F;
            this.Hud.gpshdop = 0F;
            this.Hud.gpshdop2 = 0F;
            this.Hud.groundalt = 0F;
            this.Hud.groundColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(184)))), ((int)(((byte)(36)))));
            this.Hud.groundColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(79)))), ((int)(((byte)(7)))));
            this.Hud.groundcourse = 0F;
            this.Hud.groundspeed = 0F;
            this.Hud.heading = 0F;
            this.Hud.hudcolor = System.Drawing.Color.LightGray;
            this.Hud.linkqualitygcs = 0F;
            this.Hud.Location = new System.Drawing.Point(666, 29);
            this.Hud.lowairspeed = false;
            this.Hud.lowgroundspeed = false;
            this.Hud.lowvoltagealert = false;
            this.Hud.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Hud.message = null;
            this.Hud.messagetime = new System.DateTime(((long)(0)));
            this.Hud.mode = "Manual";
            this.Hud.Name = "Hud";
            this.Hud.navpitch = 0F;
            this.Hud.navroll = 0F;
            this.Hud.pitch = 0F;
            this.Hud.roll = 0F;
            this.Hud.Russian = false;
            this.Hud.Size = new System.Drawing.Size(435, 219);
            this.Hud.skyColor1 = System.Drawing.Color.Blue;
            this.Hud.skyColor2 = System.Drawing.Color.LightBlue;
            this.Hud.speedunit = null;
            this.Hud.SSA = 0F;
            this.Hud.status = false;
            this.Hud.streamjpg = ((System.IO.MemoryStream)(resources.GetObject("Hud.streamjpg")));
            this.Hud.TabIndex = 59;
            this.Hud.targetalt = 0F;
            this.Hud.targetheading = 0F;
            this.Hud.targetspeed = 0F;
            this.Hud.turnrate = 0F;
            this.Hud.verticalspeed = 0F;
            this.Hud.vibex = 0F;
            this.Hud.vibey = 0F;
            this.Hud.vibez = 0F;
            this.Hud.VSync = false;
            this.Hud.wpno = 0;
            this.Hud.xtrack_error = 0F;
            // 
            // Btn_HeadUp
            // 
            this.Btn_HeadUp.Location = new System.Drawing.Point(1119, 63);
            this.Btn_HeadUp.Name = "Btn_HeadUp";
            this.Btn_HeadUp.Size = new System.Drawing.Size(65, 48);
            this.Btn_HeadUp.TabIndex = 60;
            this.Btn_HeadUp.Text = "云台升";
            this.Btn_HeadUp.UseVisualStyleBackColor = true;
            this.Btn_HeadUp.Click += new System.EventHandler(this.Btn_HeadUp_Click);
            // 
            // Btn_HeadDown
            // 
            this.Btn_HeadDown.Location = new System.Drawing.Point(1119, 129);
            this.Btn_HeadDown.Name = "Btn_HeadDown";
            this.Btn_HeadDown.Size = new System.Drawing.Size(65, 48);
            this.Btn_HeadDown.TabIndex = 61;
            this.Btn_HeadDown.Text = "云台降";
            this.Btn_HeadDown.UseVisualStyleBackColor = true;
            this.Btn_HeadDown.Click += new System.EventHandler(this.Btn_HeadDown_Click);
            // 
            // Btn_KeyPressE
            // 
            this.Btn_KeyPressE.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Btn_KeyPressE.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_KeyPressE.Location = new System.Drawing.Point(163, 12);
            this.Btn_KeyPressE.Name = "Btn_KeyPressE";
            this.Btn_KeyPressE.Size = new System.Drawing.Size(80, 80);
            this.Btn_KeyPressE.TabIndex = 62;
            this.Btn_KeyPressE.Text = "E";
            this.Btn_KeyPressE.UseVisualStyleBackColor = false;
            // 
            // Btn_KeyPressQ
            // 
            this.Btn_KeyPressQ.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Btn_KeyPressQ.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_KeyPressQ.Location = new System.Drawing.Point(3, 12);
            this.Btn_KeyPressQ.Name = "Btn_KeyPressQ";
            this.Btn_KeyPressQ.Size = new System.Drawing.Size(80, 80);
            this.Btn_KeyPressQ.TabIndex = 63;
            this.Btn_KeyPressQ.Text = "Q";
            this.Btn_KeyPressQ.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1371, 790);
            this.Controls.Add(this.Btn_HeadDown);
            this.Controls.Add(this.Btn_HeadUp);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Hud);
            this.Controls.Add(this.GroupBox_Acceleration);
            this.Controls.Add(this.GroupBox_压力深度);
            this.Controls.Add(this.GroupBox_Temperature);
            this.Controls.Add(this.PicBox_Video);
            this.Controls.Add(this.GroupBox_AngleSpeed);
            this.Controls.Add(this.GroupBox_Command);
            this.Controls.Add(this.GroupBox_KeyBoard);
            this.Controls.Add(this.GroupBox_Init);
            this.Controls.Add(this.menuStrip_设置);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip_设置;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ROV上位机";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.GroupBox_Init.ResumeLayout(false);
            this.GroupBox_Init.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicBox_Video)).EndInit();
            this.GroupBox_KeyBoard.ResumeLayout(false);
            this.GroupBox_Command.ResumeLayout(false);
            this.menuStrip_设置.ResumeLayout(false);
            this.menuStrip_设置.PerformLayout();
            this.GroupBox_AngleSpeed.ResumeLayout(false);
            this.GroupBox_Temperature.ResumeLayout(false);
            this.GroupBox_Acceleration.ResumeLayout(false);
            this.GroupBox_压力深度.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox GroupBox_Init;
        private System.Windows.Forms.TextBox Txt_Info;
        private System.Windows.Forms.Label Lab_Flag;
        private System.Windows.Forms.Button Btn_Start;
        private System.Windows.Forms.Button Btn_Stop;
        private System.Windows.Forms.Button Btn_Send;
        private System.Windows.Forms.Button Btn_Parameter;
        private System.Windows.Forms.Button Btn_Open;
        private System.Windows.Forms.Label Lab_Pressure;
        private System.Windows.Forms.Label Lab_Val_Pressure;
        private System.Windows.Forms.Label Lab_AngleSpeedY;
        private System.Windows.Forms.Label Lab_AngleSpeedX;
        private System.Windows.Forms.Label Lab_AngleSpeedZ;
        private System.Windows.Forms.Label Lab_Temperature;
        private System.Windows.Forms.Label Lab_Depth;
        private System.Windows.Forms.Label Lab_Val_AngleSpeedY;
        private System.Windows.Forms.Label Lab_Val_AngleSpeedX;
        private System.Windows.Forms.Label Lab_Val_Temperature;
        private System.Windows.Forms.Label Lab_Val_Depth;
        private System.Windows.Forms.Label Lab_Val_AngleSpeedZ;
        public System.Windows.Forms.PictureBox PicBox_Video;
        private System.Windows.Forms.Button Btn_TurnLeft;
        private System.Windows.Forms.Button Btn_Down;
        private System.Windows.Forms.Button Btn_Hover;
        private System.Windows.Forms.Button Btn_SpeedLv3;
        private System.Windows.Forms.Button Btn_SpeedLv2;
        private System.Windows.Forms.Button Btn_SpeedLv1;
        private System.Windows.Forms.Button Btn_TurnRight;
        private System.Windows.Forms.Button Btn_Up;
        private System.Windows.Forms.GroupBox GroupBox_KeyBoard;
        private System.Windows.Forms.Button Btn_KeyPressW;
        private System.Windows.Forms.Button Btn_KeyPressA;
        private System.Windows.Forms.Button Btn_KeyPressS;
        private System.Windows.Forms.Button Btn_KeyPressD;
        private System.IO.Ports.SerialPort MySerialPort;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox GroupBox_Command;
        private System.Windows.Forms.MenuStrip menuStrip_设置;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 视频传输设置ToolStripMenuItem;
        private System.Windows.Forms.Timer Timer_UpdateData;
        private System.Windows.Forms.GroupBox GroupBox_AngleSpeed;
        private System.Windows.Forms.GroupBox GroupBox_Temperature;
        private MissionPlanner.Controls.VerticalProgressBar VertProgressBar_Pressure;
        private MissionPlanner.Controls.VerticalProgressBar VertProgressBar_Depth;
        private System.Windows.Forms.GroupBox GroupBox_Acceleration;
        private System.Windows.Forms.Label Lab_Val_AccelerationZ;
        private System.Windows.Forms.Label Lab_AccelerationY;
        private System.Windows.Forms.Label Lab_AccelerationX;
        private System.Windows.Forms.Label Lab_AccelerationZ;
        private System.Windows.Forms.Label Lab_Val_AccelerationY;
        private System.Windows.Forms.Label Lab_Val_AccelerationX;
        private System.Windows.Forms.GroupBox GroupBox_压力深度;
        private System.Windows.Forms.ToolStripMenuItem PID系数设置ToolStripMenuItem;
        private System.Windows.Forms.Button Btn_Servo;
        private System.Windows.Forms.RadioButton RadBtn_FreeMode;
        private System.Windows.Forms.RadioButton RadBtn_PIDMode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Lab_ControlMode;
        private MissionPlanner.Controls.HUD Hud;
        private System.Windows.Forms.Button Btn_HeadUp;
        private System.Windows.Forms.Button Btn_HeadDown;
        private System.Windows.Forms.RadioButton RadBtn_ObjectTrack;
        private System.Windows.Forms.Button Btn_KeyPressE;
        private System.Windows.Forms.Button Btn_KeyPressQ;
    }
}

