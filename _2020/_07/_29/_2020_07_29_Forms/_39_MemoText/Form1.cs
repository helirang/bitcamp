using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _39_MemoText
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnWriteMemo_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("memo.txt");
            sw.Write(tbMemo.Text);
            sw.Close();
        }

        private void btnReadMemo_Click(object sender, EventArgs e)
        {
            char[] buf = new char[1024];
            int ret = 0;
            StreamReader sr = new StreamReader("memo.txt");
            tbMemo.Clear();
            while (true)
            {
                // ret은 실제 읽어들인 크기
                ret = sr.Read(buf, 0, buf.Length);
                tbMemo.Text += new string(buf, 0, ret);
                if (ret < 1024)
                    break;
            }
            sr.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnClearMemo_Click(object sender, EventArgs e)
        {
            tbMemo.Clear();
        }
    }
}
