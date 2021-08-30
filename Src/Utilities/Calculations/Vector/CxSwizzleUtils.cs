using System;
using System.Diagnostics;

namespace CXUtils.Types.Utils
{
    public static class CxSwizzleUtils
    {
        public static object Swizz( this Float2 vector, string swizzle )
        {
            Debug.Assert( swizzle.Length > 4 || swizzle.Length == 0, "swizzle cannot be over 4 or non elements!" );

            float[] values = new float[swizzle.Length];

            for ( int i = 0; i < swizzle.Length; ++i )
            {
                char loweredLetter = char.ToLower( swizzle[i] );

                switch ( loweredLetter )
                {
                    case 'x':
                        values[i] = vector[0];
                        continue;
                    case 'y':
                        values[i] = vector[1];
                        continue;

                    default: throw new ArgumentOutOfRangeException();
                }
            }

            switch ( swizzle.Length )
            {
                case 1: return values[0];
                case 2: return new Float2( values[0], values[1] );
                case 3: return new Float3( values[0], values[1], values[3] );
                case 4: return new Float4( values[0], values[1], values[2], values[3] );

                default: throw new ArgumentOutOfRangeException();
            }
        }
        
        public static object Swizz( this Float3 vector, string swizzle )
        {
            Debug.Assert( swizzle.Length > 4 || swizzle.Length == 0, "swizzle cannot be over 4 or non elements!" );

            float[] values = new float[swizzle.Length];

            for ( int i = 0; i < swizzle.Length; ++i )
            {
                char loweredLetter = char.ToLower( swizzle[i] );

                switch ( loweredLetter )
                {
                    case 'x':
                        values[i] = vector[0];
                        continue;
                    case 'y':
                        values[i] = vector[1];
                        continue;
                    case 'z':
                        values[i] = vector[1];
                        continue;

                    default: throw new ArgumentOutOfRangeException();
                }
            }

            switch ( swizzle.Length )
            {
                case 1: return values[0];
                case 2: return new Float2( values[0], values[1] );
                case 3: return new Float3( values[0], values[1], values[3] );
                case 4: return new Float4( values[0], values[1], values[2], values[3] );

                default: throw new ArgumentOutOfRangeException();
            }
        }
        
        public static object Swizz( this Float4 vector, string swizzle )
        {
            Debug.Assert( swizzle.Length > 4 || swizzle.Length == 0, "swizzle cannot be over 4 or non elements!" );

            float[] values = new float[swizzle.Length];

            for ( int i = 0; i < swizzle.Length; ++i )
            {
                char loweredLetter = char.ToLower( swizzle[i] );

                switch ( loweredLetter )
                {
                    case 'x':
                        values[i] = vector[0];
                        continue;
                    case 'y':
                        values[i] = vector[1];
                        continue;
                    case 'z':
                        values[i] = vector[2];
                        continue;
                    case 'w':
                        values[i] = vector[3];
                        continue;

                    default: throw new ArgumentOutOfRangeException();
                }
            }

            switch ( swizzle.Length )
            {
                case 1: return values[0];
                case 2: return new Float2( values[0], values[1] );
                case 3: return new Float3( values[0], values[1], values[3] );
                case 4: return new Float4( values[0], values[1], values[2], values[3] );

                default: throw new ArgumentOutOfRangeException();
            }
        }
        
        public static object Swizz( this Int2 vector, string swizzle )
        {
            Debug.Assert( swizzle.Length > 4 || swizzle.Length == 0, "swizzle cannot be over 4 or non elements!" );

            int[] values = new int[swizzle.Length];

            for ( int i = 0; i < swizzle.Length; ++i )
            {
                char loweredLetter = char.ToLower( swizzle[i] );

                switch ( loweredLetter )
                {
                    case 'x':
                        values[i] = vector[0];
                        continue;
                    case 'y':
                        values[i] = vector[1];
                        continue;

                    default: throw new ArgumentOutOfRangeException();
                }
            }

            switch ( swizzle.Length )
            {
                case 1: return values[0];
                case 2: return new Int2( values[0], values[1] );
                case 3: return new Int3( values[0], values[1], values[3] );
                case 4: return new Int4( values[0], values[1], values[2], values[3] );

                default: throw new ArgumentOutOfRangeException();
            }
        }
        
        public static object Swizz( this Int3 vector, string swizzle )
        {
            Debug.Assert( swizzle.Length > 4 || swizzle.Length == 0, "swizzle cannot be over 4 or non elements!" );

            int[] values = new int[swizzle.Length];

            for ( int i = 0; i < swizzle.Length; ++i )
            {
                char loweredLetter = char.ToLower( swizzle[i] );

                switch ( loweredLetter )
                {
                    case 'x':
                        values[i] = vector[0];
                        continue;
                    case 'y':
                        values[i] = vector[1];
                        continue;
                    case 'z':
                        values[i] = vector[1];
                        continue;

                    default: throw new ArgumentOutOfRangeException();
                }
            }

            switch ( swizzle.Length )
            {
                case 1: return values[0];
                case 2: return new Int2( values[0], values[1] );
                case 3: return new Int3( values[0], values[1], values[3] );
                case 4: return new Int4( values[0], values[1], values[2], values[3] );

                default: throw new ArgumentOutOfRangeException();
            }
        }
        
        public static object Swizz( this Int4 vector, string swizzle )
        {
            Debug.Assert( swizzle.Length > 4 || swizzle.Length == 0, "swizzle cannot be over 4 or non elements!" );

            int[] values = new int[swizzle.Length];

            for ( int i = 0; i < swizzle.Length; ++i )
            {
                char loweredLetter = char.ToLower( swizzle[i] );

                switch ( loweredLetter )
                {
                    case 'x':
                        values[i] = vector[0];
                        continue;
                    case 'y':
                        values[i] = vector[1];
                        continue;
                    case 'z':
                        values[i] = vector[2];
                        continue;
                    case 'w':
                        values[i] = vector[3];
                        continue;

                    default: throw new ArgumentOutOfRangeException();
                }
            }

            switch ( swizzle.Length )
            {
                case 1: return values[0];
                case 2: return new Int2( values[0], values[1] );
                case 3: return new Int3( values[0], values[1], values[3] );
                case 4: return new Int4( values[0], values[1], values[2], values[3] );

                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}
