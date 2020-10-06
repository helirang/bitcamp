using System;
using System.Threading;

namespace _49_NoParamThread
{
    class Program
    {
        // 직원 스레드가 동작할 메서드(일)를 선언
        static void ThreadProc()
        {
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine("직원 스레드 : " + i);
                Thread.Sleep(500);
            }
            Console.WriteLine("직원 스레드 종료");
        }

        // 앱이 실행되면 Main메서드를 Main(CEO) 스레드가 진행
        static void Main(string[] args)
        {
            // 직원스레드 담당 객체 생성
            Thread t = new Thread(new ThreadStart(ThreadProc));
            t.Start();  // 직원스레드 동작 시작

            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine("CEO 스레드 : " + i);
                Thread.Sleep(300);
            }
            Console.WriteLine("CEO 스레드 종료");
        }
    }
}
