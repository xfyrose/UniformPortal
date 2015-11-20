using Util.Core.Logs.Formats;

namespace Util.Core.Logs
{
    public class LogMessage
    {
        public string Level { get; set; } 
        public string TraceId { get; set; }
        public string Time { get; set; }
        public string TotalSeconds { get; set; }
        public string Url { get; set; }
        public string BusinessId { get; set; }
        public string Application { get; set; }
        public string Tenant { get; set; }
        public string Category { get; set; }
        public string Class { get; set; }
        public string Method { get; set; }
        public string Params { get; set; }
        public string Ip { get; set; }
        public string Host { get; set; }
        public string ThreadId { get; set; }
        public string UserId { get; set; }
        public string Operator { get; set; }
        public string Role { get; set; }
        public string Caption { get; set; }
        public string Content { get; set; }
        public string Sql { get; set; }
        public string SqlParams { get; set; }
        public string ErrorCode { get; set; }
        public string Error { get; set; }
        public string StackTrace { get; set; }

        public override string ToString()
        {
            return new LogMessageFormatter(this).Format();
        }
    }
}