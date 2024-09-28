namespace HakatonBAGNET.Domain.Entities;

public class QuestionEntity : BaseEntity<Guid>
{
    public QuestionEntity(
        int categoryId,
        int userId,
        string questionContent,
        int correctPointsCount,
        int incorrectPointsCount)
    {
        CategoryId = categoryId;
        UserId = userId;
        QuestionContent = questionContent;
        CorrectPointsCount = correctPointsCount;
        IncorrectPointsCount = incorrectPointsCount;
    }

    public int CategoryId { get; set; }
    public int UserId { get; set; }
    public string QuestionContent { get; set; }
    public int CorrectPointsCount { get; set; }
    public int IncorrectPointsCount { get; set; }
    public bool IsModerated { get; set; } = false;
    public bool IsActive { get; set; } = false;

    public CategoryEntity Category { get; set; } = null!;
    public UserEntity User { get; set; } = null!;
    public ICollection<AnswerEntity> Answeres { get; } = [];
    public ICollection<ReactionEntity> Reactions { get; } = [];

}