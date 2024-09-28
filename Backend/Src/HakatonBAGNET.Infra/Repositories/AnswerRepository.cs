namespace HakatonBAGNET.Infra.Repositories;

public class AnswerRepository : Repository<AnswerEntity, Guid>, IAnswerRepository
{
    public AnswerRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}