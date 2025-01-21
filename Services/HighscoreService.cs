using Microsoft.EntityFrameworkCore;
using QuizAppBackend.Contracts.Highscores;
using QuizAppBackend.Data;

namespace QuizAppBackend.Services;

public interface IHighscoreService
{
    Task<List<GetHighscoreResponseDto>> ListAsync();
}

public class HighscoreService : IHighscoreService
{
    private readonly AppDbContext _dbContext;

    public HighscoreService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<GetHighscoreResponseDto>> ListAsync()
    {
        var toReturn = await _dbContext.Highscores
            .Select(x => new GetHighscoreResponseDto
            {
                Email = x.Email,
                Score = x.Score,
            })
            .ToListAsync();

        return toReturn;
    }
}

