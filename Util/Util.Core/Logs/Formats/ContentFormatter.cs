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

            Add(CommonLog.LogFormatContent);
            Add(Message.Content);

            return base.Format();
        }
    }
}