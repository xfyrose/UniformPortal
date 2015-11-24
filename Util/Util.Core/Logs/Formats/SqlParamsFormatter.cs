using System;
using Util.Resources;

namespace Util.Core.Logs.Formats
{
    internal class SqlParamsFormatter : FormatterBase
    {
        public SqlParamsFormatter(LogMessage message)
            : base(message)
        {
            
        }

        public override string Format()
        {
            if (string.IsNullOrWhiteSpace(Message.SqlParams))
            {
                return string.Empty;
            }

            Add($"{Util.Resources.LogMessage.SqlParams}：");
            Add(Message.SqlParams);

            return base.Format();
        }
    }
}