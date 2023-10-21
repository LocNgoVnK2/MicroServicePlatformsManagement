using MicroservicePlatform.Model;

namespace MicroservicePlatform.Data{
    public static class PrepDb{
        public static void PrepPopulation(IApplicationBuilder app){
            using(var serviceScope = app.ApplicationServices.CreateScope()){
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }
        private static void SeedData(AppDbContext context){
            if(!context.Platforms.Any()){
                Console.WriteLine("Seeding Data...");
                context.Platforms.AddRange(
                    new Platform(){Name="Dot Net",Publisher="Microsoft" ,Cost="free"},
                    new Platform(){Name="SQL Server",Publisher="Microsoft" ,Cost="free"}
                   
                );
                context.SaveChanges();
            }else{
                Console.WriteLine("We have seed data");
            }
        }
    } 
}