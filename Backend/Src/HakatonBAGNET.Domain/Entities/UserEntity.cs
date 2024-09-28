namespace HakatonBAGNET.Domain.Entities;

public class UserEntity : BaseEntity<int>
{
    public UserEntity(
        int id,
        string firstName,
        string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }
    
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int PointsCount { get; set; } = 0;
    public bool IsActive { get; set; } = true;

    public ICollection<QuestionEntity> CreatedQuestions { get; set; } = [];
    public ICollection<AnswerEntity> AnsweredQuestions { get; set; } = [];
    public ICollection<ReactionEntity> CreatedReactionsByUser { get; set; } = [];

}