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
    class OneChek
    {
        public int chkW=0;
        public int chkC=0;
        public int chkState = 0;
    }
    public partial class Form1 : Form
    {
        const int numNemo = 70;
        Rectangle Nemo = new Rectangle(0, 0, 70, 70);
        int x = 0, y = 0;
        List<OneChek> oneChek = new List<OneChek>();
        int cnt = 0;
        bool chek = false;
        int chekColor = 0;
        Pen myPen = new Pen(Brushes.Black);
        Pen myRePen = new Pen(Brushes.Blue);
        public Form1()
        {
            InitializeComponent();
            this.Paint += Form1_Paint;
            this.MouseClick += Form1_MouseClick;
            this.Load += Form1_Load;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 32; i++)
            {
                oneChek.Add(new OneChek());
            }

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            this.x = e.X;
            this.y = e.Y;
            if(chek)
            {
                chekColor = 2;
            }
            else
            {
                chekColor = 1;
            }
            chek = !chek;
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        e.Graphics.DrawRectangle(myPen, Nemo);
                    if (Nemo.Left < x && Nemo.Right > x && Nemo.Top < y && Nemo.Bottom > y)
                    { oneChek[cnt].chkW = 1; oneChek[cnt].chkC = chekColor; }
                    if (oneChek[cnt].chkW == 1)
                    {
                        if (oneChek[cnt].chkC == 1)
                        {
                            if (oneChek[cnt].chkState == 0 || oneChek[cnt].chkState == 1)
                            { myRePen = new Pen(Brushes.Blue); oneChek[cnt].chkState = 1; }
                        }
                        else
                        {
                            if (oneChek[cnt].chkState == 0 || oneChek[cnt].chkState == 2)
                            { myRePen = new Pen(Brushes.Red); oneChek[cnt].chkState = 2; }
                        }
                        e.Graphics.DrawEllipse(myRePen, Nemo);
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
