using Microsoft.EntityFrameworkCore;
using QuizAppBackend.Contracts.Highscores;
using QuizAppBackend.Contracts.Quizzes;
using QuizAppBackend.Data;
using QuizAppBackend.Models;

namespace QuizAppBackend.Services;

public interface IQuizService
{
    Task<List<GetQuizResponseDto>> ListAsync();
    Task SubmitAnswersAsync(SubmitAnswersDto requestDto);
}

public class QuizService : IQuizService
{
    private readonly AppDbContext _dbContext;

    public QuizService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<GetQuizResponseDto>> ListAsync()
    {
        var toReturn = await _dbContext.Quizzes
            .Select(x => new GetQuizResponseDto
            {
                Id = x.Id,
                Question = x.Question,
                AnswerOptions = x.AnswerOptions,
                IsRadioOptions = x.IsRadioOptions,
            })
            .ToListAsync();

        return toReturn;
    }

    public async Task SubmitAnswersAsync(SubmitAnswersDto requestDto)
    {
        var dbQuizzes = await _dbContext.Quizzes.ToDictionaryAsync(x => x.Id, x => x);
        var score = GetScore(requestDto, dbQuizzes);

        _dbContext.Highscores.Add(new Highscore()
        {
            Email = requestDto.Email,
            Score = score,
        });
        await _dbContext.SaveChangesAsync();
    }

    private static int GetScore(SubmitAnswersDto requestDto, Dictionary<Guid, Quiz> dbQuizzes)
    {
        var score = 0;

        foreach (var answer in requestDto.Answers)
        {
            var dbQuiz = dbQuizzes[answer.Id];
            var isCorrect = true;

            if (answer.SelectableAnswers != null && dbQuiz.CorrectAnswerOptions != null)
            {
                int[]? correctAnswerOptions = dbQuiz.CorrectAnswerOptions;
                if (correctAnswerOptions?.Length != answer.SelectableAnswers.Length)
                {
                    isCorrect = false;
                }
                else
                {
                    foreach (var correctAnswerIndex in dbQuiz.CorrectAnswerOptions)
                    {
                        if (!answer.SelectableAnswers.Contains(correctAnswerIndex))
                        {
                            isCorrect = false;
                            break;
                        }
                    }
                }


            }
            else if (answer.TextAnswer != null)
            {
                isCorrect = answer.TextAnswer == dbQuiz.CorrectAnswerText;
            }
            else
            {
                throw new NotImplementedException();
            }
            if (isCorrect) score++;
        }

        return score;
    }
}
