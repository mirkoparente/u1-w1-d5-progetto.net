using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace u1_w1_d5_progetto.net
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;


            Contribuente contribuente = new Contribuente();
            contribuente.Menu();

            Console.ReadLine();
        }
    }
}
