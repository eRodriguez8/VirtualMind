using System;

namespace VirtualMind.TechnicalEvaluation.Biz.Exceptions
{
    public class ConflictException : ApplicationException
    {
        public ConflictException()
        {
        }

        public ConflictException(string message) : base(message)
            {
        }

        public ConflictException(string message, Exception innerException) : base(message, innerException)
            {
        }
    }
}