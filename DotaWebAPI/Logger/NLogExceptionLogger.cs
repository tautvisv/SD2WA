using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http.ExceptionHandling;
using NLog;

namespace Logger
{

    public class NLogExceptionLogger : ExceptionLogger
    {
        private static readonly NLog.Logger Nlog = LogManager.GetCurrentClassLogger();
        public override void Log(ExceptionLoggerContext context)
        {
            var stringBuilder = new LoggerStringBuilder
            {
                Arguments = context.RequestContext.RouteData.Values,
                ExceptionMessage = context.Exception.Message,
                Method = context.Request.Method.ToString(),
                StackTrace = context.Exception.StackTrace,
                Source = context.Exception.Source,
                Body = null,
                URL = context.Request.RequestUri.ToString(),
            };
            var message = stringBuilder.CreateString();
            Nlog.Log(LogLevel.Error, message);
        }

        private static string RequestToString(HttpRequestMessage request)
        {
            var message = new StringBuilder();
            if (request.Method != null)
                message.Append(request.Method);

            if (request.RequestUri != null)
                message.Append(" ").Append(request.RequestUri);

            return message.ToString();
        }
        private class LoggerStringBuilder
        {
            public string Source { get; set; }
            public IDictionary<string,object> Arguments { get; set; }
            public string ExceptionMessage { get; set; }
            public string URL { get; set; }
            public string Method { get; set; }
            public object Body { get; set; }
            public string StackTrace { get; set; }
            public string CreateString()
            {
                return string.Format(" Location: {4} | {0} URL: {1} | Arguments: {2} | Body: {3} | {5}", Method, URL, CreateArguments(), CreateFromBody(), Source, StackTrace);
            }

            private string CreateArguments()
            {
                var returnValue = "";
                if (Arguments == null) return returnValue;
                returnValue = Arguments.Aggregate(returnValue, (current, argument) => current + (" " + argument.Key + ": " + argument.Value));
                return string.Format("{{{0}}}",returnValue);
            }
            private string CreateFromBody()
            {
                return Body == null ? "{}" : Body.ToString();
            }
        }
    }
}
