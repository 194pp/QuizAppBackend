using Microsoft.AspNetCore.Mvc;
using QuizAppBackend.Contracts.Highscores;
using QuizAppBackend.Contracts.Quizzes;
using QuizAppBackend.Data;
using QuizAppBackend.Services;

namespace QuizAppBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuizController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IQuizService _quizService;

    public QuizController(AppDbContext context, IQuizService quizService)
    {
        _context = context;
        _quizService = quizService;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetQuizResponseDto>>> GetQuizzes()
    {
        return await _quizService.ListAsync();
    }

    [HttpPost]
    public async Task<IActionResult> SubmitAnswers([FromBody] SubmitAnswersDto requestDto)
    {
        if (requestDto == null || requestDto.Answers == null || requestDto.Answers.Count == 0)
        {
            return BadRequest("Invalid request data.");
        }

        await _quizService.SubmitAnswersAsync(requestDto);
        return Ok(new { message = "Answers submitted successfully." });

    }
}