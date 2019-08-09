using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using ServiceBusUtilities.Definitions;
using ServiceBusUtilities.Implementations;
using Xunit;

namespace Tests
{
    public class ServiceBusIntegrationTest
    {
        private readonly IMessageSender _serviceBusSender;
        private readonly IMessageReader _serviceBusReader;
        public ServiceBusIntegrationTest()
        {
            const string serviceBusConnectionString = "";
            const string topic = "testing-topic";
            var topicClient = new TopicClient(serviceBusConnectionString, topic);

            const string subscription = "testing-subscription";
            var subscriptionClient = new SubscriptionClient(serviceBusConnectionString, topic, subscription);

            _serviceBusSender = new ServiceBusSender(topicClient);
            _serviceBusReader = new ServiceBusReader(subscriptionClient);
            
        }

        [Fact]
        public async Task ShouldSendMessageToTopic()
        {
            await _serviceBusSender.SendMessageAsync("Hello World");            
        }

        [Fact]
        public void ShouldReadFromSubscription()
        {
            _serviceBusReader.ReadMessage();
        }
    }
}