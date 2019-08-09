using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using ServiceBusUtilities.Definitions;

namespace ServiceBusUtilities.Implementations
{
    public class ServiceBusSender : IMessageSender
    {
        private readonly ITopicClient _topicClient;

        public ServiceBusSender(ITopicClient topicClient)
        {
            _topicClient = topicClient;
        }

        public async Task SendMessageAsync<T>(T message)
        {
            try
            {
                var messageToSend = new Message(Encoding.UTF8.GetBytes(message.ToString()));

                await _topicClient.SendAsync(messageToSend);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}