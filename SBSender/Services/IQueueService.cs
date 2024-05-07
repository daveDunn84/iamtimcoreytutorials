
namespace SBSender.Services
{
    public interface IQueueService
    {
        Task SendMessageAsync<T>(T ServiceBusMessage, string queueName);
    }
}