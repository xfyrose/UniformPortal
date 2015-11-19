namespace Util.Core.Logs.Formats
{
    internal abstract class FormatterBase
    {
        protected FormatterBase(LogMessage message)
        {
            Message = message;
        }

        public LogMessage Message { get; set; }

        public Str Result { get; set; } = new Str();

        public virtual string Format()
        {
            return Result.ToString();
        }

        public void Add(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            Result.Add(value);
        }

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