namespace CXUtils.Debugging
{
    /// <summary>
    ///     Implements a logger
    /// </summary>
    public interface ILogger
	{
		void Log(string message);
		void Log(int value);
		void Log(long value);
		void Log(char value);
		void Log(bool value);
		void Log(float value);
		void Log(double value);
		void Log(decimal value);
		
		void Log(object item);
    }
}
