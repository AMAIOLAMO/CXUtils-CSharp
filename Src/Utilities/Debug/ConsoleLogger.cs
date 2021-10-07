using System;

namespace CXUtils.Debugging
{
    /// <summary>
    ///     Basic console logger class
    /// </summary>
    public class ConsoleLogger : ILogger
    {
        public void Log<T>( T obj ) => Console.WriteLine( obj );
        public void Log<T>( params T[] objs ) => Console.WriteLine( objs );
    }
}
