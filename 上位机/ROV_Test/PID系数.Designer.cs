namespace ROV_Test
{
    partial class PID系数
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Lab_Depth_Kp = new System.Windows.Forms.Label();
            this.Txt_Depth_Kp = new System.Windows.Forms.TextBox();
            this.Lab_Depth_Kd = new System.Windows.Forms.Label();
            this.Lab_Depth_Ki = new System.Windows.Forms.Label();
            this.Txt_Depth_Kd = new System.Windows.Forms.TextBox();
            this.Txt_Depth_Ki = new System.Windows.Forms.TextBox();
            this.GroupBox_Depth_PID = new System.Windows.Forms.GroupBox();
            this.Txt_Depth_Target = new System.Windows.Forms.TextBox();
            this.Lab_Depth_Target = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Txt_AccelerationY_Target = new System.Windows.Forms.TextBox();
            this.Lab_AccelerationY_Target = new System.Windows.Forms.Label();
            this.Txt_AccelerationY_Ki = new System.Windows.Forms.TextBox();
            this.Txt_AccelerationY_Kd = new System.Windows.Forms.TextBox();
            this.Lab_AccelerationY_Ki = new System.Windows.Forms.Label();
            this.Lab_AccelerationY_Kd = new System.Windows.Forms.Label();
            this.Txt_AccelerationY_Kp = new System.Windows.Forms.TextBox();
            this.Lab_AccelerationY_Kp = new System.Windows.Forms.Label();
            this.GroupBox_Pitch_PID = new System.Windows.Forms.GroupBox();
            this.Txt_Pitch_Target = new System.Windows.Forms.TextBox();
            this.Lab_Pitch_Target = new System.Windows.Forms.Label();
            this.Txt_Pitch_Ki = new System.Windows.Forms.TextBox();
            this.Txt_Pitch_Kd = new System.Windows.Forms.TextBox();
            this.Lab_Pitch_Ki = new System.Windows.Forms.Label();
            this.Lab_Pitch_Kd = new System.Windows.Forms.Label();
            this.Txt_Pitch_Kp = new System.Windows.Forms.TextBox();
            this.Lab_Pitch_Kp = new System.Windows.Forms.Label();
            this.GroupBox_Yaw_PID = new System.Windows.Forms.GroupBox();
            this.Txt_AngleSpeedY_Target = new System.Windows.Forms.TextBox();
            this.Lab_Yaw_Target = new System.Windows.Forms.Label();
            this.Txt_AngleSpeedY_Ki = new System.Windows.Forms.TextBox();
            this.Txt_AngleSpeedY_Kd = new System.Windows.Forms.TextBox();
            this.Lab_Yaw_Ki = new System.Windows.Forms.Label();
            this.Lab_Yaw_Kd = new System.Windows.Forms.Label();
            this.Txt_AngleSpeedY_Kp = new System.Windows.Forms.TextBox();
            this.Lab__Kp = new System.Windows.Forms.Label();
            this.Btn_Preservation = new System.Windows.Forms.Button();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RadBtn_None = new System.Windows.Forms.RadioButton();
            this.RadBtn_AngleSpeedY = new System.Windows.Forms.RadioButton();
            this.RadBtn_Pitch = new System.Windows.Forms.RadioButton();
            this.RadBtn_Depth = new System.Windows.Forms.RadioButton();
            this.ChkBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GroupBox_Depth_PID.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.GroupBox_Pitch_PID.SuspendLayout();
            this.GroupBox_Yaw_PID.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lab_Depth_Kp
            // 
            this.Lab_Depth_Kp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Lab_Depth_Kp.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.Lab_Depth_Kp.Location = new System.Drawing.Point(13, 25);
            this.Lab_Depth_Kp.Name = "Lab_Depth_Kp";
            this.Lab_Depth_Kp.Size = new System.Drawing.Size(145, 40);
            this.Lab_Depth_Kp.TabIndex = 0;
            this.Lab_Depth_Kp.Text = "深度—Kp";
            this.Lab_Depth_Kp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Txt_Depth_Kp
            // 
            this.Txt_Depth_Kp.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_Depth_Kp.Location = new System.Drawing.Point(163, 25);
            this.Txt_Depth_Kp.Multiline = true;
            this.Txt_Depth_Kp.Name = "Txt_Depth_Kp";
            this.Txt_Depth_Kp.Size = new System.Drawing.Size(108, 40);
            this.Txt_Depth_Kp.TabIndex = 1;
            this.Txt_Depth_Kp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Lab_Depth_Kd
            // 
            this.Lab_Depth_Kd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Lab_Depth_Kd.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.Lab_Depth_Kd.Location = new System.Drawing.Point(13, 129);
            this.Lab_Depth_Kd.Name = "Lab_Depth_Kd";
            this.Lab_Depth_Kd.Size = new System.Drawing.Size(145, 40);
            this.Lab_Depth_Kd.TabIndex = 9;
            this.Lab_Depth_Kd.Text = "深度—Kd";
            this.Lab_Depth_Kd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lab_Depth_Ki
            // 
            this.Lab_Depth_Ki.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Lab_Depth_Ki.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.Lab_Depth_Ki.Location = new System.Drawing.Point(13, 78);
            this.Lab_Depth_Ki.Name = "Lab_Depth_Ki";
            this.Lab_Depth_Ki.Size = new System.Drawing.Size(145, 40);
            this.Lab_Depth_Ki.TabIndex = 10;
            this.Lab_Depth_Ki.Text = "深度—Ki";
            this.Lab_Depth_Ki.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Txt_Depth_Kd
            // 
            this.Txt_Depth_Kd.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_Depth_Kd.Location = new System.Drawing.Point(163, 129);
            this.Txt_Depth_Kd.Multiline = true;
            this.Txt_Depth_Kd.Name = "Txt_Depth_Kd";
            this.Txt_Depth_Kd.Size = new System.Drawing.Size(108, 40);
            this.Txt_Depth_Kd.TabIndex = 17;
            this.Txt_Depth_Kd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Txt_Depth_Ki
            // 
            this.Txt_Depth_Ki.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_Depth_Ki.Location = new System.Drawing.Point(163, 78);
            this.Txt_Depth_Ki.Multiline = true;
            this.Txt_Depth_Ki.Name = "Txt_Depth_Ki";
            this.Txt_Depth_Ki.Size = new System.Drawing.Size(108, 40);
            this.Txt_Depth_Ki.TabIndex = 18;
            this.Txt_Depth_Ki.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GroupBox_Depth_PID
            // 
            this.GroupBox_Depth_PID.Controls.Add(this.Txt_Depth_Target);
            this.GroupBox_Depth_PID.Controls.Add(this.Lab_Depth_Target);
            this.GroupBox_Depth_PID.Controls.Add(this.Txt_Depth_Ki);
            this.GroupBox_Depth_PID.Controls.Add(this.Txt_Depth_Kd);
            this.GroupBox_Depth_PID.Controls.Add(this.Lab_Depth_Ki);
            this.GroupBox_Depth_PID.Controls.Add(this.Lab_Depth_Kd);
            this.GroupBox_Depth_PID.Controls.Add(this.Txt_Depth_Kp);
            this.GroupBox_Depth_PID.Controls.Add(this.Lab_Depth_Kp);
            this.GroupBox_Depth_PID.Location = new System.Drawing.Point(23, 30);
            this.GroupBox_Depth_PID.Name = "GroupBox_Depth_PID";
            this.GroupBox_Depth_PID.Size = new System.Drawing.Size(278, 232);
            this.GroupBox_Depth_PID.TabIndex = 19;
            this.GroupBox_Depth_PID.TabStop = false;
            this.GroupBox_Depth_PID.Text = "深度PID系数";
            // 
            // Txt_Depth_Target
            // 
            this.Txt_Depth_Target.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_Depth_Target.Location = new System.Drawing.Point(163, 181);
            this.Txt_Depth_Target.Multiline = true;
            this.Txt_Depth_Target.Name = "Txt_Depth_Target";
            this.Txt_Depth_Target.Size = new System.Drawing.Size(108, 40);
            this.Txt_Depth_Target.TabIndex = 20;
            this.Txt_Depth_Target.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Lab_Depth_Target
            // 
            this.Lab_Depth_Target.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Lab_Depth_Target.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.Lab_Depth_Target.Location = new System.Drawing.Point(13, 181);
            this.Lab_Depth_Target.Name = "Lab_Depth_Target";
            this.Lab_Depth_Target.Size = new System.Drawing.Size(145, 40);
            this.Lab_Depth_Target.TabIndex = 19;
            this.Lab_Depth_Target.Text = "深度设定值";
            this.Lab_Depth_Target.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Txt_AccelerationY_Target);
            this.groupBox1.Controls.Add(this.Lab_AccelerationY_Target);
            this.groupBox1.Controls.Add(this.Txt_AccelerationY_Ki);
            this.groupBox1.Controls.Add(this.Txt_AccelerationY_Kd);
            this.groupBox1.Controls.Add(this.Lab_AccelerationY_Ki);
            this.groupBox1.Controls.Add(this.Lab_AccelerationY_Kd);
            this.groupBox1.Controls.Add(this.Txt_AccelerationY_Kp);
            this.groupBox1.Controls.Add(this.Lab_AccelerationY_Kp);
            this.groupBox1.Location = new System.Drawing.Point(307, 268);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 232);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Y轴加速度PID系数";
            // 
            // Txt_AccelerationY_Target
            // 
            this.Txt_AccelerationY_Target.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_AccelerationY_Target.Location = new System.Drawing.Point(163, 181);
            this.Txt_AccelerationY_Target.Multiline = true;
            this.Txt_AccelerationY_Target.Name = "Txt_AccelerationY_Target";
            this.Txt_AccelerationY_Target.Size = new System.Drawing.Size(108, 40);
            this.Txt_AccelerationY_Target.TabIndex = 20;
            this.Txt_AccelerationY_Target.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Lab_AccelerationY_Target
            // 
            this.Lab_AccelerationY_Target.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.Lab_AccelerationY_Target.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.Lab_AccelerationY_Target.Location = new System.Drawing.Point(13, 181);
            this.Lab_AccelerationY_Target.Name = "Lab_AccelerationY_Target";
            this.Lab_AccelerationY_Target.Size = new System.Drawing.Size(145, 40);
            this.Lab_AccelerationY_Target.TabIndex = 19;
            this.Lab_AccelerationY_Target.Text = "Y轴加速度设定值";
            this.Lab_AccelerationY_Target.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Txt_AccelerationY_Ki
            // 
            this.Txt_AccelerationY_Ki.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_AccelerationY_Ki.Location = new System.Drawing.Point(163, 78);
            this.Txt_AccelerationY_Ki.Multiline = true;
            this.Txt_AccelerationY_Ki.Name = "Txt_AccelerationY_Ki";
            this.Txt_AccelerationY_Ki.Size = new System.Drawing.Size(108, 40);
            this.Txt_AccelerationY_Ki.TabIndex = 18;
            this.Txt_AccelerationY_Ki.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Txt_AccelerationY_Kd
            // 
            this.Txt_AccelerationY_Kd.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_AccelerationY_Kd.Location = new System.Drawing.Point(163, 129);
            this.Txt_AccelerationY_Kd.Multiline = true;
            this.Txt_AccelerationY_Kd.Name = "Txt_AccelerationY_Kd";
            this.Txt_AccelerationY_Kd.Size = new System.Drawing.Size(108, 40);
            this.Txt_AccelerationY_Kd.TabIndex = 17;
            this.Txt_AccelerationY_Kd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Lab_AccelerationY_Ki
            // 
            this.Lab_AccelerationY_Ki.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.Lab_AccelerationY_Ki.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.Lab_AccelerationY_Ki.Location = new System.Drawing.Point(13, 78);
            this.Lab_AccelerationY_Ki.Name = "Lab_AccelerationY_Ki";
            this.Lab_AccelerationY_Ki.Size = new System.Drawing.Size(145, 40);
            this.Lab_AccelerationY_Ki.TabIndex = 10;
            this.Lab_AccelerationY_Ki.Text = "Y轴加速度—Ki";
            this.Lab_AccelerationY_Ki.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lab_AccelerationY_Kd
            // 
            this.Lab_AccelerationY_Kd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.Lab_AccelerationY_Kd.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.Lab_AccelerationY_Kd.Location = new System.Drawing.Point(13, 129);
            this.Lab_AccelerationY_Kd.Name = "Lab_AccelerationY_Kd";
            this.Lab_AccelerationY_Kd.Size = new System.Drawing.Size(145, 40);
            this.Lab_AccelerationY_Kd.TabIndex = 9;
            this.Lab_AccelerationY_Kd.Text = "Y轴加速度—Kd";
            this.Lab_AccelerationY_Kd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Txt_AccelerationY_Kp
            // 
            this.Txt_AccelerationY_Kp.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_AccelerationY_Kp.Location = new System.Drawing.Point(163, 25);
            this.Txt_AccelerationY_Kp.Multiline = true;
            this.Txt_AccelerationY_Kp.Name = "Txt_AccelerationY_Kp";
            this.Txt_AccelerationY_Kp.Size = new System.Drawing.Size(108, 40);
            this.Txt_AccelerationY_Kp.TabIndex = 1;
            this.Txt_AccelerationY_Kp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Lab_AccelerationY_Kp
            // 
            this.Lab_AccelerationY_Kp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.Lab_AccelerationY_Kp.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.Lab_AccelerationY_Kp.Location = new System.Drawing.Point(13, 25);
            this.Lab_AccelerationY_Kp.Name = "Lab_AccelerationY_Kp";
            this.Lab_AccelerationY_Kp.Size = new System.Drawing.Size(145, 40);
            this.Lab_AccelerationY_Kp.TabIndex = 0;
            this.Lab_AccelerationY_Kp.Text = "Y轴加速度—Kp";
            this.Lab_AccelerationY_Kp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GroupBox_Pitch_PID
            // 
            this.GroupBox_Pitch_PID.Controls.Add(this.Txt_Pitch_Target);
            this.GroupBox_Pitch_PID.Controls.Add(this.Lab_Pitch_Target);
            this.GroupBox_Pitch_PID.Controls.Add(this.Txt_Pitch_Ki);
            this.GroupBox_Pitch_PID.Controls.Add(this.Txt_Pitch_Kd);
            this.GroupBox_Pitch_PID.Controls.Add(this.Lab_Pitch_Ki);
            this.GroupBox_Pitch_PID.Controls.Add(this.Lab_Pitch_Kd);
            this.GroupBox_Pitch_PID.Controls.Add(this.Txt_Pitch_Kp);
            this.GroupBox_Pitch_PID.Controls.Add(this.Lab_Pitch_Kp);
            this.GroupBox_Pitch_PID.Location = new System.Drawing.Point(307, 30);
            this.GroupBox_Pitch_PID.Name = "GroupBox_Pitch_PID";
            this.GroupBox_Pitch_PID.Size = new System.Drawing.Size(278, 232);
            this.GroupBox_Pitch_PID.TabIndex = 20;
            this.GroupBox_Pitch_PID.TabStop = false;
            this.GroupBox_Pitch_PID.Text = "俯仰角PID系数";
            // 
            // Txt_Pitch_Target
            // 
            this.Txt_Pitch_Target.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_Pitch_Target.Location = new System.Drawing.Point(163, 181);
            this.Txt_Pitch_Target.Multiline = true;
            this.Txt_Pitch_Target.Name = "Txt_Pitch_Target";
            this.Txt_Pitch_Target.Size = new System.Drawing.Size(108, 40);
            this.Txt_Pitch_Target.TabIndex = 20;
            this.Txt_Pitch_Target.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Lab_Pitch_Target
            // 
            this.Lab_Pitch_Target.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Lab_Pitch_Target.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.Lab_Pitch_Target.Location = new System.Drawing.Point(13, 181);
            this.Lab_Pitch_Target.Name = "Lab_Pitch_Target";
            this.Lab_Pitch_Target.Size = new System.Drawing.Size(145, 40);
            this.Lab_Pitch_Target.TabIndex = 19;
            this.Lab_Pitch_Target.Text = "俯仰角设定值";
            this.Lab_Pitch_Target.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Txt_Pitch_Ki
            // 
            this.Txt_Pitch_Ki.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_Pitch_Ki.Location = new System.Drawing.Point(163, 78);
            this.Txt_Pitch_Ki.Multiline = true;
            this.Txt_Pitch_Ki.Name = "Txt_Pitch_Ki";
            this.Txt_Pitch_Ki.Size = new System.Drawing.Size(108, 40);
            this.Txt_Pitch_Ki.TabIndex = 18;
            this.Txt_Pitch_Ki.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Txt_Pitch_Kd
            // 
            this.Txt_Pitch_Kd.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_Pitch_Kd.Location = new System.Drawing.Point(163, 129);
            this.Txt_Pitch_Kd.Multiline = true;
            this.Txt_Pitch_Kd.Name = "Txt_Pitch_Kd";
            this.Txt_Pitch_Kd.Size = new System.Drawing.Size(108, 40);
            this.Txt_Pitch_Kd.TabIndex = 17;
            this.Txt_Pitch_Kd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Lab_Pitch_Ki
            // 
            this.Lab_Pitch_Ki.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Lab_Pitch_Ki.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.Lab_Pitch_Ki.Location = new System.Drawing.Point(13, 78);
            this.Lab_Pitch_Ki.Name = "Lab_Pitch_Ki";
            this.Lab_Pitch_Ki.Size = new System.Drawing.Size(145, 40);
            this.Lab_Pitch_Ki.TabIndex = 10;
            this.Lab_Pitch_Ki.Text = "俯仰角—Ki";
            this.Lab_Pitch_Ki.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lab_Pitch_Kd
            // 
            this.Lab_Pitch_Kd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Lab_Pitch_Kd.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.Lab_Pitch_Kd.Location = new System.Drawing.Point(13, 129);
            this.Lab_Pitch_Kd.Name = "Lab_Pitch_Kd";
            this.Lab_Pitch_Kd.Size = new System.Drawing.Size(145, 40);
            this.Lab_Pitch_Kd.TabIndex = 9;
            this.Lab_Pitch_Kd.Text = "俯仰角—Kd";
            this.Lab_Pitch_Kd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Txt_Pitch_Kp
            // 
            this.Txt_Pitch_Kp.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_Pitch_Kp.Location = new System.Drawing.Point(163, 25);
            this.Txt_Pitch_Kp.Multiline = true;
            this.Txt_Pitch_Kp.Name = "Txt_Pitch_Kp";
            this.Txt_Pitch_Kp.Size = new System.Drawing.Size(108, 40);
            this.Txt_Pitch_Kp.TabIndex = 1;
            this.Txt_Pitch_Kp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Lab_Pitch_Kp
            // 
            this.Lab_Pitch_Kp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Lab_Pitch_Kp.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.Lab_Pitch_Kp.Location = new System.Drawing.Point(13, 25);
            this.Lab_Pitch_Kp.Name = "Lab_Pitch_Kp";
            this.Lab_Pitch_Kp.Size = new System.Drawing.Size(145, 40);
            this.Lab_Pitch_Kp.TabIndex = 0;
            this.Lab_Pitch_Kp.Text = "俯仰角—Kp";
            this.Lab_Pitch_Kp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GroupBox_Yaw_PID
            // 
            this.GroupBox_Yaw_PID.Controls.Add(this.Txt_AngleSpeedY_Target);
            this.GroupBox_Yaw_PID.Controls.Add(this.Lab_Yaw_Target);
            this.GroupBox_Yaw_PID.Controls.Add(this.Txt_AngleSpeedY_Ki);
            this.GroupBox_Yaw_PID.Controls.Add(this.Txt_AngleSpeedY_Kd);
            this.GroupBox_Yaw_PID.Controls.Add(this.Lab_Yaw_Ki);
            this.GroupBox_Yaw_PID.Controls.Add(this.Lab_Yaw_Kd);
            this.GroupBox_Yaw_PID.Controls.Add(this.Txt_AngleSpeedY_Kp);
            this.GroupBox_Yaw_PID.Controls.Add(this.Lab__Kp);
            this.GroupBox_Yaw_PID.Location = new System.Drawing.Point(23, 268);
            this.GroupBox_Yaw_PID.Name = "GroupBox_Yaw_PID";
            this.GroupBox_Yaw_PID.Size = new System.Drawing.Size(278, 232);
            this.GroupBox_Yaw_PID.TabIndex = 20;
            this.GroupBox_Yaw_PID.TabStop = false;
            this.GroupBox_Yaw_PID.Text = "Y轴角速度PID系数";
            // 
            // Txt_AngleSpeedY_Target
            // 
            this.Txt_AngleSpeedY_Target.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_AngleSpeedY_Target.Location = new System.Drawing.Point(163, 181);
            this.Txt_AngleSpeedY_Target.Multiline = true;
            this.Txt_AngleSpeedY_Target.Name = "Txt_AngleSpeedY_Target";
            this.Txt_AngleSpeedY_Target.Size = new System.Drawing.Size(108, 40);
            this.Txt_AngleSpeedY_Target.TabIndex = 20;
            this.Txt_AngleSpeedY_Target.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Lab_Yaw_Target
            // 
            this.Lab_Yaw_Target.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Lab_Yaw_Target.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.Lab_Yaw_Target.Location = new System.Drawing.Point(13, 181);
            this.Lab_Yaw_Target.Name = "Lab_Yaw_Target";
            this.Lab_Yaw_Target.Size = new System.Drawing.Size(145, 40);
            this.Lab_Yaw_Target.TabIndex = 19;
            this.Lab_Yaw_Target.Text = "Y轴角速度设定值";
            this.Lab_Yaw_Target.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Txt_AngleSpeedY_Ki
            // 
            this.Txt_AngleSpeedY_Ki.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_AngleSpeedY_Ki.Location = new System.Drawing.Point(163, 78);
            this.Txt_AngleSpeedY_Ki.Multiline = true;
            this.Txt_AngleSpeedY_Ki.Name = "Txt_AngleSpeedY_Ki";
            this.Txt_AngleSpeedY_Ki.Size = new System.Drawing.Size(108, 40);
            this.Txt_AngleSpeedY_Ki.TabIndex = 18;
            this.Txt_AngleSpeedY_Ki.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Txt_AngleSpeedY_Kd
            // 
            this.Txt_AngleSpeedY_Kd.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_AngleSpeedY_Kd.Location = new System.Drawing.Point(163, 129);
            this.Txt_AngleSpeedY_Kd.Multiline = true;
            this.Txt_AngleSpeedY_Kd.Name = "Txt_AngleSpeedY_Kd";
            this.Txt_AngleSpeedY_Kd.Size = new System.Drawing.Size(108, 40);
            this.Txt_AngleSpeedY_Kd.TabIndex = 17;
            this.Txt_AngleSpeedY_Kd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Lab_Yaw_Ki
            // 
            this.Lab_Yaw_Ki.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Lab_Yaw_Ki.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.Lab_Yaw_Ki.Location = new System.Drawing.Point(13, 78);
            this.Lab_Yaw_Ki.Name = "Lab_Yaw_Ki";
            this.Lab_Yaw_Ki.Size = new System.Drawing.Size(145, 40);
            this.Lab_Yaw_Ki.TabIndex = 10;
            this.Lab_Yaw_Ki.Text = "Y轴角速度—Ki";
            this.Lab_Yaw_Ki.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lab_Yaw_Kd
            // 
            this.Lab_Yaw_Kd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Lab_Yaw_Kd.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.Lab_Yaw_Kd.Location = new System.Drawing.Point(13, 129);
            this.Lab_Yaw_Kd.Name = "Lab_Yaw_Kd";
            this.Lab_Yaw_Kd.Size = new System.Drawing.Size(145, 40);
            this.Lab_Yaw_Kd.TabIndex = 9;
            this.Lab_Yaw_Kd.Text = "Y轴角速度—Kd";
            this.Lab_Yaw_Kd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Txt_AngleSpeedY_Kp
            // 
            this.Txt_AngleSpeedY_Kp.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_AngleSpeedY_Kp.Location = new System.Drawing.Point(163, 25);
            this.Txt_AngleSpeedY_Kp.Multiline = true;
            this.Txt_AngleSpeedY_Kp.Name = "Txt_AngleSpeedY_Kp";
            this.Txt_AngleSpeedY_Kp.Size = new System.Drawing.Size(108, 40);
            this.Txt_AngleSpeedY_Kp.TabIndex = 1;
            this.Txt_AngleSpeedY_Kp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Lab__Kp
            // 
            this.Lab__Kp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Lab__Kp.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.Lab__Kp.Location = new System.Drawing.Point(13, 25);
            this.Lab__Kp.Name = "Lab__Kp";
            this.Lab__Kp.Size = new System.Drawing.Size(145, 40);
            this.Lab__Kp.TabIndex = 0;
            this.Lab__Kp.Text = "Y轴角速度—Kp";
            this.Lab__Kp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Btn_Preservation
            // 
            this.Btn_Preservation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Btn_Preservation.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Preservation.ForeColor = System.Drawing.Color.Red;
            this.Btn_Preservation.Location = new System.Drawing.Point(176, 506);
            this.Btn_Preservation.Name = "Btn_Preservation";
            this.Btn_Preservation.Size = new System.Drawing.Size(119, 51);
            this.Btn_Preservation.TabIndex = 21;
            this.Btn_Preservation.Text = "保存";
            this.Btn_Preservation.UseVisualStyleBackColor = false;
            this.Btn_Preservation.Click += new System.EventHandler(this.Btn_Preservation_Click);
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Btn_Cancel.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Cancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Btn_Cancel.Location = new System.Drawing.Point(346, 506);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(119, 51);
            this.Btn_Cancel.TabIndex = 22;
            this.Btn_Cancel.Text = "取消";
            this.Btn_Cancel.UseVisualStyleBackColor = false;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RadBtn_None);
            this.groupBox2.Controls.Add(this.RadBtn_AngleSpeedY);
            this.groupBox2.Controls.Add(this.RadBtn_Pitch);
            this.groupBox2.Controls.Add(this.RadBtn_Depth);
            this.groupBox2.Controls.Add(this.ChkBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(613, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(199, 249);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            // 
            // RadBtn_None
            // 
            this.RadBtn_None.Location = new System.Drawing.Point(19, 170);
            this.RadBtn_None.Name = "RadBtn_None";
            this.RadBtn_None.Size = new System.Drawing.Size(150, 30);
            this.RadBtn_None.TabIndex = 5;
            this.RadBtn_None.TabStop = true;
            this.RadBtn_None.Text = "以上都不选";
            this.RadBtn_None.UseVisualStyleBackColor = true;
            this.RadBtn_None.CheckedChanged += new System.EventHandler(this.RadBtn_None_CheckedChanged);
            // 
            // RadBtn_AngleSpeedY
            // 
            this.RadBtn_AngleSpeedY.Location = new System.Drawing.Point(19, 134);
            this.RadBtn_AngleSpeedY.Name = "RadBtn_AngleSpeedY";
            this.RadBtn_AngleSpeedY.Size = new System.Drawing.Size(150, 30);
            this.RadBtn_AngleSpeedY.TabIndex = 4;
            this.RadBtn_AngleSpeedY.TabStop = true;
            this.RadBtn_AngleSpeedY.Text = "Y轴角速度";
            this.RadBtn_AngleSpeedY.UseVisualStyleBackColor = true;
            this.RadBtn_AngleSpeedY.CheckedChanged += new System.EventHandler(this.RadBtn_AngleSpeedY_CheckedChanged);
            // 
            // RadBtn_Pitch
            // 
            this.RadBtn_Pitch.Location = new System.Drawing.Point(19, 98);
            this.RadBtn_Pitch.Name = "RadBtn_Pitch";
            this.RadBtn_Pitch.Size = new System.Drawing.Size(150, 30);
            this.RadBtn_Pitch.TabIndex = 3;
            this.RadBtn_Pitch.TabStop = true;
            this.RadBtn_Pitch.Text = "俯仰角";
            this.RadBtn_Pitch.UseVisualStyleBackColor = true;
            this.RadBtn_Pitch.CheckedChanged += new System.EventHandler(this.RadBtn_Pitch_CheckedChanged);
            // 
            // RadBtn_Depth
            // 
            this.RadBtn_Depth.Location = new System.Drawing.Point(19, 62);
            this.RadBtn_Depth.Name = "RadBtn_Depth";
            this.RadBtn_Depth.Size = new System.Drawing.Size(150, 30);
            this.RadBtn_Depth.TabIndex = 2;
            this.RadBtn_Depth.TabStop = true;
            this.RadBtn_Depth.Text = "深度";
            this.RadBtn_Depth.UseVisualStyleBackColor = true;
            this.RadBtn_Depth.CheckedChanged += new System.EventHandler(this.RadBtn_Depth_CheckedChanged);
            // 
            // ChkBox
            // 
            this.ChkBox.Location = new System.Drawing.Point(19, 206);
            this.ChkBox.Name = "ChkBox";
            this.ChkBox.Size = new System.Drawing.Size(150, 30);
            this.ChkBox.TabIndex = 1;
            this.ChkBox.Text = "Y轴加速度";
            this.ChkBox.UseVisualStyleBackColor = true;
            this.ChkBox.CheckedChanged += new System.EventHandler(this.ChkBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "请选择你要调的属性";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PID系数
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 596);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Btn_Cancel);
            this.Controls.Add(this.Btn_Preservation);
            this.Controls.Add(this.GroupBox_Pitch_PID);
            this.Controls.Add(this.GroupBox_Yaw_PID);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GroupBox_Depth_PID);
            this.Name = "PID系数";
            this.Text = "PID参数 ";
            this.Shown += new System.EventHandler(this.PID系数_Shown);
            this.GroupBox_Depth_PID.ResumeLayout(false);
            this.GroupBox_Depth_PID.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.GroupBox_Pitch_PID.ResumeLayout(false);
            this.GroupBox_Pitch_PID.PerformLayout();
            this.GroupBox_Yaw_PID.ResumeLayout(false);
            this.GroupBox_Yaw_PID.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Lab_Depth_Kp;
        private System.Windows.Forms.TextBox Txt_Depth_Kp;
        private System.Windows.Forms.Label Lab_Depth_Kd;
        private System.Windows.Forms.Label Lab_Depth_Ki;
        private System.Windows.Forms.TextBox Txt_Depth_Kd;
        private System.Windows.Forms.TextBox Txt_Depth_Ki;
        private System.Windows.Forms.GroupBox GroupBox_Depth_PID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Txt_AccelerationY_Ki;
        private System.Windows.Forms.TextBox Txt_AccelerationY_Kd;
        private System.Windows.Forms.Label Lab_AccelerationY_Ki;
        private System.Windows.Forms.Label Lab_AccelerationY_Kd;
        private System.Windows.Forms.TextBox Txt_AccelerationY_Kp;
        private System.Windows.Forms.Label Lab_AccelerationY_Kp;
        private System.Windows.Forms.GroupBox GroupBox_Pitch_PID;
        private System.Windows.Forms.TextBox Txt_Pitch_Ki;
        private System.Windows.Forms.TextBox Txt_Pitch_Kd;
        private System.Windows.Forms.Label Lab_Pitch_Ki;
        private System.Windows.Forms.Label Lab_Pitch_Kd;
        private System.Windows.Forms.TextBox Txt_Pitch_Kp;
        private System.Windows.Forms.Label Lab_Pitch_Kp;
        private System.Windows.Forms.GroupBox GroupBox_Yaw_PID;
        private System.Windows.Forms.TextBox Txt_AngleSpeedY_Ki;
        private System.Windows.Forms.TextBox Txt_AngleSpeedY_Kd;
        private System.Windows.Forms.Label Lab_Yaw_Ki;
        private System.Windows.Forms.Label Lab_Yaw_Kd;
        private System.Windows.Forms.TextBox Txt_AngleSpeedY_Kp;
        private System.Windows.Forms.Label Lab__Kp;
        private System.Windows.Forms.Button Btn_Preservation;
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.TextBox Txt_Depth_Target;
        private System.Windows.Forms.Label Lab_Depth_Target;
        private System.Windows.Forms.TextBox Txt_AccelerationY_Target;
        private System.Windows.Forms.Label Lab_AccelerationY_Target;
        private System.Windows.Forms.TextBox Txt_Pitch_Target;
        private System.Windows.Forms.Label Lab_Pitch_Target;
        private System.Windows.Forms.TextBox Txt_AngleSpeedY_Target;
        private System.Windows.Forms.Label Lab_Yaw_Target;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RadBtn_AngleSpeedY;
        private System.Windows.Forms.RadioButton RadBtn_Pitch;
        private System.Windows.Forms.RadioButton RadBtn_Depth;
        private System.Windows.Forms.CheckBox ChkBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton RadBtn_None;
    }
}