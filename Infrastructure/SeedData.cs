using Domain.Entities;
using Infrastructure.Application.Context;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure
{
    public static class SeedData
    {

        public static async Task InitializeAsync(IServiceProvider services)
        {
            var applicationContextservice = services.GetRequiredService<ApplicationContext>();
            await AddTestData(applicationContextservice);
        }

        public static async Task AddTestData(ApplicationContext context)
        {
            if (context.Categories.Any()) return;
            List<Photo> photos = new List<Photo>
            {
                new Photo("Funny",Guid.NewGuid()),
                 new Photo("Funny",Guid.NewGuid()),
                  new Photo("Funny",Guid.NewGuid()),
                   new Photo("Funny",Guid.NewGuid()),
            };

            context.Categories.Add(new Category()
            {
                Name = "Nature",
                Description = "About Nature",
                Photos = photos,
            }); 

           /* context.Categories.Add(new Category("Nature", "About Nature",photos));
            context.Categories.Add(new Category("Artistic", "About Artistic",photos));
            context.Categories.Add(new Category("Cars", "About Cars",photos));
            context.Categories.Add(new Category("Movies", "About Movies",photos));*/


            await context.SaveChangesAsync();

        }
    }
}
