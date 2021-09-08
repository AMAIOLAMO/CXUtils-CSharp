using System;
using System.Diagnostics;
using CXUtils.Common;
using CXUtils.Types;

namespace CXUtils.Utilities
{
    /// <summary>
    ///     An extended random class that supports CXUtilities
    /// </summary>
    public class CxRandom : Random
    {
        /// <summary>
        ///     Gives a random number between <see cref="float.MinValue" /> ~ <see cref="float.MaxValue" />
        /// </summary>
        public float NextFloat() => (float)NextDouble();

        /// <summary>
        ///     Gives a random number between <paramref name="min" /> ~ <paramref name="max" />
        /// </summary>
        public float NextFloat( float min, float max ) => NextFloat() * ( max - min ) + min;

        /// <summary>
        ///     Gives a random number between 0 ~ <paramref name="max" />
        /// </summary>
        public float NextFloat( float max ) => NextFloat() * max;

        /// <summary>
        ///     Randomly decides and returns a boolean <br />
        ///     NOTE: excludes threshold (value > threshold)
        /// </summary>
        public bool Choose( double threshold = .5f ) => NextDouble() > threshold;

        /// <summary>
        ///     Randomly decides between two items <br />
        ///     NOTE: excludes threshold (value > threshold)
        /// </summary>
        public T Choose<T>( T t1, T t2, double threshold = .5d ) => Choose( threshold ) ? t1 : t2;

        /// <summary>
        ///     Randomly decides between these items <br />
        ///     NOTE: possibilities are the same
        /// </summary>
        public T Choose<T>( params T[] items ) => items[Next( 0, items.Length )];

        public int EvaluateWeights( params int[] itemWeights )
        {
            Debug.Assert( itemWeights.Length != 0, nameof( itemWeights ) + " array length is 0!" );

            int total = 0;

            //get total
            foreach ( int weight in itemWeights ) total += weight;

            int rand = Next( 0, total + 1 );

            //get probability
            for ( int i = 0; i < itemWeights.Length; ++i )
            {
                //if in range
                if ( rand <= itemWeights[i] ) return i;

                rand -= itemWeights[i];
            }

            throw ExceptionUtils.NotAccessible;
        }

        /// <summary>
        ///     Randomly decides between items with the given sorted pair <br />
        ///     NOTE: <paramref name="itemWeights" /> needs to be sorted from lowest to highest
        /// </summary>
        public bool TryEvaluateWeights( out int index, params int[] itemWeights )
        {
            int total = 0;

            //get total
            foreach ( int weight in itemWeights ) total += weight;

            int rand = Next( 0, total + 1 );

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

            throw ExceptionUtils.NotAccessible;
        }

        #region Vectors

        public Float2 NextFloat2() => new Float2( NextFloat(), NextFloat() );
        public Float3 NextFloat3() => new Float3( NextFloat(), NextFloat(), NextFloat() );
        public Float4 NextFloat4() => new Float4( NextFloat(), NextFloat(), NextFloat(), NextFloat() );

        public Float2 NextFloat2( float max ) => new Float2( NextFloat( max ), NextFloat( max ) );
        public Float3 NextFloat3( float max ) => new Float3( NextFloat( max ), NextFloat( max ), NextFloat( max ) );
        public Float4 NextFloat4( float max ) => new Float4( NextFloat( max ), NextFloat( max ), NextFloat( max ), NextFloat( max ) );

        public Float2 NextFloat2( float min, float max ) => new Float2( NextFloat( min, max ), NextFloat( min, max ) );
        public Float3 NextFloat3( float min, float max ) => new Float3( NextFloat( min, max ), NextFloat( min, max ), NextFloat( min, max ) );
        public Float4 NextFloat4( float min, float max ) => new Float4( NextFloat( min, max ), NextFloat( min, max ), NextFloat( min, max ), NextFloat( min, max ) );

        public Int2 NextInt2() => new Int2( Next(), Next() );
        public Int3 NextInt3() => new Int3( Next(), Next(), Next() );
        public Int4 NextInt4() => new Int4( Next(), Next(), Next(), Next() );

        public Int2 NextInt2( int max ) => new Int2( Next( max ), Next( max ) );
        public Int3 NextInt3( int max ) => new Int3( Next( max ), Next( max ), Next( max ) );
        public Int4 NextInt4( int max ) => new Int4( Next( max ), Next( max ), Next( max ), Next( max ) );

        public Int2 NextInt2( int min, int max ) => new Int2( Next( min, max ), Next( min, max ) );
        public Int3 NextInt3( int min, int max ) => new Int3( Next( min, max ), Next( min, max ), Next( min, max ) );
        public Int4 NextInt4( int min, int max ) => new Int4( Next( min, max ), Next( min, max ), Next( min, max ), Next( min, max ) );

        #endregion
    }
}
