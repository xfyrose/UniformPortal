using System;
using Util.Core.Logs;

namespace Util.Core.Exceptions
{
    public class ConcurrencyException : Warning
    {
        public ConcurrencyException(string message, Exception exception, string code, LogLevel level)
            : base(message, code, level, exception)
        {
            
        }

        public ConcurrencyException(string message, Exception exception, string code)
            : this(message, exception, code, LogLevel.Warning)
        {
            
        }

        public ConcurrencyException(string message, Exception exception)
            : this(message, exception, string.Empty)
        {
            
        }

        public ConcurrencyException(Exception exception)
            : this(string.Empty, exception)
        {
            
        }

        public ConcurrencyException()
            : this(null)
        {
            
        }
    }
}