using System;
using System.Threading.Tasks;

namespace FlagMySpace.Agnostic.Error
{
    public interface IErrorService
    {
        Task CaptureErrorAsync(Exception exception);
    }
}