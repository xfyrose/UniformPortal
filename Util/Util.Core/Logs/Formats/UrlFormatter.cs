using System;
using Util.Resources;

namespace Util.Core.Logs.Formats
{
    internal class UrlFormatter : FormatterBase
    {
        public UrlFormatter(LogMessage message)
            : base(message)
        {
            
        }

        public override string Format()
        {
            AddUrl();

            return base.Format();
        }

        private void AddUrl()
        {
            if (string.IsNullOrWhiteSpace(Message.Url))
            {
                return;
            }

            Add($"{CommonLog.LogFormatUrl}：{0}", Message.Url);
        }
    }
}