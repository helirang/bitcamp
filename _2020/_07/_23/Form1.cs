using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _23
{
    public partial class Form1 : Form
    {
        List<user> snake = new List<user>();
        List<user> hood = new List<user>();
        Random r = new Random();
        Timer timer = new Timer();
        int Back1X = 0, Back1Y = 0;
        int Back2X = 780, Back2Y = 820;
        const int boxSize = 20, moveBack = 50;
        const int widthMap = 817, HeightMap = 880;
        const int userStart = 120, useStartTail = 5;
        int moveY = 20;
        int moveX = 20;
        bool chekTimer = false;

        Pen myPen = null;
        Pen userPen = null;

        public Form1()
        {
            InitializeComponent();
            this.Paint += Form1_Paint;
            this.Load += Form1_Load;
            this.KeyDown += Form1_KeyDown;
            this.timer.Interval = 300;
            this.timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            snake.Add(new user());
            snake[snake.Count - 1].X = snake[snake.Count - 2].X;
            snake[snake.Count - 1].Y = snake[snake.Count - 2].Y;
            snake[snake.Count - 1].Tail = snake[snake.Count - 2].Tail;
            snake[snake.Count - 1].TailMove = snake[snake.Count - 2].TailMove;
            if (snake[snake.Count - 1].TailMove == 1 || snake[snake.Count - 1].TailMove == 2)
                snake[snake.Count - 1].Y += moveY;
            else
                snake[snake.Count - 1].X += moveX;

            for (int j = 0; j < hood.Count; j++)
            {
                if (snake[snake.Count - 1].X+20 >= hood[j].X && snake[snake.Count - 1].X - 20 <= hood[j].X &&
                    snake[snake.Count - 1].Y + 20 >= hood[j].Y && snake[snake.Count - 1].Y - 20 <= hood[j].Y)
                {
                    hood.RemoveAt(j);
                    snake[snake.Count - 1].Tail += 1;
                }
            }
            if(snake.Count > snake[snake.Count-1].Tail)
            {
                snake.RemoveAt(0);
            }
            //if (snake[snake.Count - 1].X <= boxSize || snake[snake.Count - 1].Y >= boxSize)
            //{
            //    sn
            //}
            //else if()
            //{

            //}
            Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    moveX = -20;
                    snake[snake.Count - 1].TailMove = 3;
                    break;
                case Keys.Right:
                    moveX = 20;
                    snake[snake.Count - 1].TailMove = 4;
                    break;
                case Keys.Up:
                    moveY = -20;
                    snake[snake.Count - 1].TailMove = 1;
                    break;
                case Keys.Down:
                    moveY = 20;
                    snake[snake.Count - 1].TailMove = 2;
                    break;
                case Keys.Enter:
                    chekTimer = !chekTimer;
                    if (chekTimer)
                    { timer.Start();  }
                    else timer.Stop();
                    break;
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = widthMap;
            this.Height = HeightMap;
            this.DoubleBuffered = true;
            myPen = new Pen(Brushes.White, 3);
            userPen = new Pen(Brushes.Red, 3);
            for (int i = 0; i < useStartTail; i++)
            {
                snake.Add(new user());
                snake[i].X = userStart + i * boxSize;
                snake[i].Y = userStart;
                snake[i].Tail = useStartTail;
            }
            for (int i = 0; i < useStartTail; i++)
            {
                hood.Add(new user());
                hood[i].X = r.Next(780);
                hood[i].Y = r.Next(820);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < widthMap / boxSize; i++)
            {
                e.Graphics.DrawRectangle(myPen, Back1X, Back1Y, boxSize, boxSize);
                e.Graphics.DrawRectangle(myPen, Back1X, Back2Y, boxSize, boxSize);
                Back1X += boxSize;
            }
            Back1X = 0;
            for (int i = 0; i < HeightMap / boxSize - 3; i++)
            {
                e.Graphics.DrawRectangle(myPen, Back1X, Back1Y, boxSize, boxSize);
                e.Graphics.DrawRectangle(myPen, Back2X, Back1Y, boxSize, boxSize);
                Back1Y += boxSize;
            }
            Back1Y = 0;
            for (int j = snake.Count - snake[snake.Count - 1].Tail; j< snake.Count; j++)
            {
                e.Graphics.DrawRectangle(userPen, snake[j].X, snake[j].Y, boxSize, boxSize);
                e.Graphics.FillEllipse(Brushes.Red, snake[j].X, snake[j].Y, boxSize, boxSize);
            }
            for (int j = 0; j < hood.Count; j++)
            {
                e.Graphics.FillEllipse(Brushes.GreenYellow, hood[j].X, hood[j].Y, boxSize, boxSize);
            }


        }
    }

    class user
    {
        public int X
        { get; set; }
        public int Y
        { get; set; }
        public int Tail
        { get; set; }
        public int TailMove
        { get; set; } = 0;
    }

}
