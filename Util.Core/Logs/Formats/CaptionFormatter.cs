using System;
using Util.Resources;

namespace Util.Core.Logs.Formats
{
    internal class CaptionFormatter : FormatterBase
    {
        public CaptionFormatter(LogMessage message)
            : base(message)
        {
            
        }

        public override string Format()
        {
            Add(CommonLog.LogFormatCaption, Message.Caption);

            return Result.ToString();
        }
    }
}