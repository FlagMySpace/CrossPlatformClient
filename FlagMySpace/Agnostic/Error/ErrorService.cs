using System;

namespace Agnostic.Error
{
    public class ErrorService : IErrorService
    {
        private Exception _capturedException;

        public async void CaptureError(Exception exception)
        {
            _capturedException = exception;
            _capturedException = null;
        }
    }
}