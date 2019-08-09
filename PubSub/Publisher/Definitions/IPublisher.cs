using System.Threading.Tasks;

namespace Publisher.Definitions
{
    public interface IPublisher
	{
		Task Publish<T>(T message);
    }
}
