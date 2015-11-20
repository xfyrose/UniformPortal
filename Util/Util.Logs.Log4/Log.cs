using System;
using System.Diagnostics;
using System.Globalization;
using System.Web;
using Util.Core;
using Util.Core.Logs;
using Util.Security;

namespace Util.Logs.Log4
{
    public class Log : ILog
    {
        private readonly log4net.ILog _log;

        private Log(log4net.ILog log)
        {
            _log = log;

            TraceId = Guid.NewGuid().ToString();
            Params = new Str();
            Caption = new Str();
            Content = new Str();
            Sql = new Str();
            SqlParams = new Str();
            BusinessId = string.Empty;
            Application = string.Empty;
            Tenant = string.Empty;
            Category = string.Empty;
            Class = string.Empty;
            Method = string.Empty;
            ErrorMessage = string.Empty;
            StackTrace = string.Empty;
        }

        public static ILog GetLog()
        {
            return new Log(log4net.LogManager.GetLogger(string.Empty));
        }

        public static ILog GetLog<T>()
        {
            return GetLog(typeof(T));
        }

        public static ILog GetLog(string className)
        {
            return new Log(log4net.LogManager.GetLogger(className));
        }

        public static ILog GetLog(Type type)
        {
            return new Log(log4net.LogManager.GetLogger(type))
            {
                Class = type.ToString()
            };
        }

        public static ILog GetLog(object instance)
        {
            if (instance == null)
            {
                return GetLog();
            }

            return GetLog(instance.GetType());
        }

        public static ILog GetContextLog()
        {
            return GetContextLog(GetLog);
        }

        public static ILog GetContextLog(Type type)
        {
            ILog log = GetContextLog(() => GetLog(type));
            log.Class = type.ToString();

            return log;
        }

        private static ILog GetContextLog(Func<ILog> handler)
        {
            string key = Config.GetLogContextKey();

            ILog log = Context.Get<ILog>(key);
            if (log != null)
            {
                return log;
            }

            log = handler();
            Context.Add(key, log);
            return log;
        }

        public static ILog GetContextLog(string className)
        {
            ILog log = GetContextLog(() => GetLog(className));
            log.Class = className;

            return log;
        }

        public static ILog GetContextLog(object instance)
        {
            if (instance == null)
            {
                return GetLog();
            }

            return GetContextLog(instance.GetType());
        }

        private Test _test;

        private LogLevel Level { get; set; }

        private Identity Identity { get; set; }

        private string ErrorMessage { get; set; }

        private string StackTrace { get; set; }

        public string TraceId { get; set; }
        public string BusinessId { get; set; }
        public string Application { get; set; }
        public string Tenant { get; set; }
        public string Category { get; set; }
        public string Class { get; set; }
        public string Method { get; set; }
        public Str Params { get; set; }
        public Str Caption { get; set; }
        public Str Content { get; set; }
        public Str Sql { get; set; }
        public Str SqlParams { get; set; }
        public string ErrorCode { get; set; }
        public Exception Exception { get; set; }

        public void Debug()
        {
            Execute(() =>
            {
                Level = LogLevel.Debug;
                _log.Debug(GetMessage());
            });
        }

        private void Execute(Action action)
        {
            action();
            Clear();
        }

        private LogMessage GetMessage()
        {
            InitException();
            return CreateMessage();
        }

        private void InitException()
        {
            if (Exception == null)
            {
                return;
            }

            Warning warning = new Warning(Exception);
            ErrorMessage = warning.Message;
            StackTrace = warning.StackTrace;
        }

        private LogMessage CreateMessage()
        {
            return new LogMessage()
            {
                Level = Level.Description(),
                TraceId = TraceId,
                Time = DateTime.Now.ToMillisecondString(),
                TotalSeconds = GetTotalSeconds(),
                Url = GetUrl(),
                BusinessId = BusinessId,
                Application = GetApplication(),
            };
        }

        private string GetTotalSeconds()
        {
            if (_test == null)
            {
                return string.Empty;
            }

            return _test.GetElapsed().ToString();
        }

        private string GetUrl()
        {
            if (HttpContext.Current == null)
            {
                return string.Empty;
            }

            try
            {
                return HttpContext.Current.Request.Url.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }

        private string GetApplication()
        {
            if (Application.IsEmpty())
            {
                return GetIdentity().Application;
            }

            return Application;
        }

        private Identity GetIdentity()
        {
            if (Identity != null)
            {
                return Identity;
            }

            Identity = SecurityContext.Identity;

            return Identity;
        }

        private void Clear()
        {
            BusinessId = string.Empty;
            Method = string.Empty;
            Params.Clear();
            Caption.Clear();
            Content.Clear();
            Sql.Clear();
            SqlParams.Clear();
            Exception = null;
            ErrorMessage = string.Empty;
            StackTrace = string.Empty;
        }

        public void Info()
        {
            Execute(() =>
            {
                Level = LogLevel.Information;
                _log.Info(GetMessage());
            });
        }

        public void Warn()
        {
            Execute(() =>
            {
                Level = LogLevel.Warning;
                _log.Info(GetMessage());
            });
        }

        public void Error()
        {
            Execute(() =>
            {
                Level = LogLevel.Error;
                _log.Info(GetMessage());
            });
        }

        public void Fatal()
        {
            Execute(() =>
            {
                Level = LogLevel.Fatal;
                _log.Info(GetMessage());
            });
        }

        public void Start()
        {
            _test = new Test();
            _test.Start();
        }
    }
}