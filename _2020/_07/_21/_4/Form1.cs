using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _06
{
    public partial class Form1 : Form
    {
        const int textBoxSize = 20;
        int x = 100 , y = 100;
        int catX = 50, catY = 50;
        bool now = false;
        Timer timer = new Timer();
        Size resize = new Size(50, 50);
        Bitmap catImage = new Bitmap(@"../../Cat.jpg");
        Bitmap catRe = null;
        Bitmap mouseImage = new Bitmap(@"../../Mouse.jpg");
        Bitmap mouseRe = null;

        public Form1()
        {
            InitializeComponent();
            this.Paint += Form1_Paint;
            this.MouseMove += Form1_MouseMove;
            this.MouseDown += Form1_MouseDown;
            this.MouseUp += Form1_MouseUp;
            timer.Interval = 20;
            timer.Tick += Timer_Tick;
            timer.Start();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            catRe = new Bitmap(catImage, resize);
            mouseRe = new Bitmap(mouseImage, resize);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if(catX == x && catY ==y)
            { }
            else
            {
                if (catX > x)
                    catX -= (catX - x) / 10;
                else if (catX < x)
                    catX += (x - catX) / 10;
                if (catY > y)
                    catY -= (catY - y) / 10;
                else if (catY < y)
                    catY += (y- catY) / 10;
            }
            Invalidate();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            now = !now;
            Invalidate();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                now = !now;
            }
            this.x = e.X;
            this.y = e.Y;
            Invalidate();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(this.now)
            {
                this.x = e.X;
                this.y = e.Y;
                Invalidate();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Font f = new Font("맑은 고딕",10);
            if(now)
            {
                e.Graphics.DrawImage(mouseRe, x, y);
                //e.Graphics.DrawString("쥐", f, Brushes.Black, x, y);
            }
            e.Graphics.DrawImage(catRe, catX, catY);
            //e.Graphics.DrawString("고양이", f, Brushes.Black, catX, catY);
        }
    }
}
