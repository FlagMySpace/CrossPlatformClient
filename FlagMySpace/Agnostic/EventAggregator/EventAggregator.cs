using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FlagMySpace.Agnostic.EventAggregator
{
    /// <summary>
    ///     Enables loosely-coupled publication of and subscription to events.
    /// </summary>
    public class EventAggregator : IEventAggregator
    {
        /// <summary>
        ///     The default thread marshaller used for publication;
        /// </summary>
        private static readonly Action<Action> DefaultPublicationThreadMarshaller = action => action();

        /// <summary>
        ///     Processing of handler results on publication thread.
        /// </summary>
        private static readonly Action<object, object> HandlerResultProcessing = (target, result) => { };

        private readonly List<Handler> _handlers = new List<Handler>();

        /// <summary>
        ///     Initializes a new instance of the <see cref="EventAggregator" /> class.
        /// </summary>
        public EventAggregator()
        {
            PublicationThreadMarshaller = DefaultPublicationThreadMarshaller;
        }

        /// <summary>
        ///     Gets or sets the default publication thread marshaller.
        /// </summary>
        /// <value>
        ///     The default publication thread marshaller.
        /// </value>
        public Action<Action> PublicationThreadMarshaller { get; set; }

        /// <summary>
        ///     Searches the subscribed handlers to check if we have a handler for
        ///     the message type supplied.
        /// </summary>
        /// <param name="messageType">The message type to check with</param>
        /// <returns>True if any handler is found, false if not.</returns>
        public bool HandlerExistsFor(Type messageType)
        {
            lock (_handlers)
            {
                return _handlers.Any(handler => handler.Handles(messageType) & !handler.IsDead);
            }
        }

        /// <summary>
        ///     Subscribes an instance to all events declared through implementations of <see cref="IHandle{T}" />
        /// </summary>
        /// <param name="subscriber">The instance to subscribe for event publication.</param>
        public virtual void Subscribe(object subscriber)
        {
            if (subscriber == null)
            {
                throw new ArgumentNullException("subscriber");
            }
            lock (_handlers)
            {
                if (_handlers.Any(x => x.Matches(subscriber)))
                {
                    return;
                }

                _handlers.Add(new Handler(subscriber));
            }
        }

        /// <summary>
        ///     Unsubscribes the instance from all events.
        /// </summary>
        /// <param name="subscriber">The instance to unsubscribe.</param>
        public virtual void Unsubscribe(object subscriber)
        {
            if (subscriber == null)
            {
                throw new ArgumentNullException("subscriber");
            }
            lock (_handlers)
            {
                var found = _handlers.FirstOrDefault(x => x.Matches(subscriber));

                if (found != null)
                {
                    _handlers.Remove(found);
                }
            }
        }

        /// <summary>
        ///     Publishes a message.
        /// </summary>
        /// <param name="message">The message instance.</param>
        /// <remarks>
        ///     Does not marshall the the publication to any special thread by default.
        /// </remarks>
        public virtual void Publish(object message)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }
            Publish(message, PublicationThreadMarshaller);
        }

        /// <summary>
        ///     Publishes a message.
        /// </summary>
        /// <param name="message">The message instance.</param>
        /// <param name="marshal">Allows the publisher to provide a custom thread marshaller for the message publication.</param>
        public virtual void Publish(object message, Action<Action> marshal)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }
            if (marshal == null)
            {
                throw new ArgumentNullException("marshal");
            }

            Handler[] toNotify;
            lock (_handlers)
            {
                toNotify = _handlers.ToArray();
            }

            marshal(() =>
            {
                var messageType = message.GetType();

                var dead = toNotify
                    .Where(handler => !handler.Handle(messageType, message))
                    .ToList();

                if (dead.Any())
                {
                    lock (_handlers)
                    {
                        dead.Apply(x => _handlers.Remove(x));
                    }
                }
            });
        }

        private class Handler
        {
            private readonly WeakReference _reference;
            private readonly Dictionary<Type, MethodInfo> _supportedHandlers = new Dictionary<Type, MethodInfo>();

            public Handler(object handler)
            {
                _reference = new WeakReference(handler);

                var handlerInfo = typeof (IHandle).GetTypeInfo();
                var interfaces = handler.GetType().GetTypeInfo().ImplementedInterfaces
                    .Where(x => handlerInfo.IsAssignableFrom(x.GetTypeInfo()) && x.GetTypeInfo().IsGenericType);

                foreach (var @interface in interfaces)
                {
                    var type = @interface.GenericTypeArguments[0];
                    var method = @interface.GetTypeInfo().DeclaredMethods.First(x => x.Name == "Handle");
                    _supportedHandlers[type] = method;
                }
            }

            public bool IsDead
            {
                get { return _reference.Target == null; }
            }

            public bool Matches(object instance)
            {
                return _reference.Target == instance;
            }

            public bool Handle(Type messageType, object message)
            {
                var target = _reference.Target;
                if (target == null)
                {
                    return false;
                }

                foreach (var pair in _supportedHandlers)
                {
                    if (pair.Key.IsAssignableFrom(messageType))
                    {
                        var result = pair.Value.Invoke(target, new[] {message});
                        if (result != null)
                        {
                            HandlerResultProcessing(target, result);
                        }
                    }
                }

                return true;
            }

            public bool Handles(Type messageType)
            {
                return _supportedHandlers.Any(pair => pair.Key.IsAssignableFrom(messageType));
            }
        }
    }
}