using System;

namespace CXUtils.Functional
{
	public readonly struct Result<T> : IResult<T, Exception>
	{
		public Result(T resultValue)
		{
			_resultValue = resultValue;
			_exception = null;

			_successful = true;
		}

		public Result(Exception exception)
		{
			_resultValue = default;
			_exception = exception;

			_successful = false;
		}

		/// <summary>
		///     Matches the result and calls actions
		/// </summary>
		public void Match(Action<T> successAction, Action<Exception> failureAction)
		{
			if (_successful)
			{
				successAction(_resultValue);

				return;
			}
			// else

			failureAction(_exception);
		}

		public bool Success(out T resultValue)
		{
			resultValue = _resultValue;

			return _successful;
		}

		public bool Failure(out Exception exception)
		{
			exception = _exception;

			return !_successful;
		}

		readonly bool _successful;

		readonly T _resultValue;

		readonly Exception _exception;
	}
}
