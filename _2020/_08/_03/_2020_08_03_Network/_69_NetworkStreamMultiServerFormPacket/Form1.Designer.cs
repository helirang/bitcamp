namespace _19_NetworkStreamMultiServerFormPacket
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.btnServerStart = new System.Windows.Forms.Button();
            this.btnServerStop = new System.Windows.Forms.Button();
            this.lbRecvData = new System.Windows.Forms.ListBox();
            this.tbSendData = new System.Windows.Forms.TextBox();
            this.btnEraseListBox = new System.Windows.Forms.Button();
            this.clientListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnForcedExit = new System.Windows.Forms.Button();
            this.ckbAnonymous = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port";
            // 
            // tbPort
            // 
            this.tbPort.Font = new System.Drawing.Font("휴먼편지체", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbPort.Location = new System.Drawing.Point(102, 16);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(114, 45);
            this.tbPort.TabIndex = 1;
            this.tbPort.Text = "9000";
            // 
            // btnServerStart
            // 
            this.btnServerStart.Font = new System.Drawing.Font("휴먼편지체", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnServerStart.Location = new System.Drawing.Point(237, 16);
            this.btnServerStart.Name = "btnServerStart";
            this.btnServerStart.Size = new System.Drawing.Size(248, 44);
            this.btnServerStart.TabIndex = 2;
            this.btnServerStart.Text = "Server Start";
            this.btnServerStart.UseVisualStyleBackColor = true;
            this.btnServerStart.Click += new System.EventHandler(this.BtnServerStart_Click);
            // 
            // btnServerStop
            // 
            this.btnServerStop.Font = new System.Drawing.Font("휴먼편지체", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnServerStop.Location = new System.Drawing.Point(237, 78);
            this.btnServerStop.Name = "btnServerStop";
            this.btnServerStop.Size = new System.Drawing.Size(248, 44);
            this.btnServerStop.TabIndex = 2;
            this.btnServerStop.Text = "Server Stop";
            this.btnServerStop.UseVisualStyleBackColor = true;
            this.btnServerStop.Click += new System.EventHandler(this.BtnServerStop_Click);
            // 
            // lbRecvData
            // 
            this.lbRecvData.Font = new System.Drawing.Font("휴먼편지체", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbRecvData.FormattingEnabled = true;
            this.lbRecvData.HorizontalScrollbar = true;
            this.lbRecvData.ItemHeight = 38;
            this.lbRecvData.Location = new System.Drawing.Point(25, 195);
            this.lbRecvData.Name = "lbRecvData";
            this.lbRecvData.Size = new System.Drawing.Size(709, 384);
            this.lbRecvData.TabIndex = 3;
            // 
            // tbSendData
            // 
            this.tbSendData.Font = new System.Drawing.Font("휴먼편지체", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbSendData.Location = new System.Drawing.Point(25, 637);
            this.tbSendData.Name = "tbSendData";
            this.tbSendData.Size = new System.Drawing.Size(709, 45);
            this.tbSendData.TabIndex = 4;
            this.tbSendData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbSendData_KeyDown);
            // 
            // btnEraseListBox
            // 
            this.btnEraseListBox.Font = new System.Drawing.Font("휴먼편지체", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnEraseListBox.Location = new System.Drawing.Point(576, 76);
            this.btnEraseListBox.Name = "btnEraseListBox";
            this.btnEraseListBox.Size = new System.Drawing.Size(158, 46);
            this.btnEraseListBox.TabIndex = 5;
            this.btnEraseListBox.Text = "지우기";
            this.btnEraseListBox.UseVisualStyleBackColor = true;
            this.btnEraseListBox.Click += new System.EventHandler(this.BtnEraseListBox_Click);
            // 
            // clientListView
            // 
            this.clientListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.clientListView.Font = new System.Drawing.Font("휴먼편지체", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.clientListView.FullRowSelect = true;
            this.clientListView.GridLines = true;
            this.clientListView.HideSelection = false;
            this.clientListView.Location = new System.Drawing.Point(757, 16);
            this.clientListView.Name = "clientListView";
            this.clientListView.Size = new System.Drawing.Size(348, 599);
            this.clientListView.TabIndex = 6;
            this.clientListView.UseCompatibleStateImageBehavior = false;
            this.clientListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "IP";
            this.columnHeader1.Width = 240;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Port";
            this.columnHeader2.Width = 160;
            // 
            // btnForcedExit
            // 
            this.btnForcedExit.Font = new System.Drawing.Font("휴먼편지체", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnForcedExit.Location = new System.Drawing.Point(899, 626);
            this.btnForcedExit.Name = "btnForcedExit";
            this.btnForcedExit.Size = new System.Drawing.Size(184, 61);
            this.btnForcedExit.TabIndex = 7;
            this.btnForcedExit.Text = "강퇴";
            this.btnForcedExit.UseVisualStyleBackColor = true;
            this.btnForcedExit.Click += new System.EventHandler(this.btnForcedExit_Click);
            // 
            // ckbAnonymous
            // 
            this.ckbAnonymous.AutoSize = true;
            this.ckbAnonymous.Checked = true;
            this.ckbAnonymous.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbAnonymous.Font = new System.Drawing.Font("휴먼편지체", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ckbAnonymous.ForeColor = System.Drawing.Color.White;
            this.ckbAnonymous.Location = new System.Drawing.Point(30, 125);
            this.ckbAnonymous.Name = "ckbAnonymous";
            this.ckbAnonymous.Size = new System.Drawing.Size(155, 42);
            this.ckbAnonymous.TabIndex = 8;
            this.ckbAnonymous.Text = "익명 전송";
            this.ckbAnonymous.UseVisualStyleBackColor = true;
            this.ckbAnonymous.CheckedChanged += new System.EventHandler(this.ckbAnonymous_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1111, 699);
            this.Controls.Add(this.ckbAnonymous);
            this.Controls.Add(this.btnForcedExit);
            this.Controls.Add(this.clientListView);
            this.Controls.Add(this.btnEraseListBox);
            this.Controls.Add(this.tbSendData);
            this.Controls.Add(this.lbRecvData);
            this.Controls.Add(this.btnServerStop);
            this.Controls.Add(this.btnServerStart);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Button btnServerStart;
        private System.Windows.Forms.Button btnServerStop;
        private System.Windows.Forms.ListBox lbRecvData;
        private System.Windows.Forms.TextBox tbSendData;
        private System.Windows.Forms.Button btnEraseListBox;
        private System.Windows.Forms.ListView clientListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnForcedExit;
        private System.Windows.Forms.CheckBox ckbAnonymous;
    }
}

