using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebApplication1
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly FileLogger _fileLogger;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;

            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
            string fileName = "requests_log.txt";
            _fileLogger = new FileLogger(folderPath, fileName);
        }

        public async Task Invoke(HttpContext context)
        {
            var request = context.Request;
            var logMessage = $"";

            var queryString = request.QueryString.Value.TrimStart('?');
            NameValueCollection queryParams = HttpUtility.ParseQueryString(queryString);

            foreach (string key in queryParams.AllKeys)
            {
                string value = queryParams[key];
                string tidyString = $"{key} = {value}\n";
                logMessage += tidyString ;
            }

            await _fileLogger.LogAsync(logMessage);

            await _next(context);
        }
    }
    public static class RequestLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLoggingMiddleware>();
        }
    }
}
