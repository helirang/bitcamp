using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace solu_1
{
    class product
    {
        private int price = 100;

        public ref int GetPrice()
        {
            return ref price;

        }

        public void PrintPrice()
        {
            WriteLine($"Price : {price}");
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            product carrot = new product();
            ref int ref_local_price = ref carrot.GetPrice();
            int normal_local_price = carrot.GetPrice();

            carrot.PrintPrice();
            WriteLine($"Ref local price : {ref_local_price}");
            WriteLine($"Normal local price : {normal_local_price}");

            ref_local_price = 200;

            carrot.PrintPrice();
            WriteLine($"Ref local price : {ref_local_price}");
            WriteLine($"Normal local price : {normal_local_price}");
        }
    }
}
