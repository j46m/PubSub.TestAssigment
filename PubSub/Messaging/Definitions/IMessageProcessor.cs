using System.Threading.Tasks;

namespace Messaging.Definitions
{
	public interface IMessageProcessor<T,TResult>
	{
		Task<TResult> ProcessMessageAsync(T message);
	}
}
