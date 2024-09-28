namespace HakatonBAGNET.Infra.Repositories;

public class UserRepository : Repository<UserEntity, int>, IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> IsExistByUserIdAsync(int userId, CancellationToken cancellationToken)
    {
        return await _dbSet.AnyAsync(x => x.Id == userId, cancellationToken);
    }
}