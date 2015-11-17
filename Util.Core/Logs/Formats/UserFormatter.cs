using System;
using Util.Resources;

namespace Util.Core.Logs.Formats
{
    internal class UserFormatter : FormatterBase
    {
        public UserFormatter(LogMessage message)
            : base(message)
        {
            
        }

        public override string Format()
        {
            Add(CommonLog.LogFormatUserId, Message.UserId);
            Add(CommonLog.LogFormatOperator, Message.Operator);
            Add(CommonLog.LogFormatRole, Message.Role);

            return Result.ToString();
        }
    }
}