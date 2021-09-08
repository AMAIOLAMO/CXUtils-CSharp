using System;
using CXUtils.Common;
using CXUtils.Debugging;
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


        #region Evaluation & Choose

        /// <summary>
        ///     Randomly decides between these items <br />
        ///     NOTE: possibilities are the same
        /// </summary>
        public T Choose<T>( params T[] items ) => items[Next( 0, items.Length )];

        /// <summary>
        ///     Randomly decides and returns a boolean <br />
        ///     NOTE: excludes threshold (value > threshold)
        /// </summary>
        public bool EvaluateWeight( double threshold = .5f ) => NextDouble() > threshold;

        /// <summary>
        ///     Randomly decides between two items <br />
        ///     NOTE: excludes threshold (value > threshold)
        /// </summary>
        public T EvaluateWeight<T>( T t1, T t2, double threshold = .5d ) => EvaluateWeight( threshold ) ? t1 : t2;

        public int EvaluateWeights( int totalWeight, params int[] itemWeights )
        {
            Assertion.AssertInvalid( itemWeights.Length != 0, nameof( itemWeights ), InvalidReason.LengthZero );
            //assume weights are correct

            int rand = Next( 0, totalWeight + 1 );

            //get probability
            for ( int i = 0; i < itemWeights.Length; ++i )
            {
                //if in range
                if ( rand <= itemWeights[i] ) return i;

                rand -= itemWeights[i];
            }

            throw ExceptionUtils.Get( nameof( totalWeight ), totalWeight, InvalidReason.InvalidValue, $"the given {nameof( totalWeight )} is not the correct weight!" );
        }

        public int EvaluateWeights( params int[] itemWeights )
        {
            Assertion.AssertInvalid( itemWeights.Length != 0, nameof( itemWeights ), itemWeights, InvalidReason.LengthZero );

            int total = 0;

            //get total
            foreach ( int weight in itemWeights ) total += weight;

            return EvaluateWeights( total, itemWeights );
        }

        /// <summary>
        ///     Randomly decides between items with the given sorted pair <br />
        ///     NOTE: <paramref name="itemWeights" /> needs to be sorted from lowest to highest
        /// </summary>
        public bool TryEvaluateWeights( out int index, params int[] itemWeights )
        {
            index = default;
            if ( itemWeights.Length == 0 ) return false;

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

        public T EvaluateWeights<T>( T[] array, params int[] itemWeights ) => array[EvaluateWeights( itemWeights )];

        #endregion


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
