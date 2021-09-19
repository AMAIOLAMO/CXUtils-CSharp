using System;
using System.IO;
using System.Text;
using CXUtils.Types;

namespace CXUtils.IO
{
    /// <summary>
    ///     An extended binary reader for this library
    /// </summary>
    public class CxBinaryReader : BinaryReader
    {
        public CxBinaryReader( Stream input ) : base( input ) { }
        public CxBinaryReader( Stream input, Encoding encoding ) : base( input, encoding ) { }
        public CxBinaryReader( Stream input, Encoding encoding, bool leaveOpen ) : base( input, encoding, leaveOpen ) { }


        #region Vectors

        public Float2 ReadFloat2()
        {
            byte[] buffer = ReadBytes( sizeof( float ) * 2 );

            return new Float2( BitConverter.ToSingle( buffer, 0 ),
                BitConverter.ToSingle( buffer, 4 ) );
        }

        public Float3 ReadFloat3()
        {
            byte[] buffer = ReadBytes( sizeof( float ) * 3 );

            return new Float3( BitConverter.ToSingle( buffer, 0 ),
                BitConverter.ToSingle( buffer, 4 ),
                BitConverter.ToSingle( buffer, 8 ) );
        }

        public Float4 ReadFloat4()
        {
            byte[] buffer = ReadBytes( sizeof( float ) * 4 );

            return new Float4( BitConverter.ToSingle( buffer, 0 ),
                BitConverter.ToSingle( buffer, 4 ),
                BitConverter.ToSingle( buffer, 8 ),
                BitConverter.ToSingle( buffer, 12 ) );
        }

        public Int2 ReadInt2()
        {
            byte[] buffer = ReadBytes( sizeof( int ) * 2 );

            return new Int2( BitConverter.ToInt32( buffer, 0 ),
                BitConverter.ToInt32( buffer, 4 ) );
        }

        public Int3 ReadInt3()
        {
            byte[] buffer = ReadBytes( sizeof( int ) * 3 );

            return new Int3( BitConverter.ToInt32( buffer, 0 ),
                BitConverter.ToInt32( buffer, 4 ),
                BitConverter.ToInt32( buffer, 8 ) );
        }

        public Int4 ReadInt4()
        {
            byte[] buffer = ReadBytes( sizeof( int ) * 4 );

            return new Int4( BitConverter.ToInt32( buffer, 0 ),
                BitConverter.ToInt32( buffer, 4 ),
                BitConverter.ToInt32( buffer, 8 ),
                BitConverter.ToInt32( buffer, 12 ) );
        }

        #endregion

        #region Colors

        public ColorAByte ReadColorAByte() =>
            new ColorAByte( ReadByte(),
                ReadByte(),
                ReadByte(),
                ReadByte() );

        public ColorAFloat ReadColorAFloat()
        {
            byte[] buffer = ReadBytes( sizeof( float ) * 4 );

            return new ColorAFloat( BitConverter.ToSingle( buffer, 0 ),
                BitConverter.ToSingle( buffer, 4 ),
                BitConverter.ToSingle( buffer, 8 ),
                BitConverter.ToSingle( buffer, 12 ) );
        }

        public ColorAInt ReadColorAInt()
        {
            byte[] buffer = ReadBytes( sizeof( int ) * 4 );

            return new ColorAInt( BitConverter.ToInt32( buffer, 0 ),
                BitConverter.ToInt32( buffer, 4 ),
                BitConverter.ToInt32( buffer, 8 ),
                BitConverter.ToInt32( buffer, 12 ) );
        }

        public ColorByte ReadColorByte() =>
            new ColorByte( ReadByte(),
                ReadByte(),
                ReadByte() );

        public ColorFloat ReadColorFloat()
        {
            byte[] buffer = ReadBytes( sizeof( float ) * 3 );

            return new ColorFloat( BitConverter.ToSingle( buffer, 0 ),
                BitConverter.ToSingle( buffer, 4 ),
                BitConverter.ToSingle( buffer, 8 ) );
        }

        public ColorInt ReadColorInt()
        {
            byte[] buffer = ReadBytes( sizeof( int ) * 3 );

            return new ColorAInt( BitConverter.ToInt32( buffer, 0 ),
                BitConverter.ToInt32( buffer, 4 ),
                BitConverter.ToInt32( buffer, 8 ) );
        }

        #endregion
    }

}
