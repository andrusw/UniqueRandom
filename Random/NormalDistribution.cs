using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniqueRandom
{
    public class NormalDistribution
    {            
        private Random rand;

        public NormalDistribution()
        {
            rand = new Random();
        }

        public NormalDistribution(int seed)
        {
            rand = new Random(seed);
        }

        private double GetRandomValue()
        {
            double x1, x2, w, y1, y2;
            int count = 1;

            do
            {
                x1 = 2.0 * rand.NextDouble() - 1.0;
                x2 = 2.0 * rand.NextDouble() - 1.0;
                w = x1 * x1 + x2 * x2;
            } while (w >= 1.0);

            w = Math.Sqrt((-2.0 * Math.Log(w))/ w);
            y1 = x1 * w;
            y2 = x2 * w;

            return rand.Next(2) == 0 ? y1 : y2;
        }

        /// <summary>
        /// Returns a random number (usually 99.99% of the time) in the range between -4 to 4
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public int Next()
        {
            return (int)GetRandomValue();
        }

        /// <summary>
        /// Returns a number less than the specified maximum.
        /// </summary>
        /// <param name="maxValue">The exclusive upper bound of the random number to be generated.</param>
        /// <returns></returns>
        public int Next(int maxValue)
        {
            int randVal = maxValue;
            while (randVal >= maxValue)
            {
                randVal = (int)GetRandomValue();
            }

            return randVal;
        }

        /// <summary>
        /// Returns a random number (usually 99.99% of the time) in the range between -4 to 4
        /// </summary>
        /// <returns></returns>
        public double NextDouble()
        {
            return (double)GetRandomValue();
        }


    }
}
