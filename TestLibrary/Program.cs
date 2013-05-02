using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniqueRandom;


namespace TestLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            NormalDistribution nrd = new NormalDistribution();

            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine(nrd.NextDoubleShift(86,86,86.0001).ToString());
            }

            Console.ReadKey();
        }
    }
}
