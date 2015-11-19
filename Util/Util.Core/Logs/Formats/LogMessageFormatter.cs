namespace Util.Core.Logs.Formats
{
    internal class LogMessageFormatter : FormatterBase
    {
        public LogMessageFormatter(LogMessage message) 
            : base(message)
        {
            Line = 1;
        }

        private int Line { get; set; }

        public override string Format()
        {
            Add(new TitleFormatter(Message));
            Add(new UrlFormatter(Message));
            Add(new BusinessFormatter(Message));
            Add(new ClassFormatter(Message));
            Add(new IpFormatter(Message));
            Add(new UserFormatter(Message));
            Add(new CaptionFormatter(Message));
            Add(new ContentFormatter(Message));
            Add(new SqlFormatter(Message));
            Add(new SqlParamsFormatter(Message));
            Add(new ErrorFormatter(Message));
            Add(new StackTraceFormatter(Message));

            Finish();

            return base.Format();
        }

        private void Add(FormatterBase formatter)
        {
            string result = formatter.Format();
            if (string.IsNullOrWhiteSpace(result))
            {
                return;
            }

            Result.AddLine("{0}. {1}", Line++, result);
        }

        private void Finish()
        {
            Result.Add(new string('-', 125));
            //Result.AddLine(string.Empty.PadLeft(125, '-'));
            //for (int i = 0; i < 125; i++)
            //{
            //    Result.Add("-");
            //}

            Result.AddLine();
        }
    }
}