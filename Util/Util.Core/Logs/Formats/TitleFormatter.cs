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
            Add(Util.Resources.LogMessage.Level, Message.Level);
        }

        private void AddTraceId()
        {
            Add($"{Util.Resources.LogMessage.TraceId}：{0}", Message.TraceId);
        }

        private void AddTime()
        {
            Add($"{Util.Resources.LogMessage.Time}：{0}", Message.Time);
        }

        private void AddTotalSeconds()
        {
            Add($"{Util.Resources.LogMessage.TotalSeconds}：{0}", Message.TotalSeconds);
        }
    }
}