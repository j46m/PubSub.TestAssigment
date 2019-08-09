using System;
using Desktop.Subscriber.Definitions;
using ServiceBusUtilities.Definitions;

namespace Desktop.Subscriber.Implementations
{
    public class DesktopSubsServiceBus : IDesktopSubscriber
    {
        private readonly IMessageReader _messageReader;

        public DesktopSubsServiceBus(IMessageReader messageReader)
        {
            Console.WriteLine("Some cool Desktop Subscriber  ;) ");
            _messageReader = messageReader;
        }

        public void ShowMessage()
        {
            _messageReader.ReadMessage();
        }
    }
}