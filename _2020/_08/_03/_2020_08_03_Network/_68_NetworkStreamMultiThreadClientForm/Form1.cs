using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _64_NetworkStreamMultiThreadClientForm
{
    public partial class Form1 : Form
    {
        Socket clientSocket;
        IPEndPoint ipep;        // 서버의 접속 주소

        NetworkStream ns;
        StreamWriter sw;

        Thread tRecv;
        bool isRecv = true;

        delegate void AddLogData(string data);
        AddLogData addLogData = null;

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            this.FormClosed += Form1_FormClosed;
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.isRecv = false;
                if (this.clientSocket != null &&
                    this.clientSocket.Connected)
                    this.clientSocket.Close();
            }catch(Exception ex)
            {
                AddLogListBox("Exception : " + ex.Message);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.addLogData = AddLogListBox;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            this.isRecv = true;
            this.clientSocket =
                new Socket(AddressFamily.InterNetwork,
                            SocketType.Stream,
                            ProtocolType.Tcp);
            this.ipep =
                new IPEndPoint(IPAddress.Parse(tbIp.Text),
                                Int32.Parse(tbPort.Text));
            AddLogListBox("서버 접속 요청중...");
            this.clientSocket.Connect(this.ipep);
            AddLogListBox("서버 접속 완료");

            this.ns = new NetworkStream(this.clientSocket);
            this.sw = new StreamWriter(this.ns);

            this.tRecv = new Thread(new ThreadStart(ThreadRecv));
            this.tRecv.IsBackground = true;
            this.tRecv.Start();

            btnConnect.Enabled = false;
            btnDisconnect.Enabled = true;
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                this.isRecv = false;
                if (this.clientSocket != null &&
                    this.clientSocket.Connected)
                    this.clientSocket.Close();
            }catch(Exception ex)
            {
                AddLogListBox("Exception : " + ex.Message);
            }
            finally // 성공/예외 관계없이 무조건 실행 처리
            {
                btnConnect.Enabled = true;
                btnDisconnect.Enabled = false;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lbLog.Items.Clear();
        }

        private void tbChat_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    string data = tbChat.Text;
                    this.sw.WriteLine(data);
                    this.sw.Flush();
                    AddLogListBox("← to Client : " + data);
                    tbChat.Clear();
                    break;
            }
        }

        void AddLogListBox(string data)
        {
            if (lbLog.InvokeRequired)
            {
                Invoke(addLogData, new object[] { data });
            }
            else
            {
                lbLog.Items.Add(data);
                lbLog.SelectedIndex = lbLog.Items.Count - 1;
            }
        }

        void ThreadRecv()
        {
            StreamReader sr = new StreamReader(this.ns);
            while (this.isRecv)
            {
                try
                {
                    string data = sr.ReadLine();
                    AddLogListBox("→ from Server : " + data);
                }catch(Exception ex)
                {
                    AddLogListBox("Exception: " + ex.Message);
                    break;
                }
            }
        }
    }
}
