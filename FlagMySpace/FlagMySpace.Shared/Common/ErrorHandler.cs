using System;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlagMySpace.Common
{
    public interface IError
    {
        void CaptureError(Exception ex);
    }

    public class ErrorHandler : IError
    {
        private ExceptionDispatchInfo _capturedException;

        public void CaptureError(Exception ex)
        {
            _capturedException = ExceptionDispatchInfo.Capture(ex);

            if (_capturedException != null)
            {
                MessagingCenter.Send(this, "error", _capturedException);
                _capturedException = null;
            }
        }
    }
}