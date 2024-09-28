namespace HakatonBAGNET.Models.Responses;

public record QuestionResponse(
    Guid QuestionId,
    string CategoryTitle,
    string QuestionContent,
    int CorrectPointsCount,
    int IncorrectPointsCount, 
    bool IsModerated,
    bool IsActive);