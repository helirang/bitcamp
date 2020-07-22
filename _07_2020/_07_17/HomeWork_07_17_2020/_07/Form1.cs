using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _07
{
    public partial class Form1 : Form
    {
        const int RAD = 60;
        const int MOVE_VAL = 20;
        int drawTwoX = -61;
        int drawTowY = 0;
        Timer timer = new Timer();
        int x = 60, y = 0;
        bool chek = true;
        int chekMove = 4;

        public Form1()
        {
            InitializeComponent();
            this.Paint += Form1_Paint;
            this.KeyDown += Form1_KeyDown;
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (chek)
                    {
                        timer.Start();
                        chek = !chek;
                    }
                    else
                    {
                        timer.Stop();
                        chek = !chek;
                    }
                    break;
                case Keys.Down:
                    chekMove = 1;
                    drawTwoX = 0;
                    drawTowY = -61;
                    break;
                case Keys.Up:
                    chekMove = 2;
                    drawTwoX = 0;
                    drawTowY = 61;
                    break;
                case Keys.Left:
                    chekMove = 3;
                    drawTwoX = 61;
                    drawTowY = 0;
                    break;
                case Keys.Right:
                    chekMove = 4;
                    drawTwoX = -61;
                    drawTowY = 0;
                    break;
            }
            Invalidate();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            switch (chekMove)
            {
                case 4:
                    if (x < this.ClientRectangle.Right - 60)
                        x += MOVE_VAL;
                    break;
                case 3:
                    if (x > 0)
                        x -= MOVE_VAL;
                    break;
                case 2:
                    if (y > 0)
                        y -= MOVE_VAL;
                    break;
                case 1:
                    if (y < this.ClientRectangle.Bottom - 70)
                        y += MOVE_VAL;
                    break;
            }
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen myPen = new Pen(Brushes.Red);
            g.DrawEllipse(myPen, x, y, RAD, RAD); // 시작 좌표, 너비, 높이
            Pen myTwoPen = new Pen(Brushes.DarkBlue);
            g.DrawEllipse(myTwoPen, x + drawTwoX, y + drawTowY, RAD, RAD);
        }
    }
}
