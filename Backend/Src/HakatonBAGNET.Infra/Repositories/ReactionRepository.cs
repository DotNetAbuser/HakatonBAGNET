namespace HakatonBAGNET.Infra.Repositories;

public class ReactionRepository : Repository<ReactionEntity, Guid>, IReactionRepository
{
    public ReactionRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}