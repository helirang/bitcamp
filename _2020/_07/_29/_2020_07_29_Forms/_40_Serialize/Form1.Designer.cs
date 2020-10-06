namespace _40_Serialize
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
            this.btnWriteSerialize = new System.Windows.Forms.Button();
            this.btnReadSerialize = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnWriteSerialize
            // 
            this.btnWriteSerialize.Location = new System.Drawing.Point(20, 21);
            this.btnWriteSerialize.Name = "btnWriteSerialize";
            this.btnWriteSerialize.Size = new System.Drawing.Size(209, 72);
            this.btnWriteSerialize.TabIndex = 0;
            this.btnWriteSerialize.Text = "객체 시리얼라이즈 저장";
            this.btnWriteSerialize.UseVisualStyleBackColor = true;
            this.btnWriteSerialize.Click += new System.EventHandler(this.btnWriteSerialize_Click);
            // 
            // btnReadSerialize
            // 
            this.btnReadSerialize.Location = new System.Drawing.Point(20, 132);
            this.btnReadSerialize.Name = "btnReadSerialize";
            this.btnReadSerialize.Size = new System.Drawing.Size(209, 72);
            this.btnReadSerialize.TabIndex = 0;
            this.btnReadSerialize.Text = "객체 시리얼라이즈 읽기";
            this.btnReadSerialize.UseVisualStyleBackColor = true;
            this.btnReadSerialize.Click += new System.EventHandler(this.btnReadSerialize_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 225);
            this.Controls.Add(this.btnReadSerialize);
            this.Controls.Add(this.btnWriteSerialize);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnWriteSerialize;
        private System.Windows.Forms.Button btnReadSerialize;
    }
}

