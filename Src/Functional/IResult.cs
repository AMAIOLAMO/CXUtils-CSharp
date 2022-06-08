using System;

namespace CXUtils.Functional
{
	public interface IResult<TSuccess, TFailure>
	{
		/// <summary>
		///     Matches the result and calls actions
		/// </summary>
		void Match(Action<TSuccess> successAction, Action<TFailure> failureAction);

		bool Success(out TSuccess resultValue);
		bool Failure(out TFailure failureValue);
	}
}
