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

namespace _16_NetworkStreamClientForm
{
    public partial class Form1 : Form
    {
        Socket client;
        IPEndPoint ipep;

        NetworkStream ns;
        StreamWriter sw;

        Thread tRecv;
        bool isRecv = true;

        delegate void AddMsgData(string data);
        AddMsgData addMsgData = null;

        public Form1()
        {
            InitializeComponent();

            this.FormClosed += Form1_FormClosed;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                isRecv = false;
                if (client != null && client.Connected)
                    client.Close();
            }
            catch (Exception ex)
            {
                AddRecvListBox("Exception : " + ex.Message);
            }
        }

        void ThreadRecv()
        {
            StreamReader sr = new StreamReader(ns);
            while (isRecv)
            {
                try
                {
                    string data = sr.ReadLine();
                    AddRecvListBox("                    <수신> : " + data);
                }
                catch(Exception ex)
                {
                    AddRecvListBox("Exception : " + ex.Message);
                    btnClientConnect.Enabled = true;
                    btnClientStop.Enabled = false;
                    break;
                }
            }
        }

        private void BtnClientConnect_Click(object sender, EventArgs e)
        {
            isRecv = true;
            client = 
                new Socket(AddressFamily.InterNetwork,
                           SocketType.Stream,
                           ProtocolType.Tcp);
            ipep =
                new IPEndPoint(IPAddress.Parse(tbIp.Text),
                                Int32.Parse(tbPort.Text));
            AddRecvListBox("서버 접속 시도...");
            client.Connect(ipep);
            AddRecvListBox("서버 접속 완료");

            ns = new NetworkStream(client);
            sw = new StreamWriter(ns);

            tRecv = new Thread(new ThreadStart(ThreadRecv));
            tRecv.Start();

            btnClientConnect.Enabled = false;
            btnClientStop.Enabled = true;
        }

        private void BtnClientStop_Click(object sender, EventArgs e)
        {
            try
            {
                isRecv = false;
                if (client != null && client.Connected)
                    client.Close();
            }catch(Exception ex)
            {
                AddRecvListBox("Exception : " + ex.Message);
            }
            finally
            {
                btnClientConnect.Enabled = true;
                btnClientStop.Enabled = false;
            }
        }

        private void TbSendData_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    string data = tbSendData.Text;
                    sw.WriteLine(data);
                    sw.Flush();         // 즉시 보낸다.
                    AddRecvListBox("<송신> : " + data);
                    tbSendData.Clear();
                    break;
            }
        }

        void AddRecvListBox(string data)
        {
            if (lbRecvData.InvokeRequired)
            {
                // 사용중일 때는 .NET에 등록하게 처리를 맡긴다
                Invoke(addMsgData, new object[] { data });
            }
            else
            {
                lbRecvData.Items.Add(data);
                lbRecvData.SelectedIndex = lbRecvData.Items.Count - 1;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            addMsgData = AddRecvListBox;
        }

        private void BtnEraseListBox_Click(object sender, EventArgs e)
        {
            lbRecvData.Items.Clear();
        }
    }
}
