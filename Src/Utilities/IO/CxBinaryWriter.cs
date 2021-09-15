using System;
using System.IO;
using System.Text;
using CXUtils.Types;

namespace CXUtils.IO
{
    /// <summary>
    ///     An extended binary writer for this library
    /// </summary>
    public class CxBinaryWriter : BinaryWriter
    {
        public CxBinaryWriter( Stream output ) : base( output ) { }
        public CxBinaryWriter( Stream output, Encoding encoding ) : base( output, encoding ) { }
        public CxBinaryWriter( Stream output, Encoding encoding, bool leaveOpen ) : base( output, encoding, leaveOpen ) { }

        #region Vectors

        public void Write( Float2 value )
        {
            Write( value.x );
            Write( value.y );
        }

        public void Write( Float3 value )
        {
            Write( value.x );
            Write( value.y );
            Write( value.z );
        }

        public void Write( Float4 value )
        {
            Write( value.x );
            Write( value.y );
            Write( value.z );
            Write( value.w );
        }

        public void Write( Int2 value )
        {
            Write( value.x );
            Write( value.y );
        }

        public void Write( Int3 value )
        {
            Write( value.x );
            Write( value.y );
            Write( value.z );
        }

        public void Write( Int4 value )
        {
            Write( value.x );
            Write( value.y );
            Write( value.z );
            Write( value.w );
        }

        #endregion

        #region Colors

        public void Write( ColorAByte value )
        {
            #if CXUTILS_UNSAFE && NETCOREAPP2_0_OR_GREATER
            unsafe
            {
                Write( new ReadOnlySpan<byte>( &value, sizeof( byte ) * 4 ) );
            }
            #else
            Write( value.r );
            Write( value.g );
            Write( value.b );
            Write( value.a );
            #endif
        }
        public void Write( ColorAFloat value )
        {
            #if CXUTILS_UNSAFE && NETCOREAPP2_0_OR_GREATER
            unsafe
            {
                Write( new ReadOnlySpan<byte>( &value, sizeof( float ) * 4 ) );
            }
            #else
            Write( value.r );
            Write( value.g );
            Write( value.b );
            Write( value.a );
            #endif
        }
        public void Write( ColorAInt value )
        {
            #if CXUTILS_UNSAFE && NETCOREAPP2_0_OR_GREATER
            unsafe
            {
                Write( new ReadOnlySpan<byte>( &value, sizeof( int ) * 4 ) );
            }
            #else
            Write( value.r );
            Write( value.g );
            Write( value.b );
            Write( value.a );
            #endif
        }

        public void Write( ColorByte value )
        {
            #if CXUTILS_UNSAFE && NETCOREAPP2_0_OR_GREATER
            unsafe
            {
                Write( new ReadOnlySpan<byte>( &value, sizeof( byte ) * 3 ) );
            }
            #else
            Write( value.r );
            Write( value.g );
            Write( value.b );
            #endif
        }
        public void Write( ColorFloat value )
        {
            #if CXUTILS_UNSAFE && NETCOREAPP2_0_OR_GREATER
            unsafe
            {
                Write( new ReadOnlySpan<byte>( &value, sizeof( float ) * 3 ) );
            }
            #else
            Write( value.r );
            Write( value.g );
            Write( value.b );
            #endif
        }
        public void Write( ColorInt value )
        {
            #if CXUTILS_UNSAFE && NETCOREAPP2_0_OR_GREATER
            unsafe
            {
                Write( new ReadOnlySpan<byte>( &value, sizeof( int ) * 3 ) );
            }
            #else
            Write( value.r );
            Write( value.g );
            Write( value.b );
            #endif
        }

        #endregion
    }
}
