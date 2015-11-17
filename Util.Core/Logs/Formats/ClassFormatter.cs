using System;
using Util.Resources;

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
            Add(CommonLog.LogFormatClass, Message.Class);
            Add(CommonLog.LogFormatMethod, Message.Method);
            AddParams();

            return Result.ToString();
        }

        private void AddParams()
        {
            if (string.IsNullOrWhiteSpace(Message.Params))
            {
                return;
            }

            Result.AddLine(CommonLog.LogFormatParams);
            Result.Add(Message.Params);
        }
    }
}