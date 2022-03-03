namespace CXUtils.Debugging
{
	public static class CommonLoggers
	{
		static ConsoleLogger console;

		public static ConsoleLogger Console => console ??= new ConsoleLogger();
	}
}
