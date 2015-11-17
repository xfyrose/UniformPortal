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

            Result.AddLine($"{CommonLog.LogFormatSqlParams}：");
            Result.Add(Message.SqlParams);

            return Result.ToString();
        }
    }
}