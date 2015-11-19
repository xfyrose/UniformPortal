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
            if (string.IsNullOrWhiteSpace(Message.Sql))
                return string.Empty;

            Add("Sql语句:");
            Add(Message.Sql);

            return base.ToString();
        }
    }
}