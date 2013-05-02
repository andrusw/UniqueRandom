using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniqueRandom
{
    /// <summary>
    /// A random number that is distributed on the normal (or Gaussian) distribution. 
    /// 
    /// The center of the bell-shape curve (by default) is centered on the number 0.
    /// Range -1 to 1 will hold 68.2689492137% of the returned numbers.
    /// Range -2 to 2 will hold 95.4499736104% of the returned numbers.
    /// Range -3 to 3 will hold 99.7300203937% of the returned numbers.
    /// Range -4 to 4 will hold 99.9936657516% of the returned numbers.
    /// Range -5 to 5 will hold 99.9999426697% of the returned numbers.
    /// Range -6 to 6 will hold 99.9999998027% of the returned numbers.
    /// .
    /// .
    /// </summary>
    public class NormalDistribution
    {            
        private Random rand;

        #region Constructors

        /// <summary>
        /// Initialize a new instance of UniqueRandom.NormalDistribution class, using a time-dependent default seed value.
        /// </summary>
        public NormalDistribution()
        {
            rand = new Random();
        }

        /// <summary>
        /// Initialize a new instance of UniqueRandom.NormalDistribution class, using the specified seed value.
        /// </summary>
        /// <param name="seed"></param>
        public NormalDistribution(int seed)
        {
            rand = new Random(seed);
        }

        #endregion

        /// <summary>
        /// Generates the normal distribution with two numbers, which is then randomly selected between the two.
        /// </summary>
        /// <returns></returns>
        private double GetRandomValue()
        {
            double x1, x2, w, y1, y2;

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

        #region Int Returns

        /// <summary>
        /// Returns a random number.
        /// </summary>
        /// <returns>A 32-bit signed integer</returns>
        /// <remarks>
        /// Generates a random numbers whose value ranges from -6 to 6, 99.9999998027% of the time, with the majority of the numbers will fall on 0. 
        /// To generate a random number whose value ranges fall within a set bound use NormalDistribution.Next(Int32, Int32) method overload.
        /// </remarks>
        /// <example>
        /// NormalDistribution nrd = new NormalDistribution();
        /// nrd.Next();
        /// </example>
        public int Next()
        {
            return (int)GetRandomValue();
        }

        /// <summary>
        /// Returns a number less than the specified maximum, without shifting distribution. 
        /// </summary>
        /// <param name="maxValue">The exclusive upper bound of the random number to be generated.</param>
        /// <returns>A 32-bit signed integer less than maxValue.</returns>
        /// <example>
        /// NormalDistribution nrd = new NormalDistribution();
        /// nrd.Next(0);
        /// </example>
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
        /// Return a random number within a specific range, without shifting distribution. 
        /// </summary>
        /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
        /// <param name="maxValue">The exclusive upper bound of the random number returned. maxValue must be greater than the minValue.</param>
        /// <returns>A 32-bit signed integer greater than or equal to minValue and less than maxValue; that is, the range of return values includes minValue but not maxValue. If minValue equals maxValue, minValue is returned.</returns>
        /// <exception cref="ArgumentOutOfRangeException">minValue is greater than maxValue.</exception>
        /// <remarks>
        /// This method will return a range of values with the normal distribution centered on 0. This is the ideal method, if you do not want to handle outliers in your program.
        /// </remarks>
        /// <example>
        /// NormalDistribution nrd = new NormalDistribution();
        /// nrd.Next(-4,4);
        /// </example>
        public int Next(int minValue, int maxValue)
        {
            if (minValue > maxValue)
                throw new ArgumentOutOfRangeException();

            int randVal = (int)GetRandomValue();

            while (minValue > randVal || maxValue <= randVal)
            {
                randVal = (int)GetRandomValue();
            }

            return randVal;
        }

        #endregion

        #region Double Returns

        /// <summary>
        /// Returns a random number.
        /// </summary>
        /// <returns>A double-precision floating point number.</returns>
        /// <remarks>
        /// Generates a random numbers whose value ranges from -6.0 to 6.0, 99.9999998027% of the time, with the majority of the numbers will fall on 0. 
        /// To generate a random number whose value ranges fall within a set bound use NormalDistribution.NextDouble(Double, Double) method overload.
        /// </remarks>
        /// <example>
        /// NormalDistribution nrd = new NormalDistribution();
        /// nrd.NextDouble();
        /// </example>
        public double NextDouble()
        {
            return (double)GetRandomValue();
        }

        /// <summary>
        /// Returns a number less than the specified maximum, without shifting distribution.
        /// </summary>
        /// <param name="maxValue">The exclusive upper bound of the random number to be generated.</param>
        /// <returns>A double-precision floating point number, less than maxValue.</returns>
        /// <example>
        /// NormalDistribution nrd = new NormalDistribution();
        /// nrd.NextDouble(0.0);
        /// </example>
        public double NextDouble(double maxValue)
        {
            double randVal = maxValue;
            while (randVal >= maxValue)
            {
                randVal = GetRandomValue();
            }

            return randVal;
        }

        /// <summary>
        /// Return a random number within a specific range, without shifting distribution. 
        /// </summary>
        /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
        /// <param name="maxValue">The exclusive upper bound of the random number returned. maxValue must be greater than the minValue.</param>
        /// <returns>A double-precision floating point number greater than or equal to minValue and less than maxValue; that is, the range of return values includes minValue but not maxValue. If minValue equals maxValue, minValue is returned.</returns>
        /// <exception cref="ArgumentOutOfRangeException">minValue is greater than maxValue.</exception>
        /// <remarks>
        /// This method will return a range of values with the normal distribution centered on 0. This is the ideal method, if you do not want to handle outliers in your program.
        /// </remarks>
        /// <example>
        /// NormalDistribution nrd = new NormalDistribution();
        /// nrd.NextDouble(-4.0,4.0);
        /// </example>
        public double NextDouble(double minValue, double maxValue)
        {
            if (minValue > maxValue)
                throw new ArgumentOutOfRangeException();

            double randVal = GetRandomValue();

            while (minValue > randVal || maxValue <= randVal)
            {
                randVal = GetRandomValue();
            }

            return randVal;
        }

        #endregion

        #region Byte Array

        /// <summary>
        /// Fills the elements of a specified array of bytes with random numbers.
        /// </summary>
        /// <param name="buffer"></param>
        /// <exception cref="ArgumentNullException">buffer is null</exception>
        /// <remarks>
        /// Each element of the array of bytes is set to a random number.
        /// </remarks>
        public void NextBytes(Byte[] buffer)
        {
            if(buffer == null)
                throw new ArgumentNullException();

            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] =  (byte)((int)(Math.Abs(NextDouble(-2.55, 2.55)) * 100));
            }
        }
        #endregion

    }
}
