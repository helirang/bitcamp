namespace _39_MemoText
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
            this.tbMemo = new System.Windows.Forms.TextBox();
            this.btnClearMemo = new System.Windows.Forms.Button();
            this.btnReadMemo = new System.Windows.Forms.Button();
            this.btnWriteMemo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbMemo
            // 
            this.tbMemo.Font = new System.Drawing.Font("휴먼편지체", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbMemo.Location = new System.Drawing.Point(12, 12);
            this.tbMemo.Multiline = true;
            this.tbMemo.Name = "tbMemo";
            this.tbMemo.Size = new System.Drawing.Size(793, 536);
            this.tbMemo.TabIndex = 0;
            // 
            // btnClearMemo
            // 
            this.btnClearMemo.Location = new System.Drawing.Point(561, 567);
            this.btnClearMemo.Name = "btnClearMemo";
            this.btnClearMemo.Size = new System.Drawing.Size(243, 61);
            this.btnClearMemo.TabIndex = 1;
            this.btnClearMemo.Text = "화면 클리어";
            this.btnClearMemo.UseVisualStyleBackColor = true;
            this.btnClearMemo.Click += new System.EventHandler(this.btnClearMemo_Click);
            // 
            // btnReadMemo
            // 
            this.btnReadMemo.Location = new System.Drawing.Point(289, 567);
            this.btnReadMemo.Name = "btnReadMemo";
            this.btnReadMemo.Size = new System.Drawing.Size(243, 61);
            this.btnReadMemo.TabIndex = 1;
            this.btnReadMemo.Text = "메모 읽기";
            this.btnReadMemo.UseVisualStyleBackColor = true;
            this.btnReadMemo.Click += new System.EventHandler(this.btnReadMemo_Click);
            // 
            // btnWriteMemo
            // 
            this.btnWriteMemo.Location = new System.Drawing.Point(12, 567);
            this.btnWriteMemo.Name = "btnWriteMemo";
            this.btnWriteMemo.Size = new System.Drawing.Size(243, 61);
            this.btnWriteMemo.TabIndex = 1;
            this.btnWriteMemo.Text = "메모 저장";
            this.btnWriteMemo.UseVisualStyleBackColor = true;
            this.btnWriteMemo.Click += new System.EventHandler(this.btnWriteMemo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 636);
            this.Controls.Add(this.btnWriteMemo);
            this.Controls.Add(this.btnReadMemo);
            this.Controls.Add(this.btnClearMemo);
            this.Controls.Add(this.tbMemo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbMemo;
        private System.Windows.Forms.Button btnClearMemo;
        private System.Windows.Forms.Button btnReadMemo;
        private System.Windows.Forms.Button btnWriteMemo;
    }
}

