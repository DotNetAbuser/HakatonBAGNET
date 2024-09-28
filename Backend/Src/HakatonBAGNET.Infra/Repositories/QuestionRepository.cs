namespace HakatonBAGNET.Infra.Repositories;

public class QuestionRepository : Repository<QuestionEntity, Guid>, IQuestionRepository
{
    public QuestionRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}