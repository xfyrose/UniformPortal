using System;

namespace Util.Core.Logs
{
    public interface ILog
    {
        string TraceId { get; set; }

        string BusinessId { get; set; }

        string Application { get; set; }

        string Tenant { get; set; }

        string Category { get; set; }

        string Class { get; set; }

        string Method { get; set; }

        Str Params { get; set; }

        Str Caption { get; set; }

        Str Content { get; set; }

        Str Sql { get; set; }

        Str SqlParams { get; set; }

        string ErrorCode { get; set; }

        Exception Exception { get; set; }

        void Debug();
        void Info();
        void Warn();
        void Error();
        void Fatal();

        void Start();
    }
}