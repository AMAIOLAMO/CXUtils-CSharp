namespace CXUtils.Debugging
{
	public static class DebugUtils
	{
		static ConsoleLogger consoleLogger;

		public static ConsoleLogger ConsoleLogger => consoleLogger ??= new ConsoleLogger();
	}
}
