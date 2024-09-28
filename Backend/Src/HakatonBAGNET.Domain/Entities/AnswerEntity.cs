namespace HakatonBAGNET.Domain.Entities;

public class AnswerEntity : BaseEntity<Guid>
{
    public AnswerEntity(
        Guid id,
        int userId,
        Guid questionId,
        string answerContent)
    {
        Id = id;
        UserId = userId;
        QuestionId = questionId;
        AnswerContent = answerContent;
    }
    
    public int UserId { get; set; }
    public Guid QuestionId { get; set; }
    public string AnswerContent { get; set; }
    public bool IsModerated { get; set; }
    public bool IsActive { get; set; }

    public UserEntity User { get; set; } = null!;
    public QuestionEntity Question { get; set; } = null!;
    public ICollection<ReactionEntity> Reactions { get; set; } = [];
}