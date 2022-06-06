using System.IO;
using System.Text;
using CXUtils.Domain.Types;

namespace CXUtils.IO
{
	/// <summary>
	///     An extended binary writer for this library
	/// </summary>
	public class CxBinaryWriter : BinaryWriter
	{
		public CxBinaryWriter(Stream output) : base(output) { }
		public CxBinaryWriter(Stream output, Encoding encoding) : base(output, encoding) { }
		public CxBinaryWriter(Stream output, Encoding encoding, bool leaveOpen) : base(output, encoding, leaveOpen) { }

		public static CxBinaryWriter From(string filePath) =>
			new(File.OpenWrite(filePath));
		
		public static CxBinaryWriter From(string filePath, FileMode mode) =>
			new(File.Open(filePath, mode, FileAccess.Write));
		
		#region Vectors

		public void Write(Float2 value)
		{
			Write(value.x);
			Write(value.y);
		}

		public void Write(Float3 value)
		{
			Write(value.x);
			Write(value.y);
			Write(value.z);
		}

		public void Write(Float4 value)
		{
			Write(value.x);
			Write(value.y);
			Write(value.z);
			Write(value.w);
		}

		public void Write(Int2 value)
		{
			Write(value.x);
			Write(value.y);
		}

		public void Write(Int3 value)
		{
			Write(value.x);
			Write(value.y);
			Write(value.z);
		}

		public void Write(Int4 value)
		{
			Write(value.x);
			Write(value.y);
			Write(value.z);
			Write(value.w);
		}

		#endregion
	}
}
