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
        
        public void WriteFloat2( Float2 value )
        {
            Write( value.x );
            Write( value.y );
        }

        public void WriteFloat3( Float3 value )
        {
            Write( value.x );
            Write( value.y );
            Write( value.z );
        }

        public void WriteFloat4( Float4 value )
        {
            Write( value.x );
            Write( value.y );
            Write( value.z );
            Write( value.w );
        }

        public void WriteInt2( Int2 value )
        {
            Write( value.x );
            Write( value.y );
        }

        public void WriteInt3( Int3 value )
        {
            Write( value.x );
            Write( value.y );
            Write( value.z );
        }

        public void WriteInt4( Int4 value )
        {
            Write( value.x );
            Write( value.y );
            Write( value.z );
            Write( value.w );
        }
    }
}
