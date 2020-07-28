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

namespace _omo_2
{
    public partial class Form1 : Form
    {
        List<myBox> chkB = new List<myBox>();
        const int x = 40, y = 40;
        const int map = 20;
        int mouseX, mouseY;
        bool mouseColor = true;
        Brush myBrush;
        int nowBox = 0;
        bool winChek = false;
        int winerBOx = 0;
        int winerX = 0,  winerY = 0;
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

            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            for (int i = 0; i < map; i++)
            {
                for (int j = 0; j < map; j++)
                {
                    if (j == 19 || i == 19)
                    { }
                    else
                    { e.Graphics.DrawRectangle(new Pen(Brushes.Black), j * x + x / 2, i * y + y / 2, x, y); }
                   // e.Graphics.DrawString(nowBox.ToString(), new Font("맑은 고딕", 10), Brushes.Red, j * x, i * y);
                    if (j * x < mouseX && mouseX < (j * x) + 40 && i * y < mouseY && mouseY < (i * y) + 40)
                    {
                        if (chkB[nowBox].BoxState == 1)
                        {
                            MessageBox.Show("이미 돌이 있습니다!!", "");
                        }
                        else
                        {
                            mouseColor = !mouseColor;
                            chkB[nowBox].BoxState = 1;
                            if (mouseColor) chkB[nowBox].BoxColor = 1;
                            else chkB[nowBox].BoxColor = 2;
                        
                            for (int chekWin = 0; chekWin < 8; chekWin++)
                            {
                                int chkBoxX = 0, chkBoxY = 0;
                                int subX = 0, subY = 0;
                                switch (chekWin)
                                {
                                    case 0:
                                        subX = 1;
                                        break;
                                    case 1:
                                        subX = -1;
                                        break;
                                    case 2:
                                        chkB[nowBox].WinNum = 0;
                                        subY = map;
                                        break;
                                    case 3:
                                        subY = -map;
                                        break;
                                    case 4:
                                        chkB[nowBox].WinNum = 0;
                                        subX = 1;
                                        subY = map;
                                        break;
                                    case 5:
                                        subX = -1;
                                        subY = -map;
                                        break;
                                    case 6:
                                        chkB[nowBox].WinNum = 0;
                                        subX = 1;
                                        subY = -map;
                                        break;
                                    case 7:
                                        subX = -1;
                                        subY = map;
                                        break;
                                }
                                for (int chekNumer = 0; chekNumer < 5; chekNumer++)
                                {
                                    if (chkB[nowBox].BoxColor == chkB[nowBox + chkBoxX + chkBoxY].BoxColor)
                                    { chkB[nowBox].WinNum += 1; }
                                    if (chkB[nowBox].WinNum == 5)
                                    { winChek = true; winerBOx = nowBox; winerX = j; winerY = i; }

                                    chkBoxX += subX;
                                    chkBoxY += subY;

                                    if (subX < 0 && (nowBox % 20 == 0 || nowBox == 0) || subX > 0 && (nowBox % (19 + i * map) == 0 || nowBox + chkBoxX > 399))
                                    { break; }
                                    if (subY < 0 && (nowBox + chkBoxY < 0) || subY > 0 && (nowBox + chkBoxY > 399))
                                    { break; }
                                    if (subX < 0 && subY < 0 && nowBox - chkBoxX - chkBoxY < 0 || subX > 0 && subY > 0 && nowBox + chkBoxX + chkBoxY > 399)
                                    { break; }

                                    //e.Graphics.DrawString(chkBoxX.ToString(), new Font("맑은 고딕", 10), Brushes.Red, j * x, i * y); Thread.Sleep(1000);
                                }
                                chkB[nowBox].WinNum -= 1;
                            }
                        }
                    }
                    if (chkB[nowBox].BoxState == 1)
                    {
                        if (chkB[nowBox].BoxColor == 1)
                            myBrush = Brushes.White;
                        else
                            myBrush = Brushes.Black;
                        e.Graphics.FillEllipse(myBrush, j * x, i * y, x, y);
                        //  e.Graphics.DrawString(nowBox.ToString(), new Font("맑은 고딕", 10), Brushes.Red, j * x, i * y);
                    }
                    // e.Graphics.DrawString(chkB[nowBox].WinNum.ToString(), new Font("맑은 고딕", 10), Brushes.Red, j * x, i * y);
                    nowBox++;
                }
            }
            nowBox = 0;
            if (winChek)
            { endGame(chkB[winerBOx].BoxColor); winChek = !winChek; }
        }

        private void endGame(int color)
        {
            Graphics e = this.CreateGraphics();
            if(color == 1)
            { myBrush = Brushes.White; }
            else
            { myBrush = Brushes.Black; }
            e.FillEllipse(myBrush, winerX * x, winerY * y, x, y);
            if (color == 1)
                MessageBox.Show("백돌이 이겼습니다!!", "");
            else
                MessageBox.Show("흙돌이 이겼습니다!!", "");

            chkB.Clear();
            for (int i = 0; i < map; i++)
            {
                for (int j = 0; j < map; j++)
                {
                    chkB.Add(new myBox());
                }
            }
            mouseX = 0;
            mouseColor = true;
            Invalidate();
            //Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            this.BackColor = Color.DarkGoldenrod;
            this.Width = (x * (map + 1)) + 18;
            this.Height = (y * (map + 1)) + 41;
            myBrush = Brushes.Black;
            for (int i = 0; i < map; i++)
            {
                for (int j = 0; j < map; j++)
                {
                    chkB.Add(new myBox());
                }
            }
            //this.DoubleBuffered = true;
        }

        class myBox
        {
            public int BoxState
            { get; set; } = 0;
            public int BoxColor
            { get; set; } = 0;

            public int WinNum
            { get; set; } = 0;
        }
    }
}
