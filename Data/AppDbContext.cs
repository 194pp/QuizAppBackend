using Microsoft.EntityFrameworkCore;
using QuizAppBackend.Models;
using System.Text.Json;

namespace QuizAppBackend.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Highscore> Highscores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var seedData = LoadSeedData<Quiz>("Data/QuizSeedData.json");
        var seedDataHighscores = LoadSeedData<Highscore>("Data/HighscoreSeedData.json");

        modelBuilder.Entity<Quiz>().HasData(seedData);
        modelBuilder.Entity<Highscore>().HasData(seedDataHighscores);
    }
    private static List<T> LoadSeedData<T>(string filePath) where T : class
    {
        var json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<T>>(json) ?? [];
    }
}
