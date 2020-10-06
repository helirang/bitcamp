using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _32_ModalForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnModalForm_Click(object sender, EventArgs e)
        {
            /* 폼을 띄우는 2가지 방식
             * 1) Modal 방식
             *    창이 나타나면 Main창에 포커스가 가지 않는다
             *    무조건 선택이나 취소를 강요하는 방식
             * 2) Modeless 방식
             *    창이 나타나도 Main창에 포커스가 간다
             *    Main창과 2개를 함께 사용하는 방식
             */
            MyForm myForm = new MyForm();
            myForm.ShowDialog();    // Modal 방식
        }
    }
}
