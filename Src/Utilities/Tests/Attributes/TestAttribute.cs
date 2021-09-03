using System;

namespace CXUtils.Utilities.Tests
{
    /// <summary>
    ///     An attribute for quick testing purposes
    /// </summary>
    [AttributeUsage( AttributeTargets.Method )]
    public class TestAttribute : Attribute
    {
    }
}
