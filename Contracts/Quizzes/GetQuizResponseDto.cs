using System.Text.Json.Serialization;

namespace QuizAppBackend.Contracts.Quizzes;

public class GetQuizResponseDto
{
    public required Guid Id { get; set; }
    public required string Question { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string[]? AnswerOptions { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? IsRadioOptions { get; set; }
}