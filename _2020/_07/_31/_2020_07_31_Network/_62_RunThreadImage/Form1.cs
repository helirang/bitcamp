using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _14_RunThreadImage
{
    public partial class Form1 : Form
    {
        Image[] images = new Image[3];
        Rectangle[] imgRects = new Rectangle[3];
        int imgHeight = 0, imgWidth = 0;
        Random rand = new Random();

        Thread tJang;
        Thread tPark;
        Thread tIu;
        bool isRunJang = true;
        bool isRunPark = true;
        bool isRunIu = true;

        string winner = null;

        bool isRace = false;

        public Form1()
        {
            InitializeComponent();

            this.BackColor = Color.Black;
            this.DoubleBuffered = true;

            this.Paint += Form1_Paint;
            this.MouseDoubleClick += Form1_MouseDoubleClick;
            this.FormClosed += Form1_FormClosed;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(tJang.IsAlive)
                tJang.Abort();
            if(tPark.IsAlive)
                tPark.Abort();
            if(tIu.IsAlive)
                tIu.Abort();
        }

        void ThreadJang()
        {
            int sign = 1;
            do
            {
                imgRects[0].X += rand.Next(20) * sign;
                Invalidate();
                Thread.Sleep(rand.Next(100));

                if (imgRects[0].Right > this.ClientRectangle.Right)
                    sign = -sign;

                if(sign == -1 && imgRects[0].X < 0)
                {
                    Monitor.Enter(this);
                    winner = "장나라";
                    Invalidate();
                    isRunPark = false;
                    isRunIu = false;
                    Thread.Sleep(150);
                    isRunJang = false;
                    Monitor.Exit(this);
                }
            } while (isRunJang) ;
        }

        void ThreadPark()
        {
            int sign = 1;
            do
            {
                imgRects[1].X += rand.Next(20) * sign;
                Invalidate();
                Thread.Sleep(rand.Next(100));

                if (imgRects[1].Right > this.ClientRectangle.Right)
                    sign = -sign;


                if (sign == -1 && imgRects[1].X < 0)
                {
                    Monitor.Enter(this);
                    winner = "박보영";
                    Invalidate();
                    isRunIu = false;
                    isRunJang = false;
                    Thread.Sleep(150);
                    isRunPark = false;
                    Monitor.Exit(this);
                }
            }while (isRunPark) ;
        }

        void ThreadIu()
        {
            int sign = 1;
            do
            {
                imgRects[2].X += rand.Next(20) * sign;
                Invalidate();
                Thread.Sleep(rand.Next(100));

                if (imgRects[2].Right > this.ClientRectangle.Right)
                    sign = -sign;

                if (sign == -1 && imgRects[2].X < 0)
                {
                    Monitor.Enter(this);
                    winner = "아이유";
                    Invalidate();
                    isRunPark = false;
                    isRunJang = false;
                    Thread.Sleep(150);
                    isRunIu = false;
                    Monitor.Exit(this);
                }
            }while (isRunIu) ;
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                if (!isRunJang)
                {
                    isRace = false;
                    winner = null;
                    isRunJang = isRunPark = isRunIu = true;
                    InitRects();
                    InitThreads();
                }
                if (!isRace)
                {
                    isRace = true;
                    // 스레드 3개 동작하기
                    tJang.Start();
                    tPark.Start();
                    tIu.Start();
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Brushes.DarkBlue, 3);
            Pen penGold = new Pen(Brushes.Gold, 5);

            if (winner != null)
            {
                Font f = new Font("맑은 고딕", 64);
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                g.DrawString(winner, f, Brushes.Gold, this.ClientRectangle.Width / 2, this.ClientRectangle.Height / 2, sf);
                return;
            }

            for(int i = 0; i < images.Length; i++)
            {
                g.DrawLine(penGold, 0, imgRects[i].Y, this.ClientRectangle.Right, imgRects[i].Y);
                g.DrawImage(images[i], imgRects[i]);
                g.DrawRectangle(pen, imgRects[i]);
            }
        }

        void InitRects()
        {
            imgRects[0].X = 0;
            imgRects[0].Y = 0;
            imgRects[0].Width = imgWidth;
            imgRects[0].Height = imgHeight;

            imgRects[1].X = 0;
            imgRects[1].Y = imgHeight;
            imgRects[1].Width = imgWidth;
            imgRects[1].Height = imgHeight;

            imgRects[2].X = 0;
            imgRects[2].Y = imgHeight * 2;
            imgRects[2].Width = imgWidth;
            imgRects[2].Height = imgHeight;
        }

        void SetNullThreads()
        {
            if (tJang.IsAlive)
                tJang.Abort();
            if (tPark.IsAlive)
                tPark.Abort();
            if (tIu.IsAlive)
                tIu.Abort();
            tJang = tPark = tIu = null;
        }

        void InitThreads()
        {
            tJang = new Thread(new ThreadStart(ThreadJang));
            tJang.IsBackground = true;
            tPark = new Thread(new ThreadStart(ThreadPark));
            tPark.IsBackground = true;
            tIu = new Thread(new ThreadStart(ThreadIu));
            tIu.IsBackground = true;
        }

        void InitImages()
        {
            images[0] = Image.FromFile("장나라.jpg");
            images[1] = Image.FromFile("박보영.jpg");
            images[2] = Image.FromFile("아이유.jpg");

            imgHeight = this.ClientRectangle.Height / 3;
            imgWidth = this.ClientRectangle.Width / 7;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1200, 600);

            InitImages();

            InitRects();
            InitThreads();
        }
    }
}
