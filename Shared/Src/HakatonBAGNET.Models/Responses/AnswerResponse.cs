namespace HakatonBAGNET.Models.Responses;

public record AnswerResponse(
    [property: JsonPropertyName("question_by_full_name")]
    string QuestionByFullName,
    [property: JsonPropertyName("answer_by_full_name")]
    string AnswerByFullName,
    [property: JsonPropertyName("question_content")]
    string QuestionContent,
    [property: JsonPropertyName("answer_content")]
    string AnswerContent,
    [property: JsonPropertyName("is_moderated")]
    bool IsModerated,
    [property: JsonPropertyName("is_active")]
    bool IsActive);