using System;

namespace Util.Core.Logs.Formats
{
    internal class ClassFormatter : FormatterBase
    {
        public ClassFormatter(LogMessage message)
            : base(message)
        {
            
        }

        public override string Format()
        {
            Add(Util.Resources.LogMessage.Class, Message.Class);
            Add(Util.Resources.LogMessage.Method, Message.Method);
            AddParams();

            return base.Format();
        }

        private void AddParams()
        {
            if (string.IsNullOrWhiteSpace(Message.Params))
            {
                return;
            }

            Add($"{Util.Resources.LogMessage.Params}:");
            Result.Add(Message.Params);
        }
    }
}