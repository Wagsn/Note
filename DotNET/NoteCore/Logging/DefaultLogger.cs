﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace NoteCore.Logging
{
    public class DefaultLogger<CategoryName> : Microsoft.Extensions.Logging.ILogger<CategoryName>
    {

        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            throw new NotImplementedException();
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            throw new NotImplementedException();
        }
    }
}
