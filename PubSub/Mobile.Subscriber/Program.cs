using System;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.DependencyInjection;
using Mobile.Subscriber.Definitions;
using Mobile.Subscriber.Implementations;
using ServiceBusUtilities.Definitions;
using ServiceBusUtilities.Implementations;

namespace Mobile.Subscriber
{
    class Program
    {
        private static IServiceCollection _services;
        private static IMobileSubscriber _mobileSubscriber;

        static void Main(string[] args)
        {
            Initialize();

            _mobileSubscriber.ShowMessage();
            Console.ReadKey();
        }

        private static void Initialize()
        {
            _services = new ServiceCollection();

            //TODO: from config
            const string serviceBusConnectionString = "";
            const string topic = "testing-topic";
            const string subscription = "testing-subscription-2";

            _services.AddSingleton<ISubscriptionClient>(new SubscriptionClient(serviceBusConnectionString,topic,subscription));
            var subscriptionClient = _services.BuildServiceProvider().GetService<ISubscriptionClient>();
            _services.AddSingleton<IMessageReader>(x=> new ServiceBusReader(subscriptionClient));
            var messageReader = _services.BuildServiceProvider().GetService<IMessageReader>();

            _services.AddSingleton<IMobileSubscriber>(x=> new SubscriberServiceBus(messageReader));
            _mobileSubscriber = _services.BuildServiceProvider().GetService<IMobileSubscriber>();
        }
    }
}
