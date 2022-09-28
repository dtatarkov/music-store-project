using API.Context;
using API.Services;
using API.Settings;
using API.Validators;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NLog;
using NLog.Web;
using Npgsql;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        GlobalDiagnosticsContext.Set("connectionString", builder.Configuration.GetValue<string>("LogsDB:ConnectionString"));
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        builder.Logging.ClearProviders();
        builder.Host.UseNLog();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer(); // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<IApplicationContext, ApplicationContext>(options =>
        {
            var psqlBuilder = new NpgsqlConnectionStringBuilder(builder.Configuration.GetValue<string>("DB:ConnectionString"))
            {
                Password = builder.Configuration.GetValue<string>("DB:Password")
            };

            options.UseNpgsql(psqlBuilder.ConnectionString);
        });

        builder.Services.AddSingleton(services => new AppSettings(services.GetRequiredService<IConfiguration>()));
        builder.Services.AddSingleton<IAlbumValidator, AlbumValidator>();

        builder.Services.AddScoped<IAlbumsService, AlbumsService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}