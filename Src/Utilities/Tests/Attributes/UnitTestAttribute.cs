using System;

namespace CXUtils.Utilities.Tests
{
    /// <summary>
    ///     An attribute for unit testing
    /// </summary>
    [AttributeUsage( AttributeTargets.Method )]
    public sealed class UnitTestAttribute : Attribute
    {
    }
}