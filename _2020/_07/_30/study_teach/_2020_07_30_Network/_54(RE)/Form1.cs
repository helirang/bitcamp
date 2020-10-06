using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _54_RE_
{
    public partial class Form1 : Form
    {
        const int imagePhotoY = 180;
        bool start = false;
        Bitmap bitmap1 = new Bitmap(new Bitmap("../../박보영.jpg"), 150, 180);
        Bitmap bitmap2 = new Bitmap(new Bitmap("../../아이유.jpg"), 150, 180);
        Bitmap bitmap3 = new Bitmap(new Bitmap("../../장나라.jpg"), 150, 180);
        public object lockTH = new object();

        delegate void d();
        Random rand = new Random();

        List<moveXY> moveP = new List<moveXY>();

        Thread b;
        Thread i;
        Thread j;


        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            this.Paint += Form1_Paint;
            this.DoubleClick += Form1_DoubleClick;
        }

        class moveXY
        {
            public int X { get; set; }
            public int Y { get; set; }

            public bool right { get; set; } = false;

            public Image image { get; set; }

            public bool gameEnd { get; set; } = false;

            public moveXY(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            start = true;
            b = new Thread(() => MovePhoto(0, moveP[0].X, moveP[0].Y));
            b.IsBackground = true;
            i = new Thread(() => MovePhoto(1, moveP[1].X, moveP[1].Y));
            i.IsBackground = true;
            j = new Thread(() => MovePhoto(2, moveP[2].X, moveP[2].Y));
            j.IsBackground = true;

            b.Start();
            i.Start();
            j.Start();
            Invalidate();
        }


        private void MovePhoto(int photoNum, int moveX, int moveY)
        {

            //Image image = bitmap1;
            //Graphics g = CreateGraphics();
            int x_ = 0;
            while (true)
            {

                x_ = this.rand.Next(80) + 40;
                //g.FillRectangle(Brushes.Black, moveP[photoNum].X, moveP[photoNum].Y, 150, 180);
                if (moveP[photoNum].right)
                { x_ *= -1; }
                moveP[photoNum].X += x_;

                if (moveP[photoNum].X >= this.Right - 150 && !moveP[photoNum].right)
                {
                    moveP[photoNum].X = this.Right - 300;
                    moveP[photoNum].right = true;
                }
                else if (moveP[photoNum].right)
                {
                    if (moveP[photoNum].X <= 0)
                    {
                        moveP[photoNum].gameEnd = true;
                        //DrawThLine(g);
                        //g.DrawImage(moveP[photoNum].image, moveP[photoNum].X, moveP[photoNum].Y);
                        break;
                    }
                }
                Console.WriteLine($"{moveP[photoNum].Y}");
                //DrawThLine(g);
                //DrawThLine(g);
                //g.DrawImage(moveP[photoNum].image, moveP[photoNum].X, moveP[photoNum].Y);
                Thread.Sleep(500);
            }
            Thread.Sleep(100);
            //Application.Exit();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;
            this.Width = 1000;
            this.Height = (imagePhotoY * 3) + 65;
            this.DoubleBuffered = true;
            Image image = bitmap1;
            for (int i = 0; i < 3; i++)
            {
                moveP.Add(new moveXY(0, imagePhotoY * i));
                switch (i)
                {
                    case 0:
                        image = bitmap1;
                        break;
                    case 1:
                        image = bitmap2;
                        break;
                    case 2:
                        image = bitmap3;
                        break;
                }
                moveP[i].image = image;
            }
        }
        private void DrawThLine(Graphics e)
        {
            Pen linePen = new Pen(Brushes.Yellow, 10);
            for (int i = 0; i < 3; i++)
            {
                e.DrawLine(linePen, 0, (imagePhotoY * i) + (i * 10) - 5, this.Right, (imagePhotoY * i) + (i * 10) - 5);
                if (!start)
                    e.DrawRectangle(new Pen(Brushes.BlueViolet, 3), 0, (imagePhotoY * i) + i * 10, 150, 180);
            }
        }

        private void DrawPhoto(Graphics e)
        {
            for (int i = 0; i < 3; i++)
            { 
                moveP[i].Y = (imagePhotoY * i) + i * 10;
                e.DrawImage(moveP[i].image, 0, (imagePhotoY * i) + i * 10);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawThLine(e.Graphics);
            if (!start)
            {
                DrawPhoto(e.Graphics);
            }
            else
            {
                //while (true)
                //{
                    for (int i = 0; i < 3; i++)
                    {
                        DrawThLine(e.Graphics);
                        e.Graphics.DrawImage(moveP[i].image, moveP[i].X, moveP[i].Y);
                        if (moveP[i].gameEnd)
                        { Application.Exit(); }
                    }
                Thread.Sleep(1000);
                //}
            }
        }
    }
}
