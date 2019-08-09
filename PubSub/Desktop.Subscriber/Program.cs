using System;
using Desktop.Subscriber.Definitions;
using Desktop.Subscriber.Implementations;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.DependencyInjection;
using ServiceBusUtilities.Definitions;
using ServiceBusUtilities.Implementations;

namespace Desktop.Subscriber
{
	class Program
	{
        private static IServiceCollection _services;
        private static IDesktopSubscriber _desktopSubscriber;
        static void Main(string[] args)
        {
            Initialize();
            _desktopSubscriber.ShowMessage();
            Console.ReadKey();
        }

        private static void Initialize()
        {
            _services = new ServiceCollection();

            //TODO: from config
            const string serviceBusConnectionString = "";
            const string topic = "testing-topic";
            const string subscription = "testing-subscription";

            _services.AddSingleton<ISubscriptionClient>(new SubscriptionClient(serviceBusConnectionString, topic, subscription));
            var subscriptionClient = _services.BuildServiceProvider().GetService<ISubscriptionClient>();
            _services.AddSingleton<IMessageReader>(x => new ServiceBusReader(subscriptionClient));
            var messageReader = _services.BuildServiceProvider().GetService<IMessageReader>();

            _services.AddSingleton<IDesktopSubscriber>(x => new DesktopSubsServiceBus(messageReader));
            _desktopSubscriber = _services.BuildServiceProvider().GetService<IDesktopSubscriber>();
        }
    }
}
