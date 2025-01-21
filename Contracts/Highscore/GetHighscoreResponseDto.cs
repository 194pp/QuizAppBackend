namespace QuizAppBackend.Contracts.Highscores;

public class GetHighscoreResponseDto
{
    public required string Email { get; set; }
    public required int Score { get; set; }
}

