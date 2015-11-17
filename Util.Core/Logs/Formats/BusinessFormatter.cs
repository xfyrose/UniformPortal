using System;
using Util.Resources;

namespace Util.Core.Logs.Formats
{
    internal class BusinessFormatter : FormatterBase
    {
        public BusinessFormatter(LogMessage message)
            : base(message)
        {
            
        }

        public override string Format()
        {
            Add(CommonLog.LogFormatBusinessId, Message.BusinessId);

            return Result.ToString();
        }
    }
}