using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _33_ModelessForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnModelessForm_Click(object sender, EventArgs e)
        {
            MyForm myForm = new MyForm();
            myForm.Show();  // Modeless방식 창 띄우기
        }
    }
}
