﻿using Util.Resources;

namespace Util.Core.Logs.Formats
{
    internal class TitleFormatter : FormatterBase
    {
        public TitleFormatter(LogMessage message)
            : base(message)
        {
            Message = message;
            Result = new Str();
        }

        public override string Format()
        {
            AddLevel();
            AddTraceId();
            AddTime();
            AddTotalSeconds();

            return Result.ToString();
        }

        private void AddLevel()
        {
            Result.Add(CommonLog.LogFormatLogLevel, Message.Level);
        }

        private void AddTraceId()
        {
            Result.Add(CommonLog.LogFormatTraceId, Message.TraceId);
        }

        private void AddTime()
        {
            Result.Add(CommonLog.LogFormatTime, Message.Time);
        }

        private void AddTotalSeconds()
        {
            Result.Add(CommonLog.LogFormatTotalSeconds, Message.TotalSeconds);
        }
    }
}