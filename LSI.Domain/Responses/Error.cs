namespace LSI.Domain.Responses
{
    public class Error
    {
        public ErrorType Type;
        public string Message;

        public Error(ErrorType errorType, string message)
        {
            Type = errorType;
            Message = message;
        }

        public Error(string message) : this(ErrorType.GENERIC, message)
        {

        }
    }
}