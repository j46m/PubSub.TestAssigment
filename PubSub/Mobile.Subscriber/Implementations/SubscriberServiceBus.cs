using System;
using Mobile.Subscriber.Definitions;
using ServiceBusUtilities.Definitions;

namespace Mobile.Subscriber.Implementations
{
    public class SubscriberServiceBus : IMobileSubscriber
    {
        private readonly IMessageReader _messageReader;

        public SubscriberServiceBus(IMessageReader messageReader)
        {
            Console.WriteLine("Some cool Mobile Subscriber an app or something ;) ");
            _messageReader = messageReader;
        }

        public void ShowMessage()
        {
            _messageReader.ReadMessage();
        }
    }
}