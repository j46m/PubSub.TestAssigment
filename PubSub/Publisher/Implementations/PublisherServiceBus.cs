using System;
using System.Threading.Tasks;
using Messaging.Definitions;
using Publisher.Definitions;
using ServiceBusUtilities.Definitions;

namespace Publisher.Implementations
{
    public class PublisherServiceBus : IPublisher
    {
        private readonly IMessageProcessor<string, string> _messageProcessor;
        private readonly IMessageSender _messageSender;

        public PublisherServiceBus(IMessageProcessor<string, string> messageProcessor, IMessageSender messageSender)
        {
            _messageProcessor = messageProcessor;
            _messageSender = messageSender;
        }

        public Task Publish<T>(T message)
        {
            var randomMessage = _messageProcessor.ProcessMessageAsync(message.ToString()).Result;
            return Task.Factory.StartNew(() => SendMessage(randomMessage));
        }

        private void SendMessage(string message)
        {
            _messageSender.SendMessageAsync(message);
        }
    }
}