using System.ComponentModel.DataAnnotations;

namespace QuizAppBackend.Contracts.Highscores;

public class SubmitAnswersDto
{
    [EmailAddress]
    public string Email { get; set; }
    public List<SubmitAnswerDto> Answers { get; set; }
}

public class SubmitAnswerDto
{
    public Guid Id { get; set; }
    public string? TextAnswer { get; set; }
    public int[]? SelectableAnswers { get; set; }
}

