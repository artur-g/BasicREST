using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace BasicREST
{
    /// <summary>
    /// Sources:
    ///     https://medium.com/net-core/how-to-build-a-restful-api-with-asp-net-core-fb7dd8d3e5e3
    ///     https://www.freecodecamp.org/news/an-awesome-guide-on-how-to-build-restful-apis-with-asp-net-core-87b818123e28/
    ///     
    ///     https://www.obergbrothersnaturalbeef.com/beefmap.html
    ///     https://www.obergbrothersnaturalbeef.com/porkmap.html
    ///     
    ///     https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/validation?view=aspnetcore-3.1
    ///     https://regex101.com/
    ///     
    ///     Did NOT work without Migrations (or somethig else [maybe persistence] [context.Database.EnsureCreated() is enought])
    ///     https://www.learnentityframeworkcore.com/migrations/seeding
    ///     
    ///     Exception handling.
    ///     I REALLY want to use AOP for this, but (so far) wasnt able to find good solution for this.
    ///     
    ///     Good candidates:
    ///     - AOP via compile-time weaving (unfortunatly, PostSharp is not free)
    ///     https://www.dotnetcurry.com/patterns-practices/1305/aspect-oriented-programming-aop-csharp-using-solid
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var context = host.Services.CreateScope().ServiceProvider.GetService<Data.MeatContext>())
            {
                ///IMPORTANT: in InMemoryDatabase. Without this, data wont seed properly
                context.Database.EnsureCreated();
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
