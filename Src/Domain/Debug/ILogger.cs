namespace CXUtils.Debugging
{
    /// <summary>
    ///     Implements a basic logger
    /// </summary>
    public interface ILogger
    {
        void Log<T>( T obj );
        void Log<T>( params T[] objs );
    }
}
