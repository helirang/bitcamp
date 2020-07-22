using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02_re
{
    public partial class Form1 : Form
    {

        int drawx = 210;
        int x=0, y=0;
        Timer timer = new Timer();
        Rectangle rec = new Rectangle(20,20,20,20);
        Image image = Image.FromFile(@"../../ani.png");



        public Form1()
        {
            InitializeComponent();
            this.Paint += Form1_Paint;
            timer.Interval = 120;
            timer.Tick += Timer_Tick;
            timer.Start();
            this.MouseClick += Form1_MouseClick;
            this.KeyDown += Form1_KeyDown;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Up:
                    if (timer.Interval >= 21)
                    timer.Interval -= 20;
                    break;
                case Keys.Down:
                    timer.Interval += 20;
                    break;
                case Keys.Left:
                    x -= 10;
                    break;
                case Keys.Right:
                    x += 10;
                    break;
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
            Invalidate();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            drawx += 210;
            if(drawx > 1000)
            { drawx = 210; }
            Invalidate();
        }

   

    

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(image, x-105, y-125, new Rectangle(drawx, 50, 210, 300), GraphicsUnit.Pixel);
        }
    }
}
