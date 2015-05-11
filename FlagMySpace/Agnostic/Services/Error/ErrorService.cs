using System;
using System.Threading.Tasks;
using FlagMySpace.Agnostic.EventAggregator;

namespace FlagMySpace.Agnostic.Services.Error
{
    public class ErrorService : IErrorService
    {
        private readonly IEventAggregator _eventAggregator;
        private Exception _capturedException;

        public ErrorService(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public Task CaptureErrorAsync(Exception exception)
        {
            _capturedException = exception;

            if (_capturedException != null)
            {
                _eventAggregator.Publish(_capturedException);
                _capturedException = null;
            }

            return Task.FromResult<object>(null);
        }
    }
}