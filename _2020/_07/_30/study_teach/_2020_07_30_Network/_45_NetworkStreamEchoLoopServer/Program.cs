using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace _45_NetworkStreamEchoLoopServer
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Socket은 Application이 
             * Transport Layer 계층과 통신하기 위한 
             * 연결객체*/
            /* IPv4 : 4byte IP 주소
             * TCP  : 신뢰성있는 전송
             */
            Socket serverSocket =
                new Socket(AddressFamily.InterNetwork,
                            SocketType.Stream,
                            ProtocolType.Tcp);
            const int PORT = 9000;
            // 주소 객체
            /* Network의 주소 2가지
             * 1) 강원도 정선군 사북읍 하이원길 265 : IP
             *     Network Lan Card : Host(PC)
             * 2) 포커룸                          : PORT
             *     해당 서버 프로세스
             *     
             */
            /*IPAddress.Any : 현재 Host의 IP
             * PORT : 9000
             * PORT의 범위 : 0 ~ 65535(0 ~ 1023 예약)
             */
            IPEndPoint ipep =
                new IPEndPoint(IPAddress.Any, PORT);

            /* 소켓에 주소를 연결
             * (휴대폰에 개통을 해서 전화번호를 부여받는다)
             */
            serverSocket.Bind(ipep);
            serverSocket.Listen(10);    // 10명 동시 대기 큐 생성
            Console.WriteLine("클라이언트 접속 대기중...");

            /* 고객이 전화가 오기를 기다리고 있다.
             * Accept()는 호출하면 리턴하지 않고
             * 기다리고 있다.
             * 
             * 고객이 접속요청후 정상 연결이 되면
             * Client와 연결된 소켓을 반환한다.
             */
            Socket partnerSocket = serverSocket.Accept();
            Console.WriteLine("클라이언트 접속완료~");

            // 고객이 보내온 데이터를 수신한다
            NetworkStream ns = new NetworkStream(partnerSocket);
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            while (true)
            {
                string recvData = sr.ReadLine();
                Console.WriteLine("← Client : " + recvData);
                sw.WriteLine(recvData);
                sw.Flush();
                Console.WriteLine("Server → : " + recvData);
                if (recvData == "bye")
                    break;
            }

            partnerSocket.Close();
            serverSocket.Close();
        }
    }
}
