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
            Add(Util.Resources.LogMessage.UserId, Message.UserId);
            Add(Util.Resources.LogMessage.Operator, Message.Operator);
            Add(Util.Resources.LogMessage.Role, Message.Role);

            return base.Format();
        }
    }
}