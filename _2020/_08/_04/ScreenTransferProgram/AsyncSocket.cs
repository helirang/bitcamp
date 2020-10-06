using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;                                               // 네트워크 관련 클래스 사용
using System.Net.Sockets;                                       // Socket 클래스 사용
using System.Threading;
using ScreenTransferProgram;
using System.Drawing;                                         // Thread 사용

namespace ChatProgram
{
    class AsyncSocket
    {
        private const int PACKET_HEADER_SIZE = 4;               // 패킷 해더 크기

        public const int DEFAULT_PORT_NUM = 3317;               // 기본 포트 번호

        private DisplayScreen mDisplayScreenWnd = null;         // display screen form

        private String mMyIPAddress = "";                       // 자신의 IP Address
        private String mServerIPAddress = "";                   // 서버 IP Address

        private int mServerPortNum = 0;                         // 서버 port num

        private Socket mServerSocket = null;                    // 접속 대기용 소켓
        private Socket mClientSocket = null;                    // 클라이언트용 소켓

        private Thread mReceiverThread = null;                  // 서버 데이터 수신 스레드

        private ScreenCapture mScreenCapture = null;            // Screen capture 관련 기능 수행 클래스

        /// <summary>
        /// 기본 생성자
        /// </summary>
        public AsyncSocket()
        {

        }

        /// <summary>
        /// chat창 객체를 파라미터로 받는 생성자
        /// </summary>
        /// <param name="chat">chat창 객체 변수</param>
        public AsyncSocket(DisplayScreen displayScreen)
        {
            mDisplayScreenWnd = displayScreen;                  // main chat form의 객체를 연결
            Init();                                             // 초기화 작업
        }

        /// <summary>
        /// 소켓이 생성될때 필요한 초기화 작업을 수행
        /// </summary>
        private void Init()
        {
            SetMyIPAddress();                                   // 내 IP address 설정

            mScreenCapture = new ScreenCapture();               // Screen capture 관련 기능 수행 객체 생성
        }

        /// <summary>
        /// Client socket 초기화
        /// </summary>
        /// <param name="serverIPAddress">접속할 서버 IP 주소</param>
        /// <param name="serverPortNum">접속할 서버 port 번호</param>
        public void InitClientSocket(String serverIPAddress, int serverPortNum)
        {
            mServerIPAddress = serverIPAddress;
            mServerPortNum = serverPortNum;

            // 접속할 서버의 IPEndPoint 객체 생성
            IPEndPoint serverIpep = new IPEndPoint(IPAddress.Parse(mServerIPAddress), mServerPortNum);
            // 데이터 통신에 사용할 클라이언트용 소켓 생성
            mClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        }

        /// <summary>
        /// Client socket 종료
        /// </summary>
        public void CloseClientSocket()
        {
            // 클라이언트용 소켓을 닫음. 소켓을 닫기 전에 발생할 수 있는 error 처리
            if (mClientSocket == null)              // 소켓 객체가 null일 경우. error 처리
            {
                mDisplayScreenWnd.NotifyMessage("에러!\r\n 클라이언트 소켓 객체가 null입니다.");
                return;
            }
            mClientSocket.Close();                  // 클라이언트용 소켓을 닫음. 소켓 자원을 반환

            mDisplayScreenWnd.NotifyMessage("UDP 클라이언트 소켓을 닫았습니다.");
            mDisplayScreenWnd.NotifyMessage("UDP 클라이언트 종료 완료");
        }

        /// <summary>
        /// 서버를 시작
        /// </summary>
        /// <param name="portNum">서버 Port 번호</param>
        public void StartServer(int portNum)
        {
            mServerIPAddress = mMyIPAddress;
            mServerPortNum = portNum;

            // 서버의 IPEndPoint 객체를 생성
            IPEndPoint serverIpep = new IPEndPoint(IPAddress.Any, mServerPortNum);

            // 서버에서 접속 대기용으로 사용할 서버용 소켓을 생성
            mServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            mServerSocket.Bind(serverIpep);                     // 생성한 서버 소켓에 IP주소와 Port 번호를 지정

            mReceiverThread = new Thread(new ThreadStart(Receive));         // 데이터 수신 함수를 스레드에 연결
            mReceiverThread.Start();                                        // 데이터 수신 스레드 시작

            mDisplayScreenWnd.NotifyMessage("UDP 서버 시작를 시작합니다.");
        }

        /// <summary>
        /// 서버 중지
        /// </summary>
        public void StopServer()
        {
            // 서버용 소켓을 닫음. 소켓을 닫기 전에 발생할 수 있는 error 처리
            if (mServerSocket == null)
            {
                mDisplayScreenWnd.NotifyMessage("에러!\r\n 서버용 소켓 객체가 null입니다.");
            }
            mServerSocket.Close();                      // 서버용 소켓을 닫음
            mDisplayScreenWnd.NotifyMessage("UDP 서버 소켓을 닫았습니다.");

            // 데이터 수신 스레드를 종료함. 종료하기 전에 발생할 수 있는 error 처리
            if (mReceiverThread == null)                        // 수신 스레드 객체가 null일 경우. error 처리
            {
                mDisplayScreenWnd.NotifyMessage("에러!\r\n 수신 스레드 객체가 null입니다.");
                return;
            }
            if (mReceiverThread.IsAlive == false)               // 수신 스레드가 동작하지 않을 경우. error 처리
            {
                mDisplayScreenWnd.NotifyMessage("에러!\r\n 수신 스레드 객체가 동작하고 있지 않습니다.");
                return;
            }
            mReceiverThread.Abort();                            // 데이터 수신 스레드를 종료
            mDisplayScreenWnd.NotifyMessage("UDP 서버 수신 스레드를 종료하였습니다.");
            mDisplayScreenWnd.NotifyMessage("UDP 서버 종료 완료");
        }

        /// <summary>
        /// 상대방 호스트로부터 데이터 수신
        /// </summary>
        private void Receive()
        {
            byte[] data = null;                             // 수신한 raw data
            Bitmap image = null;                            // 수신한 image

            while (true)
            {
                if (mServerSocket == null)                  // socket 객체가 null일 경우 error 처리
                {
                    mDisplayScreenWnd.NotifyMessage("에러!\r\n 소켓 객체가 null입니다.");
                    break;
                }

                data = ReceiveData();                       // 데이터 수신

                image = mScreenCapture.GetScreenImage(data, data.Length);

                mDisplayScreenWnd.RefreshScreenImage(image);// display screen 창에 새로운 image 전달

                mDisplayScreenWnd.NotifyMessage("새로운 화면 수신");
            }
        }

        /// <summary>
        /// 소켓의 버퍼에 있는 데이터 수신
        /// </summary>
        /// <returns>수신 완료된 데이터</returns>
        private byte[] ReceiveData()
        {
            byte[] headerBuffer = new byte[PACKET_HEADER_SIZE];     // 패킷 해더 수신 버퍼
            byte[] dataBuffer = null;                               // 데이터 수신 버퍼 생성

            int totalDataSize = 0;                              // 전체 데이터 크기
            int accumulatedDataSize = 0;                        // 지금까지 수신한 데이터 크기
            int leftDataSize = 0;                               // 미수신한 데이터 크기
            int receivedDataSize = 0;                           // 수신한 데이터 크기

            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 0);
            EndPoint remote = (EndPoint)(ipep);

            // 데이터 수신. receivedDataSize에는 Receive 함수를 한 번 호출함으로써 수신한 데이터 크기가 저장
            receivedDataSize = mServerSocket.ReceiveFrom(headerBuffer, 0, PACKET_HEADER_SIZE, SocketFlags.None, ref remote);

            // 수신하여야 할 총 데이터 크기를 구함
            totalDataSize = BitConverter.ToInt32(headerBuffer, 0);

            leftDataSize = totalDataSize;                       // 남은 수신하여야 하는 데이터 크기를 leftDataSize에 저장
            dataBuffer = new byte[totalDataSize];               // 수신할 총 데이터 크기만큼 데이터 배열 생성

            while (leftDataSize > 0)                            // 수신하여야 할 남은 데이터가 없을 때 까지 반복
            {
                // 데이터 수신
                receivedDataSize = mServerSocket.ReceiveFrom(dataBuffer, accumulatedDataSize, leftDataSize, SocketFlags.None, ref remote);
                // 총 누적 수신된 데이터를 구함
                accumulatedDataSize = accumulatedDataSize + receivedDataSize;
                // 수신하여야 할 남은 데이터를 구함
                leftDataSize = leftDataSize - receivedDataSize;
            }

            return dataBuffer;                          // 수신된 데이터가 들어 있는 dataBuffer 변수를 반환
        }

        /// <summary>
        /// 화면을 캡쳐한 이미지 전송
        /// </summary>
        public void Send()
        {
            byte[] data = null;                         // 전송할 raw data

            if (mClientSocket == null)                  // socket 객체가 null일 경우 error 처리
            {
                mDisplayScreenWnd.NotifyMessage("에러!\r\n 소켓 객체가 null입니다.\r\n 메시지를 전송할 수 없습니다.");
                return;
            }

            data = mScreenCapture.GetScreenImageByteArray();

            SendData(data);                             // 데이터 전송

            mDisplayScreenWnd.NotifyMessage("서버로 화면 전송 완료");
        }

        /// <summary>
        /// byte 배열 형태의 데이터 값을 네트워크를 통해 전송
        /// </summary>
        /// <param name="dataBuffer">전송하고자 하는 값이 들어 있는 byte 배열</param>
        private void SendData(byte[] dataBuffer)
        {
            byte[] headerBuffer = new byte[PACKET_HEADER_SIZE];     // 패킷 해더 송신 버퍼

            int totalDataSize = 0;                              // 전체 데이터 크기
            int accumulatedDataSize = 0;                        // 지금까지 전송한 데이터 크기
            int leftDataSize = 0;                               // 미전송한 데이터 크기
            int sentDataSize = 0;                               // 전송한 데이터 크기

            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(mServerIPAddress), mServerPortNum);

            totalDataSize = dataBuffer.Length;                  // 전체 데이터 크기를 구함
            leftDataSize = totalDataSize - sentDataSize;        // 남은 데이터 크기를 구함

            // 전송할 데이터의 총 크기를 구함
            headerBuffer = BitConverter.GetBytes(totalDataSize);
            mClientSocket.SendTo(headerBuffer, PACKET_HEADER_SIZE, SocketFlags.None, ipep); // 전체 데이터 크기를 전송

            while (leftDataSize > 0)                            // 데이터를 모두 전송할 때 까지 반복
            {
                // 데이터를 전송. sentDataSize에는 Send 함수를 한 번 호출 함으로써 전송된 데이터의 크기가 저장
                sentDataSize = mClientSocket.SendTo(dataBuffer, accumulatedDataSize, leftDataSize, SocketFlags.None, ipep);
                // 지금까지 누적된 전송된 데이터의 총 크기를 구함
                accumulatedDataSize = accumulatedDataSize + sentDataSize;
                // 전송되어야 할 남은 데이터의 크기를 구함
                leftDataSize = leftDataSize - sentDataSize;
            }
        }

        /// <summary>
        /// 자신의 IP 주소를 구하여 멤버 변수 mMyIPAddress에 저장
        /// </summary>
        private void SetMyIPAddress()
        {
            String myIPAddress = "";
            IPHostEntry host; 
            host = Dns.GetHostEntry(Dns.GetHostName()); 
            foreach (IPAddress ip in host.AddressList) 
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork) 
                {
                    myIPAddress = ip.ToString();
                    break;
                } 
            } 
            mMyIPAddress = myIPAddress;
        }


        /// <summary>
        /// 자신의 IP 주소를 반환
        /// </summary>
        /// <returns>자신의 IP 주소</returns>
        public String GetMyIPAddress()
        {
            return mMyIPAddress;
        }
    }
}
