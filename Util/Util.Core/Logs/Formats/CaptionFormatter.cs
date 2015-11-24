using System;

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
            Add(Util.Resources.LogMessage.Caption, Message.Caption);

            return base.Format();
        }
    }
}