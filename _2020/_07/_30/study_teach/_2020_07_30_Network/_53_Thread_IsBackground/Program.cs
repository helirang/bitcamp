using System;
using System.Threading;

namespace _53_Thread_IsBackground
{
    class Program
    {
        static int sumOdd = 0;  // 홀수합
        static int sumEven = 0; // 짝수합

        static void ThreadProc()
        {
            Random rand = new Random();

            for (int i = 1; i <= 100; i += 2)
            {
                sumOdd += i;
                Console.WriteLine("직원 스레드 : " + i);
                Thread.Sleep(rand.Next(50) + 50);
            }
        }

        static void Main(string[] args)
        {
            Thread t = new Thread(new ThreadStart(ThreadProc));
            t.IsBackground = true;  // CEO가 끝나면 함께 끝내라
            t.Start();

            for (int i = 0; i <= 100; i += 2)
            {
                sumEven += i;
                Console.WriteLine("CEO 스레드 : " + i);
                Thread.Sleep(50);
            }


            Console.WriteLine("1~100까지 짝수의 합: " + sumEven);
            Console.WriteLine("CEO 스레드 종료");
        }
    }
}
