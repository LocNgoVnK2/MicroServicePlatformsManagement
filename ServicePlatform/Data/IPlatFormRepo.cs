using MicroservicePlatform.Model;

namespace MicroservicePlatform.Data{
     public interface IPlatFormRepo 
    {
        bool SaveChanges();
        IEnumerable<Platform> GetPlatforms();
        Platform GetPlatformById(int id);
        void RemovePlatform(Platform platform);
        void CreatePlatform(Platform platform);
    }
}