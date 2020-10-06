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

namespace _63_NetworkStreamMultiThreadServerForm
{
    public partial class Form1 : Form
    {
        Socket acceptSocket;    // 안내 역할 소켓(연결 처리 소켓)
        IPEndPoint ipep;        // 서버의 주소(ip, port)

        Thread tAccept;         // 연결담당 스레드
        bool isAccept = true;   // 연결담당 스레드 반복 플래그

        bool isRecv = true;     // 수신담당 스레드 반복 플래그

        /*Main 스레드가 아닌 Sub 스레드에서 윈폼의 컨트롤을 
         직접 접근하면 GUI 스레드가 사용중일 때는 예외가 발생하게 된다
         그러므로 사용중 일 때는 일단 메서드 호출을 .NET 프레임워크에
         통보를 전달을 해놓으면 .NET이 컨트롤 접근이 안전할 때
         자동으로 호출해준다.
         <요약> 별도 스레드에서 윈폼의 컨트롤을 직접 접근하면
               예외가 발생한다.
         */
        delegate void AddMsgData(string data);
        AddMsgData addMsgData = null;

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
                this.isAccept = false;
                this.isRecv = false;
                this.acceptSocket.Close();
            }
            catch(Exception ex)
            {
                AddLogListBox("Exception : " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            addMsgData = AddLogListBox;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.isAccept = true;
            this.isRecv = true;
            /*IPv4, TCP*/
            this.acceptSocket =
                new Socket(AddressFamily.InterNetwork,
                            SocketType.Stream,
                            ProtocolType.Tcp);
            /*프로세스가 위치한 Host IP, UI에 있는 port*/
            this.ipep = new IPEndPoint(IPAddress.Any,
                                Int32.Parse(tbPort.Text));
            this.acceptSocket.Bind(this.ipep);
            this.acceptSocket.Listen(1000);
            AddLogListBox("서버 대기중...");

            this.tAccept = new Thread(new ThreadStart(ThreadAccept));
            this.tAccept.Start();

            btnStart.Enabled = false;
            btnStop.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                this.isAccept = false;
                this.isRecv = false;
                this.acceptSocket.Close();
            }catch(Exception ex)
            {
                AddLogListBox("Exception : " + ex.Message);
            }
            finally
            {
                btnStart.Enabled = true;
                btnStop.Enabled = false;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lbLog.Items.Clear();
        }

        /*Main스레드에서는 AddLogListBox메서드 호출이 문제 없는데
         Sub스레드에서는 아래처럼 Invoke처리를 해줘야 한다*/
        void AddLogListBox(string data)
        {
            // 직접 컨트롤을 접근할 수 없는 상황일 때
            if (lbLog.InvokeRequired)
            {
                // .NET에 등록처리를 한다
                // (나중에 자동으로 addMsgData가 호출)
                Invoke(addMsgData, new object[] { data });
            }
            else
            {
                lbLog.Items.Add(data);
                lbLog.SelectedIndex = lbLog.Items.Count - 1;
            }
        }

        void ThreadAccept()
        {
            while (this.isAccept)
            {
                /* Accept()할 때마다 해당 소켓을 담당할 수신 스레드를 생성 구동한다.
                 */
                try
                {
                    Socket partnerSocket = this.acceptSocket.Accept();
                    AddLogListBox("클라이언트 접속");
                    NetworkStream ns = new NetworkStream(partnerSocket);

                    Thread tRecv = new Thread(new ParameterizedThreadStart(ThreadRecv));
                    tRecv.Start(ns);
                }catch(Exception ex)
                {
                    AddLogListBox("Exception : " + ex.Message);
                }
            }
        }
        void ThreadRecv(object obj)
        {
            NetworkStream ns = obj as NetworkStream;
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            while (this.isRecv)
            {
                try
                {
                    string data = sr.ReadLine();
                    AddLogListBox("← Client 수신 : " + data);
                    sw.WriteLine(data);
                    sw.Flush();
                    AddLogListBox("→ Client Echo : " + data);
                }
                catch(Exception ex)
                {
                    AddLogListBox("Exception : " + ex.Message);
                    break;
                }
            }
        }
    }
}
