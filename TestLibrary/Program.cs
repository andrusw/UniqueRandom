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
            Byte[] b = new Byte[10];
            nrd.NextBytes(b);

            for (int i = 0; i < b.Length; i++)
            {
                Console.WriteLine(b[i].ToString());
            }

            Console.ReadKey();
        }
    }
}
