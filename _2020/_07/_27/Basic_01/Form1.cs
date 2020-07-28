using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Basic_01
{
    public partial class Form1 : Form
    {
        int mouseX, mouseY;
        int centX, centY;
        const int RADIUS = 300;
        int cnt = 360;
        bool chek = false;

        public Form1()
        {
            InitializeComponent();
            this.Paint += Form1_Paint;
            this.Load += Form1_Load;
            this.MouseUp += Form1_MouseUp;
            this.MouseDown += Form1_MouseDown;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
            Invalidate();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;
            this.DoubleBuffered = true;
            this.Width = 1000;
            this.Height = 1000;
            this.centX = this.Width / 2;
            this.centY = this.Height / 2;
        }



        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int degree = 360 / cnt;

            for (int i = 0; i < 360; i += degree)
            {
                double x = this.centX + (RADIUS * Math.Cos(i * Math.PI / 180));
                double y = this.centY + (RADIUS * Math.Sin(i * Math.PI / 180));
                e.Graphics.FillEllipse(Brushes.AliceBlue,
                    new RectangleF((float)x - 10, (float)y - 10, 20, 20));

                if (x - 10 <= mouseX && x + 490 >= mouseX && y - 10 <= mouseY && y + 490 >= mouseY)
                {
                    chek = true;
                }
            }
            if(chek)
            {
                e.Graphics.DrawRectangle(new Pen(Brushes.Gold,30),
                  200, 200, 600, 600);
                e.Graphics.DrawString($"Click", new Font("맑은 고딕", 50), Brushes.GreenYellow, (float)centX -75, (float)centY-50);
                mouseX = 0; mouseY = 0;
                chek = false;
            }
        }
    }
}
