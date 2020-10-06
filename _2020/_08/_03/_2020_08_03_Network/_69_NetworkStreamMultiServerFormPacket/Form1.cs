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

namespace _19_NetworkStreamMultiServerFormPacket
{
    public partial class Form1 : Form
    {
        Socket acceptSocket;    // 안내 역할 소켓(Accept 처리)
        IPEndPoint ipep;        // 서버의 주소(ip, port)        

        Thread tAccept;         // 연결 역할 스레드
        bool isAccept = true;   // Accept 스레드를 계속반복/중지 역할 플래그

        // 접속하는 소켓들과 연결된 객체를 저장하는 리스트
        List<SocketData> clientList = new List<SocketData>();

        /*Main 스레드가 아닌 별도의 스레드에서 폼의 컨트롤을 직접 접근했을때
         GUI스레드가 사용중일 때는 Error가 발생하게 된다.
         그러므로 사용중일 때는 일단 함수 호출을 닷넷 프레임워크에 통보를
         하고 전달을 하면 사용이 끝난 후 자동으로 호출해준다.
         이 처리를 안하면 가끔 잘되고 종종 예외가 발생한다*/
        delegate void AddMsgData(string data);  // ListBox 용도
        AddMsgData addMsgData = null;

        delegate void AddClientAddress(string ip, string port); // ListView 용도
        AddClientAddress addClientAddress = null;

        delegate void DelClientAddressFromListView(SocketData client); // ListView 용도
        DelClientAddressFromListView delClientAddressFromListView = null;

        bool IsAnonymous = true;    // 클라이언트한테 다른 클라이언트의 ip를 보낼까 말까

        public Form1()
        {
            InitializeComponent();

            this.Load += this.Form1_Load;
            this.FormClosed += Form1_FormClosed;
        }

        public void ShowForm()
        {
            Form1 frm = new Form1();
            frm.ShowDialog();
        }

        /// <summary>
        /// WinForm이 종료되었을 때 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                isAccept = false;
                CloseAll();
                acceptSocket.Close();
            }
            catch (Exception ex)
            {
                AddRecvListBox("Exception: " + ex.Message);
            }
        }

        /// <summary>
        /// 클라이언트가 접속할 때 연결을 담당하는 스레드가 맡은 함수
        /// </summary>
        void ThreadAccept()
        {
            while (isAccept)
            {
                try
                {
                    /*VIPS에서 입구의 안내직원이 담당직원을 연결시켜준다*/
                    Socket clientSocket = acceptSocket.Accept();    // 클라이언트가 접속할 때까지 대기상태
                    AddRecvListBox("클라이언트 접속");
                    SocketData sd = new SocketData(clientSocket);
                    AddClientAddressListView(sd.ip, sd.port);

                    /*clientList가 다른 스레드에서도 사용되기 때문에 오류방지를 위해서
                     lock처리를 해준다
                     1) ThreadAccept 스레드 : 새 접속자를 등록
                     2) ThreadReceive 스레드 : 기 접속자 등록 해지
                     3) Main 스레드 : 모든 접속자 해지 */
                    lock (this)
                    {                        
                        clientList.Add(sd);
                    }

                    // 수신 역할 스레드 가동
                    // 클라이언트가 보내오는 데이터를 기다리고 있다가 수신해라 
                    Thread tRecv = new Thread(new ParameterizedThreadStart(ThreadRecv));
                    tRecv.Start(sd);
                }
                catch (Exception ex)
                {
                    AddRecvListBox("Exception: " + ex.Message);
                    btnServerStart.Enabled = true;
                    btnServerStop.Enabled = false;
                }
            }
        }

        /// <summary>
        /// 모든 접속 소켓의 연결을 종료한다
        /// </summary>
        void CloseAll()
        {
            lock (this)
            {
                foreach (SocketData client in clientList)
                {
                    client.clientSocket.Close();
                }
            }
        }

        /// <summary>
        /// 데이터를 서버에 보낸 클라이언트를 제외한 나머지 클라이언트한테
        /// 데이터를 모두 전송하는 함수
        /// </summary>
        /// <param name="data">서버에 도착한 데이터</param>
        /// <param name="selfClient">데이터를 서버에 보낸 클라이언트
        ///       null일 경우는 클라이언트에서 수신한 데이터 없이
        ///       서버에서 모든 클라이언트한테 전송하는 경우
        /// </param>
        void SendAllData(string data, SocketData selfClient = null)
        {
            lock (this)
            {
                foreach (SocketData client in clientList)
                {
                    if (client != selfClient)
                    {
                        if(IsAnonymous)
                            client.sw.WriteLine(data);
                        else
                        {
                            string ipData = String.Format("[{0}] {1}", selfClient.ip, data);
                            client.sw.WriteLine(ipData);
                        }
                        client.sw.Flush();  // 즉시 전송해라
                    }
                }
            }
        }

        /// <summary>
        /// 접속정보를 보여주는 ListView의 모든 항목을 삭제한다
        /// </summary>
        void DeleteAllClientAddressFromListView()
        {
            clientListView.Items.Clear();
        }

        /// <summary>
        /// 접속자를 관리하는 ListView에서 해당 클라이언트를 삭제
        /// </summary>
        /// <param name="client">삭제할 대상 클라이언트 정보</param>
        void DeleteClientAddressFromListView(SocketData client)
        {
            if (clientListView.InvokeRequired)
            {
                // 사용중일 때는 .NET에 등록하게 처리를 맡긴다
                Invoke(delClientAddressFromListView, new object[] { client });
            }
            else
            {
                foreach (ListViewItem lvi in clientListView.Items)
                {
                    string ip = lvi.SubItems[0].Text;
                    string port = lvi.SubItems[1].Text;

                    if (ip == client.ip && port == client.port)
                    {
                        clientListView.Items.Remove(lvi);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 리스트 구조에 관리하던 모든 소켓관련 객체 정보를 삭제한다
        /// </summary>
        void DeleteAllClientFromList()
        {
            clientList.Clear();
        }

        /// <summary>
        /// 클라이언트를 관리하는 리스트 자료구조에서 클라이언트를 삭제
        /// </summary>
        /// <param name="client"></param>
        void DeleteClientFromList(SocketData client)
        {
            if (client.clientSocket.Connected)
                client.clientSocket.Close();
            clientList.Remove(client);
        }

        /// <summary>
        /// 연결된 소켓을 종료하고 
        /// 리스트 자료구조에서 접속객체정보를 삭제한다
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        void DeleteClientFromList(string ip, string port)
        {
            foreach(SocketData sd in clientList)
            {
                if(ip == sd.ip && port == sd.port)
                {
                    if (sd.clientSocket.Connected)
                        sd.clientSocket.Close();
                    clientList.Remove(sd);
                    break;
                }
            }            
        }

        /* 구분자 패킷 설계
         * 1) 크게 명령, 구분자, 데이터 3부분으로 나눈다
         * 2) 명령에 따라 데이터를 어떻게 해석할지 정한다
         * 3) 명령이 먼저 나온다
         * 4) 예시
         *    4-1) 명령의 종류 C : 채팅
         *                    S : 정해진 초 이후에 나를 해제
         *                    B : WinForm의 배경색
         *    4-2) 구분자 : |
         *    4-3) C|안녕하세요  
         *         S|3
         *         B|Gold
         */

        /// <summary>
        /// 정해진 약속에 따라 패킷을 처리하는 함수
        /// </summary>
        /// <param name="srcData">클라이언트가 보내온 전체 데이터</param>
        /// <param name="sendClient">데이터를 보낸 클라이언트</param>
        void ProcessPacket(string srcData, SocketData sendClient)
        {
            string[] datas = srcData.Split(new char[] { '|' });
            switch(datas[0])
            {
                case "C":
                    AddRecvListBox(String.Format("[채팅] [{0}] {1}", sendClient.ip, srcData));
                    SendAllData(datas[1], sendClient);
                    break;
                case "S":
                    {
                        AddRecvListBox(String.Format("[해제] [{0}] {1}", sendClient.ip, srcData));
                        int sec = Int32.Parse(datas[1]);
                        // 정해진 초 후에 처리할 스레드에 전달할 인자
                        SocketCloseData scd = new SocketCloseData();
                        scd.client = sendClient;
                        scd.sec = sec;
                        Thread tClose =
                            new Thread(new ParameterizedThreadStart(ThreadClose));
                        tClose.Start(scd);
                    }
                    break;
                case "B":
                    AddRecvListBox(String.Format("[배경] [{0}] {1}", sendClient.ip, srcData));
                    Color color = Color.FromName(datas[1]);
                    this.BackColor = color;
                    break;
            }
        }

        public class SocketCloseData
        {
            public SocketData client;
            public int sec;
        }

        void ThreadClose(object s)
        {
            SocketCloseData scd = (SocketCloseData)s;
            Thread.Sleep(scd.sec * 1000);
            DeleteClientAddressFromListView(scd.client);
            DeleteClientFromList(scd.client);
        }

        /// <summary>
        /// 클라이언트가 보내온 데이터를 기다리고 
        /// 정해진 약속에 따라 해석하고 처리하는 함수
        /// </summary>
        /// <param name="sockData">담당 소켓관련 객체</param>
        void ThreadRecv(object sockData)
        {
            SocketData clientData = sockData as SocketData;

            while (true)
            {
                try
                {
                    string data = clientData.sr.ReadLine(); // 클라이언트가 보내올 때까지 무한대기 
                    ProcessPacket(data, clientData);
                    //SendAllData(data, clientData);  // 자신을 제외한 나머지 클라이언트에 모두 전송
                    //AddRecvListBox(String.Format("[{0}] {1}", clientData.ip, data));
                }
                catch (Exception ex)    // 거의 99%이상은 접속이 끊어졌을 때 발생한다
                {
                    AddRecvListBox("Exception: " + ex.Message);
                    DeleteClientFromList(clientData);
                    DeleteClientAddressFromListView(clientData);
                    break;
                }
            }
        }

        /// <summary>
        /// 접속정보 관리하는 ListView에 접속정보를 등록
        /// </summary>
        /// <param name="ip">ip 주소</param>
        /// <param name="port">port 주소</param>
        void AddClientAddressListView(string ip, string port)
        {
            if (clientListView.InvokeRequired)
            {
                // 사용중일 때는 .NET에 등록하게 처리를 맡긴다
                Invoke(addClientAddress, new object[] { ip, port });
            }
            else
            {
                string[] address = { ip, port };
                clientListView.Items.Add(new ListViewItem(address));
            }
        }


        /// <summary>
        /// 송수신데이터를 ListBox에 보여주는 함수
        /// </summary>
        /// <param name="data">송수신 데이터</param>
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
                lbRecvData.SelectedIndex = lbRecvData.Items.Count - 1;  // 마지막 라인에 선택이 위치할 수 있도록
            }
        }

        /// <summary>
        /// 서버 시작 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnServerStart_Click(object sender, EventArgs e)
        {
            isAccept = true;
            acceptSocket =
                new Socket(AddressFamily.InterNetwork,
                            SocketType.Stream, ProtocolType.Tcp);
            ipep = new IPEndPoint(IPAddress.Any,
                    Int32.Parse(tbPort.Text));

            acceptSocket.Bind(ipep);    // 휴대폰에 전화번호 부여
            acceptSocket.Listen(10);
            AddRecvListBox("서버 대기중...");

            tAccept = new Thread(new ThreadStart(ThreadAccept));
            tAccept.Start();

            btnServerStart.Enabled = false;
            btnServerStop.Enabled = true;
        }

        /// <summary>
        /// "Server Stop" 버튼이 눌렸을 때
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnServerStop_Click(object sender, EventArgs e)
        {
            try
            {
                isAccept = false;   // ThreadAccept의 무한루프를 중지
                CloseAll();
                DeleteAllClientFromList();
                DeleteAllClientAddressFromListView();
                acceptSocket.Close();   // 접속도 안받아주기 위해
            }
            catch (Exception ex)
            {
                AddRecvListBox("Exception: " + ex.Message);
            }
            finally
            {
                btnServerStart.Enabled = true;
                btnServerStop.Enabled = false;
            }
        }

        /// <summary>
        /// 서버에서 직접 모든 클라이언트한테 보내는 메세지창에서 
        /// Enter를 눌렀을 경우 발생하는 이벤트 핸들러 함수
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbSendData_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    string data = tbSendData.Text;
                    SendAllData(data);
                    AddRecvListBox("<서버> : " + data);
                    tbSendData.Clear();
                    break;
            }
        }

        /// <summary>
        /// 이 프로그램의 초기화 역할
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            /* Main 스레드 외의 스레드에서 WinForm의 컨트롤을
             * 접근할 때 Exception방지를 위해 delegate로
             * 메서드를 지칭할 수 있게 만들었다.
             */
            addMsgData = AddRecvListBox;
            addClientAddress = AddClientAddressListView;
            delClientAddressFromListView = DeleteClientAddressFromListView;
        }

        /// <summary>
        /// 송수신 데이터가 표시된 ListBox의 로그를 모두 지워라
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEraseListBox_Click(object sender, EventArgs e)
        {
            lbRecvData.Items.Clear();
        }

        /// <summary>
        /// 현재 접속중인 클라이언트를 강제로 퇴장시킨다(연결 해제)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnForcedExit_Click(object sender, EventArgs e)
        {
            // ListView에서 선택된 항목이 1개이상일 경우 foreach문 사용
            foreach (ListViewItem lvi in clientListView.SelectedItems)
            {
                string ip = lvi.SubItems[0].Text;
                string port = lvi.SubItems[1].Text;
                DeleteClientFromList(ip, port);                
                clientListView.Items.Remove(lvi);// 연결 정보가 보이는 ListView에서 삭제해라
            }
        }

        /// <summary>
        /// 익명 전송을 체크/해제 할때마다 true/false 설정
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckbAnonymous_CheckedChanged(object sender, EventArgs e)
        {
            IsAnonymous = !IsAnonymous;
        }
    }

    /// <summary>
    /// 소켓을 매개체로 해서 송수신하는 객체를 생성하고
    /// ip, port 정보를 보관하는 소켓관련 클래스
    /// </summary>
    public class SocketData
    {
        public Socket clientSocket;
        public NetworkStream ns;
        public StreamWriter sw;
        public StreamReader sr;
        public string ip;
        public string port;

        public SocketData(Socket sock)
        {
            this.clientSocket = sock;
            ns = new NetworkStream(sock);
            sw = new StreamWriter(ns);
            sr = new StreamReader(ns);

            string address = sock.RemoteEndPoint.ToString();
            string[] array = address.Split(new char[] { ':' });

            this.ip = array[0];
            this.port = array[1];
        }
    }
}
