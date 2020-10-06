using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace test0608
{
    class Program
    {
        static void Divide(int a, int b, out int c, out int d)
        {
            c = a / b;
            d = a % b;
        }
        static void Main(string[] args)
        {
            int a = 20;
            int b = 3;

            Divide(a, b, out int c, out int d);

            WriteLine($"a: {a}, b: {b}, c: {c}, d: {d}");

        }
    }
}
