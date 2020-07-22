using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _05
{
    public partial class Form1 : Form
    {
        const int numNemo = 70;
        Rectangle Nemo = new Rectangle(0, 0, 70, 70);
        int x = 0, y = 0;
        int[] oneChek = new int[32] { 0,0,0,0,0,0,0,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        int cnt = 0;
        public Form1()
        {
            InitializeComponent();
            this.Paint += Form1_Paint;
            this.MouseMove += Form1_MouseMove;
            this.MouseDown += Form1_MouseDown;

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.x = e.X;
            this.y = e.Y;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen myPen = new Pen(Brushes.Black);

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        e.Graphics.DrawRectangle(myPen, Nemo);
                    if (Nemo.Left < x && Nemo.Right > x && Nemo.Top < y && Nemo.Bottom > y)
                        oneChek[cnt] = 1;
                    if (oneChek[cnt] == 1)
                    {
                        e.Graphics.DrawEllipse(myPen, Nemo);
                    }
                    cnt++;
                    Nemo.X += numNemo;
                    }
                    Nemo.X = 0;
                    Nemo.Y += numNemo;
                }
            Nemo.X = 0;
            Nemo.Y = 0;
            cnt = 0;

        }
    }
}
