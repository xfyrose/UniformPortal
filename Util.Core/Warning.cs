using System;
using System.Collections;
using System.Linq;
using System.Text;

using Util.Core.Logs;

namespace Util.Core
{
    public class Warning : Exception
    {
        public Warning(string message)
            : this(message, "")
        {
        }

        public Warning(string message, string code)
            : this(message, code, LogLevel.Warning)
        {
        }

        public Warning(string message, string code, LogLevel level)
            : this(message, code, level, null)
        {
        }

        public Warning(Exception exception)
            : this(string.Empty, string.Empty, LogLevel.Warning, exception)
        {
        }

        public Warning(string message, string code, Exception exception)
            : this(message, code, LogLevel.Warning, exception)
        {
        }

        public Warning(string message, string code, LogLevel level, Exception exception)
            : base(message ?? string.Empty, exception)
        {
            Code = code;
            Level = level;
            _message = GetMessage();
        }

        private string GetMessage()
        {
            StringBuilder result = new StringBuilder();
            AppendSelfMessage(result);
            AppendInnerMessage(result, InnerException);
            return result.ToString().TrimEnd(Environment.NewLine.ToArray());
        }

        private void AppendSelfMessage(StringBuilder result)
        {
            if (string.IsNullOrWhiteSpace(base.Message))
            {
                return;
            }

            result.AppendLine(base.Message);
        }

        private void AppendInnerMessage(StringBuilder result, Exception exception)
        {
            if (exception == null)
            {
                return;
            }

            if (exception is Warning)
            {
                result.AppendLine(exception.Message);
            }

            result.AppendLine(exception.Message);
            result.Append(GetData(exception));

            AppendInnerMessage(result, exception.InnerException);
        }

        private string GetData(Exception exception)
        {
            StringBuilder result = new StringBuilder();

            foreach (DictionaryEntry data in exception.Data)
            {
                result.AppendFormat("{0}:{1}{2}", data.Key, data.Value, Environment.NewLine);
            }

            return result.ToString();
        }

        private readonly string _message;

        public override string Message
        {
            get
            {
                if (Data.Count == 0)
                {
                    return _message;
                }

                return $"{_message}{Environment.NewLine}{GetData(this)}";
            }
        }

        public string TraceId { get; set; }

        public string Code { get; set; }

        public LogLevel Level { get; set; }

        public override string StackTrace
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(base.StackTrace))
                {
                    return base.StackTrace;
                }

                if (InnerException == null)
                {
                    return string.Empty;
                }

                return InnerException.StackTrace;
            }
        }

        public void WriteLog(ILog log)
        {
            switch (Level)
            {
                case LogLevel.Debug:
                    log.Debug();
                    break;
                case LogLevel.Information:
                    log.Info();
                    break;
                case LogLevel.Warning:
                    log.Warn();
                    break;
                case LogLevel.Error:
                    log.Error();
                    break;
                case LogLevel.Fatal:
                    log.Fatal();
                    break;

            }
        }

        public static void WriteLog(ILog log, Exception exception)
        {
            Warning excep = exception as Warning;
            if (excep == null)
            {
                log.Error();
                return;
            }

            log.TraceId = excep.TraceId;
            log.ErrorCode = excep.Code;
            excep.WriteLog(log);
        }

        public string GetPrompt()
        {
            if (Level == LogLevel.Debug)
            {
                return Util.Resources.Common.SystemBusy;
            }

            if (Level == LogLevel.Error)
            {
                return Util.Resources.Common.SystemBusy;
            }

            return Message;
        }
    }
}