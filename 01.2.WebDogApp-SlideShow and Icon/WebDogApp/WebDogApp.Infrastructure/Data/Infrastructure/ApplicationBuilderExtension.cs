using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using WebDogApp.Infrastructure.Data.Domain;

namespace WebDogApp.Infrastructure.Data.Infrastructure
{
    public static class ApplicationBuilderExtension
    {
        public static async Task<IApplicationBuilder> PrepareDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;
            var data = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            SeedBreeds(data);

            return app;
        }

        private static void SeedBreeds(ApplicationDbContext data)
        {
            if (data.Breeds.Any())
            {
                return;
            }

            data.Breeds.AddRange(new[]
            {
                new Breed { Name = "Husky" },
                new Breed { Name = "Pinscher" },
                new Breed { Name = "Cocer spaniol" },
                new Breed { Name = "Dachshund" },
                new Breed { Name = "Doberman" }
            });

            data.SaveChanges();
        }
    }
}
