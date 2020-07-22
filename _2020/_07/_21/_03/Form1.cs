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
        Random r = new Random();
        Timer timer = new Timer();
        int chekNum = 4;
        int height = 160;
        int j = 0;
        int jNum = 4;
        Pen myPen = new Pen(Brushes.White);
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            this.Paint += Form1_Paint;
            timer.Interval = 1500;
            timer.Tick += Timer_Tick;
            this.BackColor = Color.Black;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            chekNum = r.Next(3);
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            for(int i = 0; i < 3; i++)
            { e.Graphics.DrawEllipse(myPen, 0, height * i + j , 130, height); j += jNum; }

            switch (chekNum)
            {
                case 0:
                    e.Graphics.FillEllipse(Brushes.Red, 0, height * chekNum , 130, height);
                    break;
                case 1:
                    e.Graphics.FillEllipse(Brushes.Yellow, 0, height * chekNum + (j - jNum*2), 130, height);
                    break;
                case 2:
                    e.Graphics.FillEllipse(Brushes.Green, 0, height * chekNum + (j - jNum), 130, height);
                    break;
            }
            j = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 150;
            this.Height = 550;
            timer.Start();
        }
    }
}
