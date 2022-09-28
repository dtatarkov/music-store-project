using API.Context;
using API.IntegrationTests.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.IntegrationTests
{
    public class TestsApplication: WebApplicationFactory<Program>
    {
        private readonly string environment;

        public TestsApplication(string environment = "Development")
        {
            this.environment = environment;
        }

        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.UseEnvironment(environment);

            // Add mock/test services to the builder here
            builder.ConfigureServices(services =>
            {
                var descriptor = services.Single(d => d.ServiceType == typeof(DbContextOptions<ApplicationContext>));
                services.Remove(descriptor);

                services.AddDbContext<ApplicationContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                });

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var initializer = scopedServices.GetRequiredService<IDBInitializer>();
                    
                    initializer.Initialize();                    
                }
            });

            return base.CreateHost(builder);
        }
    }
}
