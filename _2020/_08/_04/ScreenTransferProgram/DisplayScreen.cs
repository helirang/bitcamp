using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ChatProgram;

namespace ScreenTransferProgram
{
    public partial class DisplayScreen : Form
    {
        private const int SERVER = 1;                               // 사용할 네트워크의 종류. 서버
        private const int CLIENT = 2;                               // 사용할 네트워크의 종류. 클라이언트

        delegate void UpdateTextCallback(String message);           // 텍스트 메시지 갱신 delegate
        delegate void UpdateScreenImageCallback(Bitmap image);      // 이미지 갱신 delegate

        private AsyncSocket mAsyncSocket = null;                             // 동기 소켓으로 작동하는 사용자 정의 소켓 클래스

        private int mNetworkType = 0;                                       // 네트워크 종류를 나타냄

        /// <summary>
        /// 생성자
        /// </summary>
        public DisplayScreen()
        {
            InitializeComponent();

            mAsyncSocket = new AsyncSocket(this);                         // 사용자 정의 소켓 클래스 생성
            mTxtServerIPAddress.Text = mAsyncSocket.GetMyIPAddress();
            mTxtServerPortNum.Text = AsyncSocket.DEFAULT_PORT_NUM.ToString();
            mTxtClientIPAddress.Text = mAsyncSocket.GetMyIPAddress();
            mTxtClientPortNum.Text = AsyncSocket.DEFAULT_PORT_NUM.ToString();
        }

        /// <summary>
        /// 서버 시작 버튼 이벤트 핸들러
        /// </summary>
        private void mBtnStartServer_Click(object sender, EventArgs e)
        {
            int portNum = 0;                                        // 서버 port 번호
            portNum = Int32.Parse(mTxtServerPortNum.Text.Trim());   // 서버 port 번호를 입력
            mAsyncSocket.StartServer(portNum);                      // 서버 시작

            mNetworkType = SERVER;                                  // 네트워크 종류를 서버로 지정
        }

        /// <summary>
        /// 클라이어트 시작 버튼 이벤트 핸들러
        /// </summary>
        private void mBtnStartClient_Click(object sender, EventArgs e)
        {
            String serverIPAddress = "";                // 서버 IP 주소
            int portNum = 0;                            // 서버 port 번호

            serverIPAddress = mTxtServerIPAddress.Text.Trim();      // 접속할 서버 IP 주소 획득
            portNum = Int32.Parse(mTxtServerPortNum.Text.Trim());   // 접속할 서버 port 번호를 가져옴

            mAsyncSocket.InitClientSocket(serverIPAddress, portNum);// 클라이언트 기능 초기화
            mTimerSendScreenImage.Start();                          // 이미지 전송 스레드 시작

            mNetworkType = CLIENT;                                  // 네트워크 종류를 클라이언트로 지정
        }

        /// <summary>
        /// 수신한 화면 갱신
        /// </summary>
        /// <param name="image">수신한 화면 이미지</param>
        public void RefreshScreenImage(Bitmap image)
        {
            UpdateScreenImage(image);
        }

        /// <summary>
        /// PictureBox 컨트롤에 접근하기 위한 delegate 함수
        /// </summary>
        /// <param name="image">갱신할 화면 이미지</param>
        private void UpdateScreenImage(Bitmap image)
        {
            try
            {
                if (mPicScreenImage.InvokeRequired)
                {
                    UpdateScreenImageCallback d = new UpdateScreenImageCallback(UpdateScreenImage);
                    Invoke(d, new object[] { image });
                }
                else
                {
                    mPicScreenImage.Image = image as Image;         // PictureBox 컨트롤에 갱신할 화면 이미지 입력
                }
            }
            catch { }
        }

        /// <summary>
        /// AsyncSockets 클래스로부터 시스템적 전달 사항 수신
        /// </summary>
        /// <param name="message">SyncSockets 클래스로부터 수신한 공지 사항</param>
        public void NotifyMessage(String message)
        {
            message = message + "\r\n";

            AppendMessage(message);
        }

        /// <summary>
        /// 메시지 창에 텍스트 추가
        /// </summary>
        /// <param name="message"></param>
        private void AppendMessage(String message)
        {
            try
            {
                if (mTxtStatus.InvokeRequired)
                {
                    UpdateTextCallback d = new UpdateTextCallback(AppendMessage);
                    Invoke(d, new object[] { message });
                }
                else
                {
                    mTxtStatus.AppendText(message + "\r\n");        // TextBox 컨트롤에 추가할 텍스트 입력
                }
            }
            catch { }
        }

        /// <summary>
        /// 화면을 주기적으로 전송할 Timer
        /// </summary>
        private void mTimerSendScreenImage_Tick(object sender, EventArgs e)
        {
            mAsyncSocket.Send();
        }

        /// <summary>
        /// 종료 버튼 클릭 이벤트 핸들러
        /// </summary>
        private void mBtnExit_Click(object sender, EventArgs e)
        {
            if (mNetworkType == SERVER)
            {
                mAsyncSocket.StopServer();
            }
            else if (mNetworkType == CLIENT)
            {
                mTimerSendScreenImage.Stop();
                mAsyncSocket.CloseClientSocket();
            }
        }
    }
}
