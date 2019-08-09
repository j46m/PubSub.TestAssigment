using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using ServiceBusUtilities.Definitions;

namespace ServiceBusUtilities.Implementations
{
    public class ServiceBusReader : IMessageReader
    {
        private readonly ISubscriptionClient _subscriptionClient;
        public ServiceBusReader(ISubscriptionClient subscriptionClient)
        {
            _subscriptionClient = subscriptionClient;
        }
        public void ReadMessage()
        {           
            _subscriptionClient.RegisterMessageHandler(ProcessMessagesAsync,ExceptionReceivedHandler);
        }

        private async Task ProcessMessagesAsync(Message message, CancellationToken token)
        {
            Console.WriteLine($"Received message: SequenceNumber:{message.SystemProperties.SequenceNumber} Body:{Encoding.UTF8.GetString(message.Body)}");
            await Task.CompletedTask;
        }

        private Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            Console.WriteLine($"Message handler encountered an exception {exceptionReceivedEventArgs.Exception}.");
            var context = exceptionReceivedEventArgs.ExceptionReceivedContext;
            Console.WriteLine("Exception context for troubleshooting:");
            Console.WriteLine($"- Endpoint: {context.Endpoint}");
            Console.WriteLine($"- Entity Path: {context.EntityPath}");
            Console.WriteLine($"- Executing Action: {context.Action}");
            return Task.CompletedTask;
        }
    }
}