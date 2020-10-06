using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;                                               // 네트워크 관련 클래스 사용
using System.Net.Sockets;                                       // Socket 클래스

namespace UDPClientConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] data = new byte[10];

            IPAddress ipAddress = IPAddress.Parse("127.0.0.1"); // 접속할 서버의 IP 주소
            IPEndPoint ipep = new IPEndPoint(ipAddress, 3317);  // 접속할 서버를 지정

            // 서버 소켓 생성
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            while (true)
            {
                Console.WriteLine("데이터 입력 >> ");
                string str = Console.ReadLine();
                data = Encoding.Default.GetBytes(str);
                //data = Encoding.Default.GetBytes("클라이언트에서 보내는 메시지입니다.");
                server.SendTo(data, ipep);                          // 서버에 대이터 전송

                Console.WriteLine("서버에 데이터를 전송하였습니다.");
                if (str == "bye")
                    break;
            }
            server.Close();                                     // 서버 소켓 닫기
        }
    }
}
