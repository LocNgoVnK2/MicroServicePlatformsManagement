using MicroservicePlatform.Model;

namespace MicroservicePlatform.Data{
    public class PlatFormRepo : IPlatFormRepo
    {
        private readonly AppDbContext _context;

        public PlatFormRepo(AppDbContext context) 
        {
            _context = context;
        }
        public void CreatePlatform(Platform platform)
        {
            if(platform ==null){
                throw new ArgumentNullException(nameof(platform));
            }
            _context.Platforms.Add(platform);
        }

        public Platform GetPlatformById(int id)
        {
            return _context.Platforms.FirstOrDefault(e=>e.Id == id);
        }

        public IEnumerable<Platform> GetPlatforms()
        {
            return _context.Platforms.ToList();
        }
        public void RemovePlatform(Platform platform)
        {
            if (platform == null)
            {
                throw new ArgumentNullException(nameof(platform));
            }

            _context.Platforms.Remove(platform);
        }
        public bool SaveChanges()
        {
            return _context.SaveChanges()>=0;
        }
    }
}