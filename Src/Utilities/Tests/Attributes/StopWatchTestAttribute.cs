using System;

namespace CXUtils.Utilities.Tests
{
    /// <summary>
    ///     An attribute for quick Stopwatch testing purposes
    /// </summary>
    [AttributeUsage( AttributeTargets.Method )]
    public class StopWatchTestAttribute : Attribute
    {
    }
}
