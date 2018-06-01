using System;
using Microsoft.Extensions.Logging;

namespace starter_app.Controllers.LogProviders.FileLog
{
    public sealed class FileLoggerProvider : ILoggerProvider
    {
        private readonly Func<string, LogLevel, bool> _func;

        public FileLoggerProvider(Func<string, LogLevel, bool> func)
        {
            this._func = func;
        }

        public FileLoggerProvider(LogLevel minimumLogLevel) : 
            this((category, logLevel) => logLevel >= minimumLogLevel)
        {
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(categoryName, this._func);
        }

        public void Dispose()
        {
        }
    }
}