using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _omo_1
{
    public partial class Form1 : Form
    {
        List<myBox> chkB = new List<myBox>();
        const int x = 40, y = 40;
        const int map = 19;
        int mouseX, mouseY;
        bool mouseColor = true;
        Brush myBrush;
        int nowBox = 0;
        public Form1()
        {
            InitializeComponent();

            this.Load += Form1_Load;
            this.Paint += Form1_Paint;
            this.MouseClick += Form1_MouseClick;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
            mouseColor = !mouseColor;
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < map; i++)
            {
                for (int j = 0; j < map; j++)
                {
                    e.Graphics.DrawRectangle(new Pen(Brushes.Black), j * x, i * y, x, y);
                    if (j * x < mouseX && mouseX < (j * x) + 40 && i * y < mouseY && mouseY < (i * y) + 40)
                    {
                        chkB[nowBox].BoxState = 1;
                        if (mouseColor) chkB[nowBox].BoxColor = 1;
                        else chkB[nowBox].BoxColor = 2;
                    }
                    if (chkB[nowBox].BoxState == 1)
                    {
                        if (chkB[nowBox].BoxColor == 1)
                            myBrush = Brushes.White;
                        else
                            myBrush = Brushes.Black;
                        e.Graphics.FillEllipse(myBrush, j * x, i * y, x, y);
                    }
                    nowBox++;
                }
            }
            nowBox = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.DarkGoldenrod;
            this.Width = (x * map) + 18;
            this.Height = (y * map) + 41;
            myBrush = Brushes.Black;
            for (int i = 0; i < map; i++)
            {
                for (int j = 0; j < map; j++)
                {
                    chkB.Add(new myBox());
                }
            }
            this.DoubleBuffered = true;
        }

        class myBox
        {
            public int BoxState
            { get; set; } = 0;
            public int BoxColor
            { get; set; } = 0;
        }
    }
}
