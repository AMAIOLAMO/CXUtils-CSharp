using System;
using System.Collections.Generic;

namespace CXUtils.Common
{
    /// <summary>
    ///     An extension for the system random
    /// </summary>
    public static class CxRandomExtension
    {
        /// <summary>
        ///     Gives a random number between <see cref="float.MinValue"/> ~ <see cref="float.MaxValue">
        /// </summary>
        public static float NextFloat(this Random random)
        {
            double mantissa = random.NextDouble() * 2d - 1d;

            double exponent = Math.Pow(2d, random.Next(-126, 128));
            return (float)(mantissa * exponent);
        }

        /// <summary>
        ///     Gives a random number between <paramref name="min"/> ~ <paramref name="max"/>
        /// </summary>
        public static float NextFloat(this Random random, float min, float max) => (float)random.NextDouble() * (max - min) + min;

        /// <summary>
        ///     Gives a random number between 0 ~ <paramref name="max"/>
        /// </summary>
        public static float NextFloat(this Random random, float max) => (float)random.NextDouble() * max;

        /// <summary>
        ///     Randomly decides and returns a boolean <br />
        ///     NOTE: excludes threshold (value > threshold)
        /// </summary>
        public static bool Choose(this Random random, double threshold = .5f) => random.NextDouble() > threshold;

        /// <summary>
        ///     Randomly decides between two items <br />
        ///     NOTE: excludes threshold (value > threshold)
        /// </summary>
        public static T Choose<T>(this Random random, T t1, T t2, double threshold = .5d) => random.Choose(threshold) ? t1 : t2;

        /// <summary>
        ///     Randomly decides between these items <br />
        ///     NOTE: possibilities are the same
        /// </summary>
        public static T Choose<T>(this Random random, params T[] items) => items[random.Next(0, items.Length)];

        /// <summary>
        ///     Randomly decides between items with the given sorted pair <br />
        ///     NOTE: <paramref name="itemWeights" /> needs to be sorted from lowest to highest
        /// </summary>
        public static bool TryChoose<T>(this Random random, out int index, params int[] itemWeights)
        {
            int total = 0;

            //get total
            foreach ( var weight in itemWeights ) total += weight;

            int rand = random.Next(0, total + 1);

            //get probability
            for ( int i = 0; i < itemWeights.Length; ++i )
            {
                //if in range
                if ( rand > itemWeights[i] )
                {
                    rand -= itemWeights[i];
                    continue;
                }
                //else
                index = i;
                return true;

            }

            throw ExceptionUtils.Error.NotAccessible;
        }
    }
}
