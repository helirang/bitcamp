using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01
{
    public partial class Form1 : Form
    {
        Bitmap canv = new Bitmap(1024,768);
        Image image = null;
        Image image2 = null;

        Bitmap cat1 = new Bitmap("../../1.jpg");
        Bitmap cat2 = new Bitmap("../../2.jpg");
        Bitmap resize = null;
        
        // Pen myPen = null;
        List<memMa> mem = new List<memMa>();
 
        bool chekMouse = false;
        int x, y;
        public Form1()
        {
            InitializeComponent();
            this.Paint += Form1_Paint;
            this.Load += Form1_Load;
            this.MouseClick += Form1_MouseClick;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
           
            mem.Add(new memMa() { Mx = e.X, Yx = e.Y });
            if (e.Button == MouseButtons.Right)
            {
                mem[mem.Count - 1].State = 1;
            }
            else if (e.Button == MouseButtons.Left)
            {
                mem[mem.Count - 1].State = 2;
            }
            chekMouse = true;
            
            Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            resize = new Bitmap(cat1,150,150); 
            image = resize;
            resize = new Bitmap(cat2, 150, 150);
            image2 = resize;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
          
            if(chekMouse)
            {
                for (int i = 0; i < mem.Count(); i++ )
                {
                    if(mem[i].State ==1)
                    e.Graphics.DrawImage(image, mem[i].Mx, mem[i].Yx, new Rectangle(0, 20, 150, 150), GraphicsUnit.Pixel);
                    else if (mem[i].State == 2)
                    e.Graphics.DrawImage(image2, mem[i].Mx, mem[i].Yx, new Rectangle(0, 20, 150, 150), GraphicsUnit.Pixel);
                }
                chekMouse = false;
            }
        }
    }

    class memMa
    {
        public int Mx
        {
            get;set;
        }
        public int Yx
        {
            get; set;
        }
        public int State
        {
            get; set;
        } = 0;
    }
}
