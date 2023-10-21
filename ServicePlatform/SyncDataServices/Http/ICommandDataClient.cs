using System.Threading.Tasks;
using MicroservicePlatform.Dtos;


namespace MicroservicePlatform.SyncDataServices.Http
{
    public interface ICommandDataClient
    {
        Task SendPlatformToCommand(PlatformReadDto plat); 
    }
}