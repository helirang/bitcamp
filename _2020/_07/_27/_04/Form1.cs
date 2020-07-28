using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Drawing2D;

namespace _04
{
    public partial class Form1 : Form
    {
        int centX, centY;
        const int RADIUS = 300;
        Timer timer = new Timer();
        int timeNum = 4;
        Size resize = new Size(790, 790);
        Bitmap resizeImage = null; // new Bitmap(sourceImage, resize);
        Bitmap sourceImage = null;
        int nowPhoto = 0;
        SoundPlayer putSound;

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
            putSound.Play();
            Invalidate();
        }

        private void Form1_Load1(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;
            this.DoubleBuffered = true;
            timer.Start();
            this.Width = 1000;
            this.Height = 1000;
            this.centX = this.Width / 2;
            this.centY = this.Height / 2;
            putSound = new SoundPlayer();
            putSound.SoundLocation = "../../짤깍.wav";
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

            miniX = this.centX + ((RADIUS-40) * Math.Cos(i * Math.PI / 180));
            miniY = this.centY + ((RADIUS-40) * Math.Sin(i * Math.PI / 180));
         

            if ((i == 0 || i % 30 == 0))
            {
            
                if (timeNum > 12)
                { timeNum = 1; }
                g.DrawString($"{timeNum}", new Font("맑은 고딕", 15), Brushes.Red, (float)miniX - 8, (float)miniY - 15); timeNum++;
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
            g.DrawLine(new Pen(Brushes.AliceBlue, 3), (float)centX, (float)centY, (float)x, (float)y);

            //if (sec == 45)
            //{ MessageBox.Show($"y = {y} x ={x}"); }
        }

        void DrawMin(Graphics g)
        {
            int min = Convert.ToInt32(DateTime.Now.ToString("mm"));
            min += 45;
            if (min > 60)
            { min = min % 60; }
            double x = this.centX + ((RADIUS - 80) * Math.Cos(min * Math.PI / 30));
            double y = this.centY + ((RADIUS - 80) * Math.Sin(min * Math.PI / 30));
            g.DrawLine(new Pen(Brushes.Crimson, 4), (float)centX, (float)centY, (float)x, (float)y);
        }

        void DrawHour(Graphics g)
        {
            int hour = Convert.ToInt32(DateTime.Now.ToString("hh"));
            hour += 9;
            if (hour > 12)
            { hour = hour % 12; }

            double x = this.centX + ((RADIUS - 150) * Math.Cos(hour * Math.PI / 6));
            double y = this.centY + ((RADIUS - 150) * Math.Sin(hour * Math.PI / 6));
            g.DrawLine(new Pen(Brushes.PaleGoldenrod, 8), (float)centX, (float)centY, (float)x, (float)y);
        }

        void DrawPix(Graphics g)
        {
            switch (nowPhoto)
            {
                case 0:
                    sourceImage = new Bitmap("../../0.jpg");
                    break;
                case 1:
                    sourceImage = new Bitmap("../../1.jpg");
                    break;
                case 2:
                    sourceImage = new Bitmap("../../2.jpg");
                    break;
                case 3:
                    sourceImage = new Bitmap("../../3.jpg");
                    break;
                case 4:
                    sourceImage = new Bitmap("../../4.jpg");
                    break;
                case 5:
                    sourceImage = new Bitmap("../../5.jpg");
                    break;
                case 6:
                    sourceImage = new Bitmap("../../6.jpg");
                    break;
                case 7:
                    sourceImage = new Bitmap("../../7.jpg");
                    break;
                case 8:
                    sourceImage = new Bitmap("../../8.jpg");
                    break;
                case 9:
                    sourceImage = new Bitmap("../../9.jpg");
                    break;
                case 10:
                    sourceImage = new Bitmap("../../10.jpg");
                    break;
                case 11:
                    sourceImage = new Bitmap("../../11.jpg");
                    break;
                case 12:
                    sourceImage = new Bitmap("../../12.jpg");
                    break;
            }
            resizeImage = new Bitmap(sourceImage, resize);
            g.FillEllipse(new TextureBrush(resizeImage),
              new RectangleF(200, 200, 600, 600));

            nowPhoto++;

            if (nowPhoto > 12)
            {
                nowPhoto = 0;
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawPix(e.Graphics);
            DrawSec(e.Graphics);
            DrawMin(e.Graphics);
            DrawHour(e.Graphics);
            e.Graphics.DrawString(DateTime.Now.ToString("HH:mm:ss"), new Font("맑은 고딕", 40), Brushes.White, 20, 20);
            DrawWatchNum(e.Graphics, 360);
        }

    }
}
