using System;

namespace Util.Core.Logs.Formats
{
    internal class IpFormatter : FormatterBase
    {
        public IpFormatter(LogMessage message)
            : base(message)
        {
            
        }

        public override string Format()
        {
            Add(Util.Resources.LogMessage.Ip, Message.Ip);
            Add(Util.Resources.LogMessage.Host, Message.Host);
            Add(Util.Resources.LogMessage.ThreadId, Message.ThreadId);

            return base.Format();
        }
    }
}