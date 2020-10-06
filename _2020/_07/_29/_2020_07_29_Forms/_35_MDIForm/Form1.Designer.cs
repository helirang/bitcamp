namespace _35_MDIForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.새파일ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.닫기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.정렬ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.계단식정렬ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.수평바둑판정렬ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.수직바둑판정렬ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.windowToolStripMenuItem,
            this.정렬ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1627, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.새파일ToolStripMenuItem,
            this.닫기ToolStripMenuItem});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.windowToolStripMenuItem.Text = "Window";
            // 
            // 새파일ToolStripMenuItem
            // 
            this.새파일ToolStripMenuItem.Name = "새파일ToolStripMenuItem";
            this.새파일ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.새파일ToolStripMenuItem.Text = "새파일";
            this.새파일ToolStripMenuItem.Click += new System.EventHandler(this.새파일ToolStripMenuItem_Click);
            // 
            // 닫기ToolStripMenuItem
            // 
            this.닫기ToolStripMenuItem.Name = "닫기ToolStripMenuItem";
            this.닫기ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.닫기ToolStripMenuItem.Text = "닫기";
            this.닫기ToolStripMenuItem.Click += new System.EventHandler(this.닫기ToolStripMenuItem_Click);
            // 
            // 정렬ToolStripMenuItem
            // 
            this.정렬ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.계단식정렬ToolStripMenuItem,
            this.수평바둑판정렬ToolStripMenuItem,
            this.수직바둑판정렬ToolStripMenuItem});
            this.정렬ToolStripMenuItem.Name = "정렬ToolStripMenuItem";
            this.정렬ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.정렬ToolStripMenuItem.Text = "정렬";
            // 
            // 계단식정렬ToolStripMenuItem
            // 
            this.계단식정렬ToolStripMenuItem.Name = "계단식정렬ToolStripMenuItem";
            this.계단식정렬ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.계단식정렬ToolStripMenuItem.Text = "계단식정렬";
            this.계단식정렬ToolStripMenuItem.Click += new System.EventHandler(this.계단식정렬ToolStripMenuItem_Click);
            // 
            // 수평바둑판정렬ToolStripMenuItem
            // 
            this.수평바둑판정렬ToolStripMenuItem.Name = "수평바둑판정렬ToolStripMenuItem";
            this.수평바둑판정렬ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.수평바둑판정렬ToolStripMenuItem.Text = "수평바둑판정렬";
            this.수평바둑판정렬ToolStripMenuItem.Click += new System.EventHandler(this.수평바둑판정렬ToolStripMenuItem_Click);
            // 
            // 수직바둑판정렬ToolStripMenuItem
            // 
            this.수직바둑판정렬ToolStripMenuItem.Name = "수직바둑판정렬ToolStripMenuItem";
            this.수직바둑판정렬ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.수직바둑판정렬ToolStripMenuItem.Text = "수직바둑판정렬";
            this.수직바둑판정렬ToolStripMenuItem.Click += new System.EventHandler(this.수직바둑판정렬ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1627, 911);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 새파일ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 닫기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 정렬ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 계단식정렬ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 수평바둑판정렬ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 수직바둑판정렬ToolStripMenuItem;
    }
}

