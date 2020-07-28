using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01
{
    public partial class Form1 : Form
    {
        int centX, centY;
        const int RADIUS = 300;
        Timer timer = new Timer();

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load1;
            this.Paint += Form1_Paint;
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Form1_Load1(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            timer.Start();
            this.Width = 1000;
            this.Height = 1000;
            this.BackColor = Color.Black;
            this.centX = this.Width /2;
            this.centY = this.Height / 2;
        }

        void DrawWatchNum(Graphics g, int cnt)
        {
            g.FillEllipse(Brushes.Red,
                new RectangleF((float)centX, (float)centY, 30, 30));

            int degree = 360 / cnt;
            for (int i = 0; i < 360; i += degree)
            {
                double x = this.centX + (RADIUS * Math.Cos(i * Math.PI / 180));
                double y = this.centY + (RADIUS * Math.Sin(i * Math.PI / 180));
                g.FillEllipse(Brushes.Gold,
                    new RectangleF((float)x - 10, (float)y - 10, 20, 20));
            }
        }

        void DrawWatchTime(Graphics g, int cnt)
        {
            int timeNum = 3;
            int degree = 360 / cnt;
            for (int i = 0; i < 360; i += degree)
            {
                double x = this.centX + (RADIUS * Math.Cos(i * Math.PI / 180));
                double y = this.centY + (RADIUS * Math.Sin(i * Math.PI / 180));
                g.FillEllipse(Brushes.Aqua,
                    new RectangleF((float)x - 25, (float)y - 25, 50, 50));
                if ((i == 0 || i % 30 == 0))
                {
                    g.FillEllipse(Brushes.YellowGreen,
                   new RectangleF((float)x - 20, (float)y - 20, 40, 40));
                    if (timeNum > 12)
                    { timeNum = 1; }
                    g.DrawString($"{timeNum}", new Font("맑은 고딕", 15), Brushes.Black, (float)x - 8, (float)y - 15); timeNum++;
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString(DateTime.Now.ToString("HH:mm:ss"), new Font("맑은 고딕", 40), Brushes.White, 20, 20);
            DrawWatchNum(e.Graphics, 360);
            DrawWatchTime(e.Graphics, 12);
        }

    }
}
