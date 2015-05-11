using System;
using System.Threading.Tasks;

namespace FlagMySpace.Agnostic.Services.ErrorService
{
    public interface IErrorService
    {
        Task CaptureErrorAsync(Exception exception);
    }
}