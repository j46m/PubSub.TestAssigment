using System.Threading.Tasks;
using Messaging.Implementations;
using Xunit;

namespace Tests
{
    public class MessageProcessorTests
    {
        private readonly MessageProcessorJson _messageProcessor;
        public MessageProcessorTests()
        {
            _messageProcessor = new MessageProcessorJson();
        }
        [Fact]
        public async Task ShouldSerializeTextToMessage()
        {
            const string expectedValue = "{\"Message\":\"Hello Test One\"}";
            var actualValue = await _messageProcessor.ProcessMessageAsync("Hello Test One");

            Assert.Equal(expectedValue,actualValue);
        }
    }
}
