using System;
using System.Threading;
namespace _55_Thread_Stop
{
    class Program
    {
        static Random rand = new Random();
        static bool isRun = true;

        static void ThreadProc()
        {
            while (isRun)
            {
                switch (rand.Next(3))
                {
                    case 0:
                        Console.WriteLine("일을 한다");
                        break;
                    case 1:
                        Console.WriteLine("몰래 사라진다");
                        break;
                    case 2:
                        Console.WriteLine("가게 돈으로 여친한테 선물한다");
                        break;
                }
                Thread.Sleep(100);
            }
        }

        static void Main(string[] args)
        {
            Thread t = new Thread(new ThreadStart(ThreadProc));
            t.Start();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("주인이 알바생을 지켜보고 있다");
                Thread.Sleep(100);
            }
            Console.WriteLine("참을 수 없다\n그만 둬!");
            isRun = false;
        }
    }
}
