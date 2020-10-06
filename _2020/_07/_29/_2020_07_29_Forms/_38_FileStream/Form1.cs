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

namespace _38_FileStream
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                string path = sfd.FileName;

                byte[] data = { 65, 66, 67, 68, 69, 70, 71, 72, 73, 74 };
                FileStream fs = 
                    new FileStream(path, FileMode.Create, FileAccess.Write);
                fs.Write(data, 0, data.Length);
                fs.Close();

                this.Text = path + "에 파일 저장";
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                byte[] data = new byte[10];

                string path = ofd.FileName;
                FileStream fs =
                    new FileStream(path, FileMode.Open, FileAccess.Read);
                fs.Read(data, 0, data.Length);
                fs.Close();

                string result = "";
                foreach (byte b in data)
                {
                    result += b.ToString() + ", ";
                }
                MessageBox.Show(result);
            }
        }
    }
}
