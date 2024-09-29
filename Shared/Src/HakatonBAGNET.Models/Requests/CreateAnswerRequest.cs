namespace HakatonBAGNET.Models.Requests;

public class CreateAnswerRequest
{
    [JsonPropertyName("user_id")]
    public int UserId { get; set; }
    
    [JsonPropertyName("question_id")]
    public Guid QuestionId { get; set; }

    [JsonPropertyName("answer_content")]
    public string AnswerContent { get; set; }
}