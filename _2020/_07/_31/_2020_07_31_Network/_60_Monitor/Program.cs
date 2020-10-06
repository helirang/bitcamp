using System;
using System.Threading;

namespace _60_Monitor
{
    class Program
    {        
        static int[] pots = new int[3]; // 물을 채울 항아리
        static Random rand = new Random();
        static object obj = new object();   // 자물쇠

        static void WaterPush()
        {
            while (true)
            {
                Monitor.Enter(obj);
                for(int i = 0; i < pots.Length; i++)
                {
                    pots[i] = rand.Next(10);
                    Console.WriteLine("콩쥐: {0}", pots[i]);
                }
                Console.WriteLine("******************************");
                Monitor.Exit(obj);
                Thread.Sleep(1000);
            }
        }
        static void WaterPop()
        {
            while (true)
            {
                Monitor.Enter(obj);
                for (int i = 0; i < pots.Length; i++)
                {
                    Console.WriteLine("팥쥐: {0}", pots[i]);
                    pots[i] = -1;
                }
                Console.WriteLine("==============================");
                Monitor.Exit(obj);
                Thread.Sleep(1000);
            }
        }

        static void Main(string[] args)
        {
            Thread tCongJui = new Thread(new ThreadStart(WaterPush));
            Thread tPotJui = new Thread(new ThreadStart(WaterPop));
            tCongJui.Start();
            Thread.Sleep(10);
            tPotJui.Start();
        }
    }
}
