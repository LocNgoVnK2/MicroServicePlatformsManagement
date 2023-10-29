
using MicroservicePlatform.Dtos;

namespace MicroservicePlatform.AsyncDataServices
{
    public interface IMessageBusClient
    {
        void PublishNewPlatform(PlatformPublishedDto platformPublishedDto);
    }
}