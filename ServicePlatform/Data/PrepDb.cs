using MicroservicePlatform.Model;
using Microsoft.EntityFrameworkCore;

namespace MicroservicePlatform.Data{
    public static class PrepDb{
        public static void PrepPopulation(IApplicationBuilder app, bool isProd ){
            using(var serviceScope = app.ApplicationServices.CreateScope()){
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProd);
            }
        }
        private static void SeedData(AppDbContext context, bool isProd){
            if(isProd){
                Console.WriteLine("Migrations Data...");
                try{
                    context.Database.Migrate();
                }catch(Exception ex){
                    Console.WriteLine("could not Migrations Data..." +ex.ToString());
                }

            }

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