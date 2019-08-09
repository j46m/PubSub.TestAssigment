using System.Threading.Tasks;

namespace ServiceBusUtilities.Definitions
{
    public interface IMessageSender
    {
        Task SendMessageAsync<T>(T message);
    }
}