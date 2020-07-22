using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _13_TextureBrush
{
    public partial class Form1 : Form
    {
        Image image = null;
        TextureBrush tBrush = null;
        int changeImg = 1;
        public Form1()
        {
            InitializeComponent();
            this.Paint += Form1_Paint;
            this.Load += Form1_Load;
            this.MouseClick += Form1_MouseClick;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            switch (changeImg)
            {
                case 0:
                    image = Image.FromFile("../../1.jpg");
                    tBrush = new TextureBrush(image);
                    break;
                case 1:
                    image = Image.FromFile("../../2.jpg");
                    tBrush = new TextureBrush(image);
                    break;
                case 2:
                    image = Image.FromFile("../../3.jpg");
                    tBrush = new TextureBrush(image);
                    break;
                case 3:
                    image = Image.FromFile("../../4.jpg");
                    tBrush = new TextureBrush(image);
                    break;
                case 4:
                    image = Image.FromFile("../../5.jpg");
                    tBrush = new TextureBrush(image);
                    break;
                case 5:
                    image = Image.FromFile("../../6.jpg");
                    tBrush = new TextureBrush(image);
                    break;
                case 6:
                    image = Image.FromFile("../../7.jpg");
                    tBrush = new TextureBrush(image);
                    break;
                case 7:
                    image = Image.FromFile("../../8.jpg");
                    tBrush = new TextureBrush(image);
                    break;
                case 8:
                    image = Image.FromFile("../../9.jpg");
                    tBrush = new TextureBrush(image);
                    break;
                case 9:
                    image = Image.FromFile("../../10.jpg");
                    tBrush = new TextureBrush(image);
                    break;


            }
            if(changeImg==9)
            { changeImg = 0; }
            else
            {
                changeImg++;
            }
            Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            image = Image.FromFile("../../1.jpg");
            tBrush = new TextureBrush(image);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(tBrush, this.ClientRectangle);
        }
    }
}
