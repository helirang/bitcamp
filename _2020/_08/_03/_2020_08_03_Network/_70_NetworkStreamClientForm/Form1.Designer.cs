namespace _16_NetworkStreamClientForm
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbSendData = new System.Windows.Forms.TextBox();
            this.lbRecvData = new System.Windows.Forms.ListBox();
            this.btnClientStop = new System.Windows.Forms.Button();
            this.btnClientConnect = new System.Windows.Forms.Button();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbIp = new System.Windows.Forms.TextBox();
            this.btnEraseListBox = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbSendData
            // 
            this.tbSendData.Font = new System.Drawing.Font("휴먼편지체", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbSendData.Location = new System.Drawing.Point(23, 565);
            this.tbSendData.Name = "tbSendData";
            this.tbSendData.Size = new System.Drawing.Size(757, 45);
            this.tbSendData.TabIndex = 10;
            this.tbSendData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbSendData_KeyDown);
            // 
            // lbRecvData
            // 
            this.lbRecvData.Font = new System.Drawing.Font("휴먼편지체", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbRecvData.FormattingEnabled = true;
            this.lbRecvData.ItemHeight = 38;
            this.lbRecvData.Location = new System.Drawing.Point(23, 126);
            this.lbRecvData.Name = "lbRecvData";
            this.lbRecvData.Size = new System.Drawing.Size(757, 384);
            this.lbRecvData.TabIndex = 9;
            // 
            // btnClientStop
            // 
            this.btnClientStop.Font = new System.Drawing.Font("휴먼편지체", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClientStop.Location = new System.Drawing.Point(326, 68);
            this.btnClientStop.Name = "btnClientStop";
            this.btnClientStop.Size = new System.Drawing.Size(280, 44);
            this.btnClientStop.TabIndex = 7;
            this.btnClientStop.Text = "Client Stop";
            this.btnClientStop.UseVisualStyleBackColor = true;
            this.btnClientStop.Click += new System.EventHandler(this.BtnClientStop_Click);
            // 
            // btnClientConnect
            // 
            this.btnClientConnect.Font = new System.Drawing.Font("휴먼편지체", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClientConnect.Location = new System.Drawing.Point(326, 12);
            this.btnClientConnect.Name = "btnClientConnect";
            this.btnClientConnect.Size = new System.Drawing.Size(280, 50);
            this.btnClientConnect.TabIndex = 8;
            this.btnClientConnect.Text = "Client Connect";
            this.btnClientConnect.UseVisualStyleBackColor = true;
            this.btnClientConnect.Click += new System.EventHandler(this.BtnClientConnect_Click);
            // 
            // tbPort
            // 
            this.tbPort.Font = new System.Drawing.Font("휴먼편지체", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbPort.Location = new System.Drawing.Point(99, 68);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(124, 45);
            this.tbPort.TabIndex = 6;
            this.tbPort.Text = "9000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "IP";
            // 
            // tbIp
            // 
            this.tbIp.Font = new System.Drawing.Font("휴먼편지체", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbIp.Location = new System.Drawing.Point(99, 18);
            this.tbIp.Name = "tbIp";
            this.tbIp.Size = new System.Drawing.Size(221, 45);
            this.tbIp.TabIndex = 6;
            this.tbIp.Text = "127.0.0.1";
            // 
            // btnEraseListBox
            // 
            this.btnEraseListBox.Font = new System.Drawing.Font("휴먼편지체", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnEraseListBox.Location = new System.Drawing.Point(612, 60);
            this.btnEraseListBox.Name = "btnEraseListBox";
            this.btnEraseListBox.Size = new System.Drawing.Size(168, 52);
            this.btnEraseListBox.TabIndex = 11;
            this.btnEraseListBox.Text = "지우기";
            this.btnEraseListBox.UseVisualStyleBackColor = true;
            this.btnEraseListBox.Click += new System.EventHandler(this.BtnEraseListBox_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(792, 621);
            this.Controls.Add(this.btnEraseListBox);
            this.Controls.Add(this.tbSendData);
            this.Controls.Add(this.lbRecvData);
            this.Controls.Add(this.btnClientStop);
            this.Controls.Add(this.btnClientConnect);
            this.Controls.Add(this.tbIp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSendData;
        private System.Windows.Forms.ListBox lbRecvData;
        private System.Windows.Forms.Button btnClientStop;
        private System.Windows.Forms.Button btnClientConnect;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbIp;
        private System.Windows.Forms.Button btnEraseListBox;
    }
}

