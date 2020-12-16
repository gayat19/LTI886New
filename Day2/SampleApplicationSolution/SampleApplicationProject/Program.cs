using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApplicationProject
{
    partial class Program
    {
        static void Main(string[] args)
        {
            new Program().PrintWelcome();
            Console.WriteLine("Hello World!!!");
            Console.WriteLine("Another line");
            Console.ReadKey();
        }
    }
}
