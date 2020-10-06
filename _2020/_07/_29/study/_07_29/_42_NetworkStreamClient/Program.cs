using System;
using System.Net.Sockets;

namespace _42_NetworkStreamClient
{
    class Program
    {
        static void Main(string[] args)
        {
            /* IPv4 : 4byte IP 주소
             * TCP : 신뢰성있는 전송
             * Socket은 Applica
             */
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
    }
}
