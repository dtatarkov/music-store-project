using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
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

            //// Add mock/test services to the builder here
            //builder.ConfigureServices(services =>
            //{
            //    services.AddScoped(sp =>
            //    {
            //        // Replace SQLite with in-memory database for tests
            //        return new DbContextOptionsBuilder<TodoDb>()
            //        .UseInMemoryDatabase("Tests")
            //        .UseApplicationServiceProvider(sp)
            //        .Options;
            //    });
            //});

            return base.CreateHost(builder);
        }
    }
}
