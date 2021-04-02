using System;
using System.Runtime.Serialization;

namespace Reflector.Exceptions
{
    [Serializable]
    public class InvalidInvocationException : Exception
    {
        public InvalidInvocationException()
        {
        }

        public InvalidInvocationException(string message) : base(message)
        {
        }

        public InvalidInvocationException(string message, Exception inner) : base(message, inner)
        {
        }

        protected InvalidInvocationException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}