using System;
using FlagMySpace.Agnostic.EventAggregator;

namespace FlagMySpace.Agnostic.Error
{
    public class ErrorService : IErrorService
    {
        private readonly IEventAggregator _eventAggregator;
        private Exception _capturedException;

        public ErrorService(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public async void CaptureError(Exception exception)
        {
            _capturedException = exception;

            if (_capturedException != null)
            {
                _eventAggregator.Publish(_capturedException);
                _capturedException = null;
            }
        }
    }
}