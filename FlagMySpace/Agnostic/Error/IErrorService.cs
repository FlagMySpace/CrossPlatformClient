using System;

namespace FlagMySpace.Agnostic.Error
{
    public interface IErrorService
    {
        void CaptureError(Exception exception);
    }
}