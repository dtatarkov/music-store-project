using API.Context;
using API.Services;
using API.Settings;
using API.Validators;
using NLog;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

GlobalDiagnosticsContext.Set("connectionString", builder.Configuration.GetValue<string>("LogsDB:ConnectionString"));

builder.Logging.ClearProviders();
builder.Host.UseNLog();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<IApplicationContext, ApplicationContext>();

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

//expose Program class so it can be access by integration tests
public partial class Program { }