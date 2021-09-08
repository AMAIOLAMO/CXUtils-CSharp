namespace CXUtils.Debugging
{
    /// <summary>
    ///     Implements a basic logger
    /// </summary>
    public interface ILogger
    {
        void Log( object obj );
        void Log( params object[] objs );
    }
}
