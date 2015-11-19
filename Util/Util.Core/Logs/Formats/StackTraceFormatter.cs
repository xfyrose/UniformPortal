namespace Util.Core.Logs.Formats
{
    internal class StackTraceFormatter : FormatterBase
    {
        /// <summary>
        /// 初始化堆栈跟踪格式器
        /// </summary>
        /// <param name="message">日志消息</param>
        public StackTraceFormatter(LogMessage message)
            : base(message)
        {
        }

        /// <summary>
        /// 格式化
        /// </summary>
        public override string Format()
        {
            if (string.IsNullOrWhiteSpace(Message.StackTrace))
                return string.Empty;
            Add("堆栈跟踪:\n");
            Add(Message.StackTrace);

            return base.Format();
        }
    }
}