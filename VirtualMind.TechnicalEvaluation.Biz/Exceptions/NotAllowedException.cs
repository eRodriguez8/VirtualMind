using System;

namespace VirtualMind.TechnicalEvaluation.Biz.Exceptions
{
    [Serializable]
    public class NotAllowedException : Exception
    {
        public NotAllowedException()
        {
        }

        public NotAllowedException(string message) : base(message)
        {
        }

        public NotAllowedException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}