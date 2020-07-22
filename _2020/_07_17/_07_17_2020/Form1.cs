using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _07_17_2020
{
    public partial class Form1 : Form
    {
        const int RAD = 100;
        int MOVE_VAL = 20;
        Timer timer = new Timer();
        RectangleF rtf = new RectangleF(0,0,50,50);
        int chek = 0;
        

        // bool move = false;

        public Form1()
        {
            InitializeComponent();
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            this.Paint += Form1_Paint;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            timer.Start();
            Graphics g = e.Graphics;
            Pen myPen = new Pen(Brushes.DarkBlue, 5);

            g.FillEllipse(Brushes.Red, rtf);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (rtf.X >= this.ClientRectangle.Right - 60)
            { MOVE_VAL = -MOVE_VAL; chek = 1; }
            else if (rtf.X <= this.ClientRectangle.Left && chek == 1)
                MOVE_VAL = -MOVE_VAL;

            rtf.X += MOVE_VAL;
            Invalidate();
        }
    }
}
