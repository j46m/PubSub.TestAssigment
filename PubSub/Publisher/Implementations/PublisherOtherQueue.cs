using System;
using System.Threading.Tasks;
using Publisher.Definitions;

namespace Publisher.Implementations
{
    public class PublisherOtherQueue : IPublisher
    {
        public Task Publish<T>(T message)
        {
            return new Task(() => Console.WriteLine("Message send to other queue system"));
        }
    }
}