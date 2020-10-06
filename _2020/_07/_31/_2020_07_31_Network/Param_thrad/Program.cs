using System;
using System.Threading;

namespace Param_thrad
{
    class Program
    {
        static void ThreadProc(object obj)
        {
            int count = (int)obj;
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(500);
            }
            Console.WriteLine("직원 스레드 종료");
        }
        static void Main(string[] args)
        {
            Thread t = new Thread(new ParameterizedThreadStart(ThreadProc)); // 매개변수 전달
            t.Start(10); // 이렇게 매개변수 전달 가능
            Console.WriteLine("주 스레드 대기...");
            t.Join();
            Console.WriteLine("주 스레드 종료...");
        }
    }
}
