namespace HakatonBAGNET.Models.Requests;

public class CreateQuestionRequest
{
    [JsonPropertyName("user_id")]
    public int UserId { get; set; }
    [JsonPropertyName("category_id")]
    public int CategoryId { get; set; }
    [JsonPropertyName("question_content")]
    public string QuestionContent { get; set; }
    [JsonPropertyName("correct_points_count")]
    public int CorrectPointsCount { get; set; }
    [JsonPropertyName("incorrect_points_count")]
    public int IncorrectPointsCount { get; set; }
}