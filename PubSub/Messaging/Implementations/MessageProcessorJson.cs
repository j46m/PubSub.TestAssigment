using System;
using System.Threading.Tasks;
using Messaging.Definitions;
using Newtonsoft.Json;

namespace Messaging.Implementations
{
    public class MessageProcessorJson : IMessageProcessor<string,string>
    {
        public Task<string> ProcessMessageAsync(string message)
        {
            //TODO: Should add ID
            var messageToSend = new {
                Message = message
            };

            var serializedMessage = JsonConvert.SerializeObject(messageToSend);

            return Task.Factory.StartNew(()=> $"{serializedMessage}");
        }
    }
}