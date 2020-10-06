using System;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace _56_ThreadError
{
    class Program
    {
        static int cnt = 0;

        static void ThreadAdd()
        {
            for (int i = 0; i < 100000; i++)
                cnt++;  // cnt = cnt + 1;
        }
        static void ThreadSub()
        {
            for (int i = 0; i < 100000; i++)
                cnt--;
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
