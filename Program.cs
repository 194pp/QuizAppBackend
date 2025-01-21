
using Microsoft.EntityFrameworkCore;
using QuizAppBackend.Data;
using QuizAppBackend.Services;

namespace QuizAppBackend;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var services = builder.Services;
        var config = builder.Configuration;

        services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                //policy.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
                //      .AllowAnyHeader()
                //      .AllowAnyMethod(); 
                policy.AllowAnyOrigin()
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            });
        });
        services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddTransient<IQuizService, QuizService>();
        services.AddTransient<IHighscoreService, HighscoreService>();
        services.AddSwaggerGen();
        services.AddDbContext<AppDbContext>(options =>
            options.UseInMemoryDatabase(config.GetConnectionString("InMemoryDb")!)
        );

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseCors();
        app.UseAuthorization();

        app.MapControllers();

        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            await dbContext.Database.EnsureCreatedAsync();
        }

        app.Run();
    }
}

