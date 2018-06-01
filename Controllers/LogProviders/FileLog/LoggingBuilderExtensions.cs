using System;
using Microsoft.Extensions.Logging;

namespace starter_app.Controllers.LogProviders.FileLog
{
    public static class LoggingBuilderExtensions
    {
        public static ILoggingBuilder AddFile(
            this ILoggingBuilder loggerFactory,
            Func<string, LogLevel, bool> func)
        {
            loggerFactory.AddProvider(new FileLoggerProvider(func));
            return loggerFactory;
        }

        public static ILoggingBuilder AddFile(
          this ILoggingBuilder loggerFactory,
          LogLevel minimumLogLevel)
        {
            return AddFile(loggerFactory, (category, logLevel) => logLevel >= minimumLogLevel);
        }
    }
}