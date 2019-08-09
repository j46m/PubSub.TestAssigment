using System;
using Messaging.Definitions;
using Messaging.Implementations;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.DependencyInjection;
using Publisher.Definitions;
using Publisher.Implementations;
using ServiceBusUtilities.Definitions;
using ServiceBusUtilities.Implementations;

namespace Publisher
{
    class Program
    {
        private static IServiceCollection _services;
        private static IPublisher _publisher;

        static void Main(string[] args)
        {
            Initialize();
            // This project should be responsible of published messages
            var inProgress = true;
			do
			{
				Console.WriteLine("Please enter message. Q to Quit");
				Console.Write("> ");
				var value = Console.ReadLine();

				if (value?.ToLower() != "q")
				{
                    // Publish any message/object user will enter
                     _publisher.Publish(value);
                }
				else
				{
					inProgress = false;
				}

			} while (inProgress);
		}

        private static void Initialize()
        {
            _services = new ServiceCollection();

            _services.AddSingleton<IMessageProcessor<string, string>>(x=> new MessageProcessorJson());

            var messageProcessor = _services.BuildServiceProvider().GetService<IMessageProcessor<string, string>>();

            //TODO: From config
            const string serviceBusConnectionString = "";
            const string topic = "testing-topic";

            _services.AddSingleton<ITopicClient>(x=> new TopicClient(serviceBusConnectionString, topic));
            var topicClient = _services.BuildServiceProvider().GetService<ITopicClient>();

            _services.AddSingleton<IMessageSender>(x=> new ServiceBusSender(topicClient));
            var messageSender = _services.BuildServiceProvider().GetService<IMessageSender>();

            _services.AddScoped<IPublisher>(x=> new PublisherServiceBus(messageProcessor,messageSender));

            _publisher = _services.BuildServiceProvider().GetService<IPublisher>();
        }
    }
}
