namespace Util.Core.Logs.Formats
{
    internal abstract class FormatterBase
    {
        protected FormatterBase(LogMessage message)
        {
            Message = message;
            Result = new Str();
        }

        public LogMessage Message { get; set; }

        public Str Result { get; set; }

        public abstract string Format();

        protected void Add(string key, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            Result.Add("{0}:{1}", key, value);
        }
    }
}