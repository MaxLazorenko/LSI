using System;
using System.Collections.Generic;
using System.Text;

namespace LSI.Domain.Responses
{
    public abstract class ResultBase
    {
        public bool Succeeded { get; }
        public Error Error;
        protected internal ResultBase(bool succeeded, Error error)
        {
            Succeeded = succeeded;
            Error = error;
        }
    }
    public class Result : ResultBase
    {
        public Result(bool succeeded, Error error) : base(succeeded, error)
        {
        }
        public static Result Ok() => new Result(true, default(Error));
        public static Result<T> Ok<T>(T value) => new Result<T>(value, true, default(Error));
        public static Result Failure(string message) => new Result(false, new Error(message));
        public static Result Failure(ErrorType errorType, string message) => new Result(false, new Error(errorType, message));
    }

    public class Result<T> : ResultBase
    {
        private readonly T _value;
        public T Value
        {
            get
            {
                if (!Succeeded) throw new InvalidOperationException("Cannot access the value of a failed result");
                return _value;
            }
        }
        public T ValueOrDefault => _value;
        protected internal Result(T value, bool succeeded, Error error) : base(succeeded, error)
        {
            _value = value;
        }
        public static implicit operator Result<T>(Result result)
        {
            if (result.Succeeded) throw new ArgumentException("Cannot convert a non-generic successful result to a generic one. The value would be null!", nameof(result));

            return new Result<T>(default(T), false, result.Error);
        }
        public static implicit operator Result(Result<T> result)
        {
            return new Result(result.Succeeded, result.Error);
        }
    }
}
