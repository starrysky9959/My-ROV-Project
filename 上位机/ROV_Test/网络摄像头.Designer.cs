namespace ROV_Test
{
    partial class 网络摄像头
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Txt_UserName = new System.Windows.Forms.TextBox();
            this.Txt_IPAddress = new System.Windows.Forms.TextBox();
            this.Txt_Password = new System.Windows.Forms.TextBox();
            this.Btn_Preservation = new System.Windows.Forms.Button();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.Btn_Connect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(63, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(63, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 46);
            this.label3.TabIndex = 2;
            this.label3.Text = "IP地址";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(63, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 46);
            this.label4.TabIndex = 3;
            this.label4.Text = "密码";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Txt_UserName
            // 
            this.Txt_UserName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_UserName.Location = new System.Drawing.Point(206, 64);
            this.Txt_UserName.Multiline = true;
            this.Txt_UserName.Name = "Txt_UserName";
            this.Txt_UserName.Size = new System.Drawing.Size(339, 46);
            this.Txt_UserName.TabIndex = 4;
            // 
            // Txt_IPAddress
            // 
            this.Txt_IPAddress.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_IPAddress.Location = new System.Drawing.Point(206, 223);
            this.Txt_IPAddress.Multiline = true;
            this.Txt_IPAddress.Name = "Txt_IPAddress";
            this.Txt_IPAddress.Size = new System.Drawing.Size(339, 46);
            this.Txt_IPAddress.TabIndex = 5;
            // 
            // Txt_Password
            // 
            this.Txt_Password.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_Password.Location = new System.Drawing.Point(206, 142);
            this.Txt_Password.Multiline = true;
            this.Txt_Password.Name = "Txt_Password";
            this.Txt_Password.Size = new System.Drawing.Size(339, 46);
            this.Txt_Password.TabIndex = 6;
            // 
            // Btn_Preservation
            // 
            this.Btn_Preservation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Btn_Preservation.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Preservation.ForeColor = System.Drawing.Color.Red;
            this.Btn_Preservation.Location = new System.Drawing.Point(57, 300);
            this.Btn_Preservation.Name = "Btn_Preservation";
            this.Btn_Preservation.Size = new System.Drawing.Size(119, 51);
            this.Btn_Preservation.TabIndex = 22;
            this.Btn_Preservation.Text = "保存";
            this.Btn_Preservation.UseVisualStyleBackColor = false;
            this.Btn_Preservation.Click += new System.EventHandler(this.Btn_Preservation_Click);
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Btn_Cancel.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Cancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Btn_Cancel.Location = new System.Drawing.Point(206, 300);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(119, 51);
            this.Btn_Cancel.TabIndex = 23;
            this.Btn_Cancel.Text = "取消";
            this.Btn_Cancel.UseVisualStyleBackColor = false;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // Btn_Connect
            // 
            this.Btn_Connect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Btn_Connect.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Connect.ForeColor = System.Drawing.Color.Maroon;
            this.Btn_Connect.Location = new System.Drawing.Point(358, 300);
            this.Btn_Connect.Name = "Btn_Connect";
            this.Btn_Connect.Size = new System.Drawing.Size(119, 51);
            this.Btn_Connect.TabIndex = 24;
            this.Btn_Connect.Text = "连接";
            this.Btn_Connect.UseVisualStyleBackColor = false;
            this.Btn_Connect.Click += new System.EventHandler(this.Btn_Connect_Click);
            // 
            // 网络摄像头
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(692, 437);
            this.Controls.Add(this.Btn_Connect);
            this.Controls.Add(this.Btn_Cancel);
            this.Controls.Add(this.Btn_Preservation);
            this.Controls.Add(this.Txt_Password);
            this.Controls.Add(this.Txt_IPAddress);
            this.Controls.Add(this.Txt_UserName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "网络摄像头";
            this.Text = "网络摄像头";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.网络摄像头_FormClosing);
            this.Shown += new System.EventHandler(this.网络摄像头_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Txt_UserName;
        private System.Windows.Forms.TextBox Txt_IPAddress;
        private System.Windows.Forms.TextBox Txt_Password;
        private System.Windows.Forms.Button Btn_Preservation;
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.Button Btn_Connect;
    }
}