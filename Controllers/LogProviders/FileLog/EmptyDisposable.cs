using System;

namespace starter_app.Controllers.LogProviders.FileLog
{
    public class EmptyDisposable : IDisposable
    {
        public void Dispose() { }
    }
}