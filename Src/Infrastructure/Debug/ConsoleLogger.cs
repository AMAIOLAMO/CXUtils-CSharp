using System;

namespace CXUtils.Debugging
{
    /// <summary>
    ///     Basic console logger class
    /// </summary>
    public class ConsoleLogger : ILogger
    {
        public void Log<T>( T item ) => Console.WriteLine( item );
        public void Log<T>( params T[] items ) => Console.WriteLine( items );
    }
}
