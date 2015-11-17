using System;
using Util.Resources;

namespace Util.Core.Logs.Formats
{
    internal class ContentFormatter : FormatterBase
    {
        public ContentFormatter(LogMessage message)
            : base(message)
        {
            
        }

        public override string Format()
        {
            if (string.IsNullOrWhiteSpace(Message.Content))
            {
                return string.Empty;
            }

            Result.AddLine(CommonLog.LogFormatContent);
            Result.AddLine(Message.Content);

            return Result.ToString();
        }
    }
}