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

            Console.Write("Normal Distribution of Integers: ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(nrd.NextDouble(0.0).ToString() + ' ');
            }

            Console.WriteLine();

            




            Console.ReadKey();
        }
    }
}
