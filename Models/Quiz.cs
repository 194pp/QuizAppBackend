using System.ComponentModel.DataAnnotations.Schema;

namespace QuizAppBackend.Models;

[Table("quizes")]
public class Quiz
{
    public Guid Id { get; set; }
    public required string Question { get; set; }
    // Checkbox/Radio question fields
    public string[]? AnswerOptions { get; set; }
    public int[]? CorrectAnswerOptions { get; set; }
    public bool? IsRadioOptions { get; set; }
    // Text input question fields
    public int? AnswerTextInputs { get; set; }
    public string? CorrectAnswerText { get; set; }
}

