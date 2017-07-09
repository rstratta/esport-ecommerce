using System;

namespace ESport.Data.Commons
{
    public class OperationException : Exception
    {
        public OperationException(string message, Exception e) : base(message,e) { }

        public OperationException(string message) : base(message) { }
    }
}
