using CXUtils.Types;
using System;

namespace CXUtils.Common
{
    /// <summary>
    ///     Classic fractal brownian motion that uses <see cref="SimplexNoise"/>
    /// </summary>
    public static class FBMotion
    {
        /// <summary>
        ///     Samples from a <paramref name="sampler"/> given using fractal brownian motion
        /// </summary>
        public static float Sample(Float2 value, Func<Float2, float> sampler, float amplitude = .5f, int octaves = 2)
        {
            float result = 0f;

            for ( int i = 0; i < octaves; ++i )
            {
                result += amplitude * sampler(value);
                value *= 2f;
                amplitude *= .5f;
            }

            return result;
        }

        /// <summary>
        ///     Samples a simplex noise but with <paramref name="amplitude"/> and <paramref name="octaves"/>
        /// </summary>
        public static float Sample(Float2 value, float amplitude = .5f, int octaves = 2)
        {
            float result = 0f;

            for ( int i = 0; i < octaves; ++i )
            {
                result += amplitude * SimplexNoise.Sample(value);
                value *= 2f;
                amplitude *= .5f;
            }

            return result;
        }

        /// <inheritdoc cref="Sample(Float2, float, int)"/>
        public static float Sample(Float3 value, float amplitude = .5f, int octaves = 2)
        {
            float result = 0f;

            for ( int i = 0; i < octaves; ++i )
            {
                result += amplitude * SimplexNoise.Sample(value);
                value *= 2f;
                amplitude *= .5f;
            }

            return result;
        }

        /// <inheritdoc cref="Sample(Float2, float, int)"/>
        public static float Sample(Float4 value, float amplitude = .5f, int octaves = 2)
        {
            float result = 0f;

            for ( int i = 0; i < octaves; ++i )
            {
                result += amplitude * SimplexNoise.Sample(value);
                value *= 2f;
                amplitude *= .5f;
            }

            return result;
        }
    }
}