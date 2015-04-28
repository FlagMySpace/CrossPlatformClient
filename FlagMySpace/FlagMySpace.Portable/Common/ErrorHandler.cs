using System;
using System.Runtime.ExceptionServices;

namespace FlagMySpace.Portable.Common
{
    public interface IErrorNotifiable
    {
        void ErrorNotify(Exception exception);
    }

    public interface IError
    {
        void CaptureError(Exception ex, IErrorNotifiable errorNotifiable);
    }

    public class ErrorHandler : IError
    {
        private ExceptionDispatchInfo _capturedException;

        public void CaptureError(Exception ex, IErrorNotifiable errorNotifiable)
        {
            _capturedException = ExceptionDispatchInfo.Capture(ex);

            if (_capturedException != null)
            {
                errorNotifiable.ErrorNotify(_capturedException.SourceException);
                _capturedException = null;
            }
        }
    }
}