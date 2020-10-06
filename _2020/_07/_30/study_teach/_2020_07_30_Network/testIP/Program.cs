using Microsoft.Extensions.Hosting;
using System;
using System.Net;
using System.Net.Sockets;

namespace testIP
{
    class Program
    {
        string localIP = "Not available, please check your network seetings!";

        IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());



            foreach (IPAddress ip in Host.AddressList)

            {

                if (ip.AddressFamily == AddressFamily.InterNetwork)

                {

                    localIP = ip.ToString();

                    Console.WriteLine(localIP);

                }

}