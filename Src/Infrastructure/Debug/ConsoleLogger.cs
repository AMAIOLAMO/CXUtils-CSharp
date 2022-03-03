using System;

namespace CXUtils.Debugging
{
	/// <summary>
	///     Basic console logger class
	/// </summary>
	public class ConsoleLogger : ILogger
	{
		public void Log(string message) => Console.WriteLine(message);

		public void Log(int value) => Console.WriteLine(value);
		public void Log(long value) => Console.WriteLine(value);
		public void Log(char value) => Console.WriteLine(value);
		public void Log(bool value) => Console.WriteLine(value);
		public void Log(float value) => Console.WriteLine(value);
		public void Log(double value) => Console.WriteLine(value);
		public void Log(decimal value) => Console.WriteLine(value);
		public void Log(object item) => Console.WriteLine(item);
	}
}
