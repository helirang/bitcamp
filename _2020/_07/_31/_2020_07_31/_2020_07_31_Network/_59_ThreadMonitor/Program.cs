using System;
using System.Threading;

namespace _59_ThreadMonitor
{
    class Program
    {
        // lock을 걸기 위한 자물쇠
        static object obj = new object();

        static int cnt = 0;

        static void ThreadAdd()
        {
            Monitor.Enter(obj); // 자물쇠로 잠근다
            for (int i = 0; i < 10000000; i++)
            {
                cnt++;
            }
            Monitor.Exit(obj);  // 자물쇠를 연다
        }
        static void ThreadSub()
        {
            Monitor.Enter(obj); // 자물쇠로 잠근다
            for (int i = 0; i < 10000000; i++)
            {
                cnt--;
            }
            Monitor.Exit(obj);  // 자물쇠를 연다
        }
        static void Main(string[] args)
        {
            Thread tAdd0 = new Thread(new ThreadStart(ThreadAdd));
            Thread tAdd1 = new Thread(new ThreadStart(ThreadAdd));
            Thread tAdd2 = new Thread(new ThreadStart(ThreadAdd));
            Thread tSub0 = new Thread(new ThreadStart(ThreadSub));
            Thread tSub1 = new Thread(new ThreadStart(ThreadSub));
            Thread tSub2 = new Thread(new ThreadStart(ThreadSub));
            tAdd0.Start();
            tAdd1.Start();
            tAdd2.Start();
            tSub0.Start();
            tSub1.Start();
            tSub2.Start();

            tAdd0.Join();
            tAdd1.Join();
            tAdd2.Join();
            tSub0.Join();
            tSub1.Join();
            tSub2.Join();

            Console.WriteLine("2개 스레드의 결과값은 " + cnt);
        }
    }
}
