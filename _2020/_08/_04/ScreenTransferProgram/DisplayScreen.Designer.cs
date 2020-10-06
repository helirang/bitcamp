namespace ScreenTransferProgram
{
    partial class DisplayScreen
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mPicScreenImage = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.mTxtServerPortNum = new System.Windows.Forms.TextBox();
            this.mTxtServerIPAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mBtnStartServer = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.mTxtClientPortNum = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.mTxtClientIPAddress = new System.Windows.Forms.TextBox();
            this.mBtnStartClient = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.mBtnExit = new System.Windows.Forms.Button();
            this.mTxtStatus = new System.Windows.Forms.TextBox();
            this.mTimerSendScreenImage = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mPicScreenImage)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mPicScreenImage);
            this.groupBox1.Location = new System.Drawing.Point(14, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(672, 420);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "화면 출력";
            // 
            // mPicScreenImage
            // 
            this.mPicScreenImage.Location = new System.Drawing.Point(7, 18);
            this.mPicScreenImage.Name = "mPicScreenImage";
            this.mPicScreenImage.Size = new System.Drawing.Size(659, 397);
            this.mPicScreenImage.TabIndex = 0;
            this.mPicScreenImage.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.mTxtServerPortNum);
            this.groupBox2.Controls.Add(this.mTxtServerIPAddress);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.mBtnStartServer);
            this.groupBox2.Location = new System.Drawing.Point(693, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(194, 132);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "서버용";
            // 
            // mTxtServerPortNum
            // 
            this.mTxtServerPortNum.Location = new System.Drawing.Point(10, 70);
            this.mTxtServerPortNum.Name = "mTxtServerPortNum";
            this.mTxtServerPortNum.Size = new System.Drawing.Size(175, 21);
            this.mTxtServerPortNum.TabIndex = 4;
            // 
            // mTxtServerIPAddress
            // 
            this.mTxtServerIPAddress.Location = new System.Drawing.Point(10, 32);
            this.mTxtServerIPAddress.Name = "mTxtServerIPAddress";
            this.mTxtServerIPAddress.Size = new System.Drawing.Size(175, 21);
            this.mTxtServerIPAddress.TabIndex = 3;
            this.mTxtServerIPAddress.Text = " ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "서버 포트번호";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "서버 아이피";
            // 
            // mBtnStartServer
            // 
            this.mBtnStartServer.Location = new System.Drawing.Point(7, 94);
            this.mBtnStartServer.Name = "mBtnStartServer";
            this.mBtnStartServer.Size = new System.Drawing.Size(176, 29);
            this.mBtnStartServer.TabIndex = 0;
            this.mBtnStartServer.Text = "서버 시작";
            this.mBtnStartServer.UseVisualStyleBackColor = true;
            this.mBtnStartServer.Click += new System.EventHandler(this.mBtnStartServer_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.mTxtClientPortNum);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.mTxtClientIPAddress);
            this.groupBox3.Controls.Add(this.mBtnStartClient);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(693, 149);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(194, 142);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "클라이언트용";
            // 
            // mTxtClientPortNum
            // 
            this.mTxtClientPortNum.Location = new System.Drawing.Point(10, 79);
            this.mTxtClientPortNum.Name = "mTxtClientPortNum";
            this.mTxtClientPortNum.Size = new System.Drawing.Size(175, 21);
            this.mTxtClientPortNum.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "클라이언트 아이피";
            // 
            // mTxtClientIPAddress
            // 
            this.mTxtClientIPAddress.Location = new System.Drawing.Point(10, 36);
            this.mTxtClientIPAddress.Name = "mTxtClientIPAddress";
            this.mTxtClientIPAddress.Size = new System.Drawing.Size(175, 21);
            this.mTxtClientIPAddress.TabIndex = 10;
            // 
            // mBtnStartClient
            // 
            this.mBtnStartClient.Location = new System.Drawing.Point(7, 103);
            this.mBtnStartClient.Name = "mBtnStartClient";
            this.mBtnStartClient.Size = new System.Drawing.Size(180, 29);
            this.mBtnStartClient.TabIndex = 7;
            this.mBtnStartClient.Text = "클라이언트 시작";
            this.mBtnStartClient.UseVisualStyleBackColor = true;
            this.mBtnStartClient.Click += new System.EventHandler(this.mBtnStartClient_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "클라이언트 포트번호";
            // 
            // mBtnExit
            // 
            this.mBtnExit.Location = new System.Drawing.Point(693, 402);
            this.mBtnExit.Name = "mBtnExit";
            this.mBtnExit.Size = new System.Drawing.Size(194, 29);
            this.mBtnExit.TabIndex = 7;
            this.mBtnExit.Text = "네트워크 종료";
            this.mBtnExit.UseVisualStyleBackColor = true;
            this.mBtnExit.Click += new System.EventHandler(this.mBtnExit_Click);
            // 
            // mTxtStatus
            // 
            this.mTxtStatus.Location = new System.Drawing.Point(693, 296);
            this.mTxtStatus.Multiline = true;
            this.mTxtStatus.Name = "mTxtStatus";
            this.mTxtStatus.ReadOnly = true;
            this.mTxtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mTxtStatus.Size = new System.Drawing.Size(193, 101);
            this.mTxtStatus.TabIndex = 8;
            // 
            // mTimerSendScreenImage
            // 
            this.mTimerSendScreenImage.Interval = 20;
            this.mTimerSendScreenImage.Tick += new System.EventHandler(this.mTimerSendScreenImage_Tick);
            // 
            // DisplayScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 442);
            this.Controls.Add(this.mTxtStatus);
            this.Controls.Add(this.mBtnExit);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "DisplayScreen";
            this.Text = "화면 전송 프로그램";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mPicScreenImage)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button mBtnStartServer;
        private System.Windows.Forms.TextBox mTxtServerPortNum;
        private System.Windows.Forms.TextBox mTxtServerIPAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox mTxtClientPortNum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox mTxtClientIPAddress;
        private System.Windows.Forms.Button mBtnStartClient;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button mBtnExit;
        private System.Windows.Forms.PictureBox mPicScreenImage;
        private System.Windows.Forms.TextBox mTxtStatus;
        private System.Windows.Forms.Timer mTimerSendScreenImage;
    }
}

