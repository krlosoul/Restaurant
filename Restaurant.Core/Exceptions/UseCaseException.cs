namespace Restaurant.Core.Exceptions
{
    using System;

    public class UseCaseException : Exception
    {
        public UseCaseException() { }

        public UseCaseException(string message, Exception ex) : base($"UseCase: {message}", ex) { }
    }
}
