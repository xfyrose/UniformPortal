using System;

namespace Util.Core.Logs.Formats
{
    internal class SqlFormatter : FormatterBase
    {
        public SqlFormatter(LogMessage message)
            : base(message)
        {
            
        }

        public override string Format()
        {
            return Result.ToString();
        }
    }
}