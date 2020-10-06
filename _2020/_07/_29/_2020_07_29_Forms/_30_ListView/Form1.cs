using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace _30_ListView
{
    public partial class Form1 : Form
    {
        int idx = 0;    // 순서 컬럼에 들어갈 데이터
        int selStyle = 0;   // 리스트뷰 스타일 선택

        public Form1()
        {
            InitializeComponent();
        }

        private void btnChangeStyle_Click(object sender, EventArgs e)
        {
            this.selStyle++;
            // 삼항 연산자(조건 연산자)
            this.selStyle = this.selStyle == 5 ?  0 : this.selStyle;
            switch (this.selStyle)
            {
                case 0:
                    listView1.View = View.Details;
                    break;
                case 1:
                    listView1.View = View.LargeIcon;
                    break;
                case 2:
                    listView1.View = View.SmallIcon;
                    break;
                case 3:
                    listView1.View = View.List;
                    break;
                case 4:
                    listView1.View = View.Tile;
                    break;
            }
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string[] items = { this.idx.ToString(), tbName.Text, tbAge.Text };

            listView1.Items.Add(new ListViewItem(items));
            idx++;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnInsertTempData_Click(object sender, EventArgs e)
        {
            string[][] tempData = new string[5][];
            tempData[0] = new string[] { idx++.ToString(), "홍길동", "24" };
            tempData[1] = new string[] { idx++.ToString(), "임꺽정", "33" };
            tempData[2] = new string[] { idx++.ToString(), "장길산", "34" };
            tempData[3] = new string[] { idx++.ToString(), "일지매", "25" };
            tempData[4] = new string[] { idx++.ToString(), "차돌바위", "35" };
            
            for(int i = 0; i < tempData.Length; i++)
            {
                listView1.Items.Add(new ListViewItem(tempData[i]));
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            /* 
             * Items는 행
             * SubItems는 열(컬럼)
             */
            // 현재 포커스가 있는 항목의 index를 달라
            int focusIndex = listView1.FocusedItem.Index;
            string str = "";
            for (int i = 0; i < listView1.Items[focusIndex].SubItems.Count; i++)
            {
                str += listView1.Items[focusIndex].SubItems[i].Text + ", ";
            }
            MessageBox.Show(str);
        }
    }
}
