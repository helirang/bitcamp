using System;
using System.Threading;

namespace _58_ThreadLock
{
    class Program
    {
        // lock을 걸기 위한 자물쇠
        static object obj = new object();

        static int cnt = 0;

        static void ThreadAdd()
        {
            lock (obj)  // 자물쇠로 잠근다
            {
                for (int i = 0; i < 100000; i++)
                {
                    cnt++;
                }           // 자물쇠를 연다
            }
        }
        static void ThreadSub()
        {
            lock (obj)
            {
                for (int i = 0; i < 100000; i++)
                {
                    cnt--;
                }
            }
        }
        static void Main(string[] args)
        {
            Thread tAdd = new Thread(new ThreadStart(ThreadAdd));
            Thread tSub = new Thread(new ThreadStart(ThreadSub));
            tAdd.Start();
            tSub.Start();

            tAdd.Join();
            tSub.Join();

            Console.WriteLine("2개 스레드의 결과값은 " + cnt);
        }
    }
}
