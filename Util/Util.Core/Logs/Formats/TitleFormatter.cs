using Util.Resources;

namespace Util.Core.Logs.Formats
{
    internal class TitleFormatter : FormatterBase
    {
        public TitleFormatter(LogMessage message)
            : base(message)
        {
        }

        public override string Format()
        {
            AddLevel();
            AddTraceId();
            AddTime();
            AddTotalSeconds();

            return base.Format();
        }

        private void AddLevel()
        {
            Add(CommonLog.LogFormatLogLevel, Message.Level);
        }

        private void AddTraceId()
        {
            Add($"{CommonLog.LogFormatTraceId}：{0}", Message.TraceId);
        }

        private void AddTime()
        {
            Add($"{CommonLog.LogFormatTime}：{0}", Message.Time);
        }

        private void AddTotalSeconds()
        {
            Add($"{CommonLog.LogFormatTotalSeconds}：{0}", Message.TotalSeconds);
        }
    }
}