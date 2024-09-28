namespace HakatonBAGNET.Domain.Entities;

public class ReactionEntity : BaseEntity<Guid>
{
    public ReactionEntity(
        Guid id,
        int userId,
        Guid questionId,
        Guid answerId,
        bool isLiked)
    {
        Id = id;
        UserId = userId;
        QuestionId = questionId;
        AnswerId = answerId; 
        IsLiked = isLiked;
    }

    public int UserId { get; set; }
    public Guid QuestionId { get; set; }
    public Guid AnswerId { get; set; }
    public bool IsLiked { get; set; }

    public UserEntity User { get; set; }
    public QuestionEntity Question { get; set; }
    public AnswerEntity Answer { get; set; }
}