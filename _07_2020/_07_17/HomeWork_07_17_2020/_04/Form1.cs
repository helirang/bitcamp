using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _04
{
    public partial class Form1 : Form
    {
        const int RAD = 100;
        int MOVE_x = 20;
        int MOVE_y = 20;
        int moveKey = 20;
        Timer timer = new Timer();
        RectangleF rtf = new RectangleF(0, 0, 50, 50);
        Rectangle rectangle = new Rectangle(200,100,100,30);
        int chek = 0;
        int score = 0;
        Random rand = new Random();

        public Form1()
        {

            InitializeComponent();
            this.KeyDown += Form1_KeyDown;
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            this.Paint += Form1_Paint;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (rectangle.X < 20)
                    { }
                        else
                    rectangle.X -= moveKey;
                    break;
                case Keys.Right:
                    if (rectangle.X < this.ClientRectangle.Right-100)
                    { rectangle.X += moveKey; }
                    else
                    { }
                    break;
                case Keys.Up:
                    if (rectangle.Y < 20)
                    { }
                    else
                        rectangle.Y -= moveKey;
                    break;
                case Keys.Down:
                    if (rectangle.Y < this.ClientRectangle.Bottom-30)
                    { rectangle.Y += moveKey; }
                    else
                    { }
                    break;
            }
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            timer.Start();
            Graphics g = e.Graphics;
            
         
            if ((rectangle.Left <= rtf.Left && rectangle.Right >= rtf.Left || rectangle.Left <= rtf.Right && rectangle.Right >= rtf.Right)
                && rectangle.Top <= rtf.Bottom && rectangle.Bottom >= rtf.Bottom)
            { MOVE_y = -MOVE_y; rtf.Y = rectangle.Top - 51; score++; }
            else if ((rectangle.Left <= rtf.Left && rectangle.Right >= rtf.Left || rectangle.Left <= rtf.Right && rectangle.Right >= rtf.Right)
               &&  rectangle.Bottom >= rtf.Top && rectangle.Top <= rtf.Top)
            { MOVE_y = -MOVE_y; rtf.Y = rectangle.Bottom + 1; score++; }
           

            g.FillRectangle(Brushes.White, rectangle);
            g.FillEllipse(Brushes.Red, rtf);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (rtf.X >= this.ClientRectangle.Right - 60)
            { MOVE_x = -MOVE_x; chek = 1; }
            else if (rtf.X <= this.ClientRectangle.Left && chek == 1)
                MOVE_x = -MOVE_x;

            if (rtf.Y >= this.ClientRectangle.Bottom - 60) 
            { MOVE_y = -MOVE_y; chek = 1; }
            else if (rtf.Y <= this.ClientRectangle.Top && chek == 1)
                MOVE_y = -MOVE_y;

            rtf.X += MOVE_x;
            rtf.Y += MOVE_y;
            Invalidate();
        }
    }
}
