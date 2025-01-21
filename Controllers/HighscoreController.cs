using Microsoft.AspNetCore.Mvc;
using QuizAppBackend.Contracts.Highscores;
using QuizAppBackend.Data;
using QuizAppBackend.Services;

namespace QuizAppBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HighscoreController
{
    private readonly AppDbContext _context;
    private readonly IHighscoreService _highscoreService;
    public HighscoreController(AppDbContext context, IHighscoreService highscoreService)
    {
        _context = context;
        _highscoreService = highscoreService;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetHighscoreResponseDto>>> GetQuizzes()
    {
        return await _highscoreService.ListAsync();
    }
}

