using System;
using System.Diagnostics;
using CXUtils.Common;

namespace CXUtils.Debugging
{
	/// <summary>
	///     A utility class for assertions
	/// </summary>
	public static class Assertion
	{
		const string CONDITIONAL_DEBUG = "DEBUG";

		[Conditional(CONDITIONAL_DEBUG)]
		public static void When(bool condition, string message)
		{
			if (condition) return;

			throw new Exception(message);
		}

		[Conditional(CONDITIONAL_DEBUG)]
		public static void When(bool condition)
		{
			if (condition) return;

			throw new Exception();
		}
		
		[Conditional(CONDITIONAL_DEBUG)]
		public static void Error(bool condition, Exception exception)
		{
			if (condition) return;

			throw exception;
		}
		
		[Conditional(CONDITIONAL_DEBUG)]
		public static void Invalid(bool condition, string valueName, object value, InvalidReason reason) =>
			Error(condition, ExceptionUtils.Get(valueName, value, reason));

		[Conditional(CONDITIONAL_DEBUG)]
		public static void Invalid(bool condition, string valueName, InvalidReason reason) =>
			Error(condition, ExceptionUtils.Get(valueName, reason));
	}
}
