using System;
using Util.Resources;

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
            Add(CommonLog.LogFormatIp, Message.Ip);
            Add(CommonLog.LogFormatHost, Message.Host);
            Add(CommonLog.LogFormatThreadId, Message.ThreadId);

            return base.Format();
        }
    }
}