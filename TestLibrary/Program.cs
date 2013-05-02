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
                Console.Write(nrd.Next().ToString() + ' ');
            }

            Console.WriteLine();

            Console.Write("Normal Distribution of Integers: ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(nrd.Next(0).ToString() + ' ');
            }

            Console.WriteLine();



            Console.Write("Normal Distribution of Double: ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(nrd.NextDouble().ToString() + ' ');
            }

            Console.ReadKey();
        }
    }
}
