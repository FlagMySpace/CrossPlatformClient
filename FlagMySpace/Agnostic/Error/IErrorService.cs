using System;

namespace Agnostic.Error
{
    public interface IErrorService
    {
        void CaptureError(Exception exception);
    }
}