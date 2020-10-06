using System;
using System.Threading;

namespace _55
{
    class Program
    {
        static int i;
        static Random rand = new Random();
        static void ThreadProc()
        {
            i = rand.Next(30);
            for(int i = 0; i <100; i++)
            {
                Console.WriteLine($"밥은 12시 {i}");
                Thread.Sleep(200);
            }
            Console.WriteLine($"서브 종료");
        }
        static void Main(string[] args)
        {
            Thread t = new Thread(new ThreadStart(ThreadProc));
            t.IsBackground = true;
            t.Start();
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"저녁은 6시 {i}");
                Thread.Sleep(100);
            }
            Console.WriteLine($"메인 종료");
        }
    }
}
