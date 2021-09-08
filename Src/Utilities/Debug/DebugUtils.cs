namespace CXUtils.Debugging
{
    public static class DebugUtils
    {
        static        ConsoleLogger _consoleLogger;
        public static ConsoleLogger ConsoleLogger => _consoleLogger ??= new ConsoleLogger();
    }
}
