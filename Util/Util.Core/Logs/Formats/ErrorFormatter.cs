namespace Util.Core.Logs.Formats
{
    internal class ErrorFormatter : FormatterBase
    {
        /// <summary>
        /// 初始化错误格式器
        /// </summary>
        /// <param name="message">日志消息</param>
        public ErrorFormatter(LogMessage message)
            : base(message)
        {
        }

        /// <summary>
        /// 格式化
        /// </summary>
        public override string Format()
        {
            AddErrorCode();
            AddError();
            return Result.ToString();
        }

        /// <summary>
        /// 添加错误码
        /// </summary>
        private void AddErrorCode()
        {
            if (string.IsNullOrWhiteSpace(Message.ErrorCode) && string.IsNullOrWhiteSpace(Message.Error) == false)
            {
                Add("错误:\n");
                return;
            }
            if (!string.IsNullOrWhiteSpace(Message.ErrorCode))
                Add("错误码:{0}\n", Message.ErrorCode);
        }

        /// <summary>
        /// 添加错误消息
        /// </summary>
        private void AddError()
        {
            if (string.IsNullOrWhiteSpace(Message.Error))
                return;
            Add(Message.Error);
        }
    }
}