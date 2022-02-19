using System.Runtime.InteropServices;

namespace CXUtils.Utilities
{
    public static class MarshalUtils
    {
        /// <summary>
        ///     Converts to class type <typeparamref name="T"/> using the given <paramref name="bytes"/>
        /// </summary>
        public static T FromBytes<T>( byte[] bytes )
        {
            GCHandle gcHandle = GCHandle.Alloc( bytes, GCHandleType.Pinned );
            var structure = Marshal.PtrToStructure<T>( gcHandle.AddrOfPinnedObject() );
            gcHandle.Free();
            return structure;
        }
    }
}
