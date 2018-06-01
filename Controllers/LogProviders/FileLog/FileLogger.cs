using System;
using System.IO;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Internal;

namespace starter_app.Controllers.LogProviders.FileLog
{
    public class FileLogger : ILogger
    {
        private readonly string _categoryName;
        private readonly Func<string, LogLevel, bool> _func;

        public FileLogger(string categoryName, Func<string, LogLevel, bool> func)
        {
            this._categoryName = categoryName;
            this._func = func;
        }

        public IDisposable BeginScope<TState>(TState state) => new EmptyDisposable();

        public bool IsEnabled(LogLevel logLevel)
        {
            return this._func(this._categoryName, logLevel);
        }

        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception exception,
            Func<TState, Exception, string> formatter)
        {
            if (this.IsEnabled(logLevel) == true)
            {
                var now = DateTime.UtcNow;
                var today = now.ToString("yyyy-MM-dd");
                var fileName = $"{this._categoryName}_{today}.log";

                var sb = new StringBuilder();
                var formattedValues = state as FormattedLogValues;
                if (formattedValues != null)
                {
                    foreach (var item in formattedValues)
                    {
                        sb.AppendLine($"{item.Key}: {item.Value}");
                    }
                }
                //var message = formatter(state, exception);

                //File.AppendAllText(fileName, $"{message}\n");
                File.AppendAllText(fileName, $"{sb.ToString()}\n");
            }
        }
    }
}