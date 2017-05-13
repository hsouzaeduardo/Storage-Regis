using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDebug
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 9999999; i++)
            {
                Console.WriteLine((i * 30 + i) / i);
            }

        }
    }
}
