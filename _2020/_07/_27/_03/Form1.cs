using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _03
{
    public partial class Form1 : Form
    {
        int centX, centY;
        const int RADIUS = 300;
        Timer timer = new Timer();
        int timeNum = 4;


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
            this.BackColor = Color.Black;
            this.DoubleBuffered = true;
            timer.Start();
            this.Width = 1000;
            this.Height = 1000;
            this.BackColor = Color.Black;
            this.centX = this.Width / 2;
            this.centY = this.Height / 2;
        }

        void DrawWatchNum(Graphics g, int cnt)
        {
            g.FillEllipse(Brushes.AliceBlue,
                new RectangleF((float)centX - 15, (float)centY - 15, 30, 30));

            int degree = 360 / cnt;
            double miniX = 0, miniY = 0;
            int j = 0;

            for (int i = 0; i < 360; i += degree)
            {
                double x = this.centX + (RADIUS * Math.Cos(i * Math.PI / 180));
                double y = this.centY + (RADIUS * Math.Sin(i * Math.PI / 180));
                g.FillEllipse(Brushes.AliceBlue,
                    new RectangleF((float)x - 10, (float)y - 10, 20, 20));

                DrawWatchTime(g, 12, ref j, ref miniX, ref miniY);
            }
        }
        void DrawWatchTime(Graphics g, int cnt, ref int i, ref double miniX, ref double miniY)
        {
            int degree = 360 / cnt;
            i += degree;

            miniX = this.centX + (RADIUS * Math.Cos(i * Math.PI / 180));
            miniY = this.centY + (RADIUS * Math.Sin(i * Math.PI / 180));
            g.FillEllipse(Brushes.Coral,
                    new RectangleF((float)miniX - 25, (float)miniY - 25, 50, 50));

            if ((i == 0 || i % 30 == 0))
            {
                g.FillEllipse(Brushes.Aquamarine,
               new RectangleF((float)miniX - 20, (float)miniY - 20, 40, 40));
                if (timeNum > 12)
                { timeNum = 1; }
                g.DrawString($"{timeNum}", new Font("맑은 고딕", 15), Brushes.Black, (float)miniX - 8, (float)miniY - 15); timeNum++;
            }
        }

        void DrawSec(Graphics g)
        {
            int sec = Convert.ToInt32(DateTime.Now.ToString("ss"));
            sec += 45;
            if (sec > 60)
            { sec = sec % 60; }
            double x = this.centX + (RADIUS * Math.Cos(sec * Math.PI / 30));
            double y = this.centY + (RADIUS * Math.Sin(sec * Math.PI / 30));
            g.DrawLine(new Pen(Brushes.AliceBlue,3), (float)centX, (float)centY, (float)x, (float)y);
        }

        void DrawMin(Graphics g)
        {
            int min = Convert.ToInt32(DateTime.Now.ToString("mm"));
            min += 45;
            if (min > 60)
            { min = min % 60; }
            double x = this.centX + ((RADIUS-80) * Math.Cos(min * Math.PI / 30));
            double y = this.centY + ((RADIUS-80) * Math.Sin(min * Math.PI / 30));
            g.DrawLine(new Pen(Brushes.Crimson,4), (float)centX, (float)centY, (float)x, (float)y);
        }

        void DrawHour(Graphics g)
        {
            int hour = Convert.ToInt32(DateTime.Now.ToString("hh"));
            hour += 9;
            if (hour > 12)
            {hour = hour % 12;}

            double x = this.centX + ((RADIUS-150) * Math.Cos(hour * Math.PI / 6));
            double y = this.centY + ((RADIUS-150) * Math.Sin(hour * Math.PI / 6));
            g.DrawLine(new Pen(Brushes.PaleGoldenrod,8), (float)centX, (float)centY, (float)x, (float)y);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawSec(e.Graphics);
            DrawMin(e.Graphics);
            DrawHour(e.Graphics);
            e.Graphics.DrawString(DateTime.Now.ToString("HH:mm:ss"), new Font("맑은 고딕", 40), Brushes.White, 20, 20);
            DrawWatchNum(e.Graphics, 360);

        }

    }
}
