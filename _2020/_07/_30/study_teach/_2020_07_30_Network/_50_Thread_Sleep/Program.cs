using System;
using System.Threading;

namespace _50_Thread_Sleep
{
    class Program
    {
        static int sumOdd = 0;  // 홀수합
        static int sumEven = 0; // 짝수합

        static void ThreadProc()
        {
            for(int i = 1; i <= 100; i += 2)
            {
                sumOdd += i;
                Console.WriteLine("직원 스레드 : " + i);
                Thread.Sleep(100);
            }
        }

        static void Main(string[] args)
        {
            Thread t = new Thread(new ThreadStart(ThreadProc));
            t.Start();

            for(int i = 0; i <= 100; i += 2)
            {
                sumEven += i;
                Console.WriteLine("CEO 스레드 : " + i);
                Thread.Sleep(50);
            }

            /*직원스레드의 작업시간을 대략 예측가능할 때는
             사용하기 좋은 동기화(Sync) 방법이다*/
            Thread.Sleep(3000); // 스레드 3초간 정지

            Console.WriteLine("1~100까지 홀수의 합: " + sumOdd);
            Console.WriteLine("1~100까지 짝수의 합: " + sumEven);
            Console.WriteLine("CEO 스레드 종료");
        }
    }
}
