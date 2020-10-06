using System;
using System.Threading;

namespace _61_ParamThread
{
    class Program
    {
        static void ThreadProc(object obj)
        {
            int count = (int)obj;
            for(int i = 0; i < count; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(500);
            }
            Console.WriteLine("직원 스레드 종료");
        }
        static void Main(string[] args)
        {
            Thread t = 
                new Thread(new ParameterizedThreadStart(ThreadProc));
            t.Start(10);
            Console.WriteLine("주 스레드 대기...");
            t.Join();
            Console.WriteLine("주 스레드 종료...");
        }
    }
}
