using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helloworld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Number =");
            String a = Console.ReadLine();
            int b = int.Parse(a);
            Console.WriteLine("Results"+(b+10));
            Console.ReadLine();
        }
    }
}
