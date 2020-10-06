using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _34_ModelessForm
{
    public partial class Form1 : Form
    {
        MyForm myForm = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnModelessForm_Click(object sender, EventArgs e)
        {
            if(myForm==null || myForm.IsDisposed)
            {
                myForm = new MyForm();
                myForm.Show();
            }
        }
    }
}
