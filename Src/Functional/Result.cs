using System;

namespace CXUtils.Functional
{
	public readonly struct Result<T> : IResult<T, Exception>
	{
		public Result(T resultValue)
		{
			_resultValue = resultValue;
			_exception = null;
		}

		public Result(Exception exception)
		{
			_resultValue = default;
			_exception = exception;
		}

		public bool Success(out T resultValue)
		{
			resultValue = _resultValue;

			return Successful;
		}

		public bool Failure(out Exception exception)
		{
			exception = _exception;

			return !Successful;
		}

		public void Match(Action<T> successAction, Action<Exception> failureAction)
		{
			if (Successful)
			{
				failureAction(_exception);

				return;
			}
			// else

			successAction(_resultValue);
		}

		public static implicit operator Result<T>(Exception exception) => new(exception);

		readonly T _resultValue;

		readonly Exception _exception;

		bool Successful => _exception != null;
	}
}
