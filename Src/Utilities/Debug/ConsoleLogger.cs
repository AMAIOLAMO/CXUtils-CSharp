using System;

namespace CXUtils.Debugging
{
    /// <summary>
    ///     Basic logger class
    /// </summary>
    public class ConsoleLogger : ILogger
    {
        public void Log( object obj ) => Console.WriteLine( obj );
        public void Log( params object[] objs ) => Console.WriteLine( objs );
    }
}
