using System;
using System.Threading.Tasks;

namespace FlagMySpace.Agnostic.Services.Error
{
    public interface IErrorService
    {
        Task CaptureErrorAsync(Exception exception);
    }
}