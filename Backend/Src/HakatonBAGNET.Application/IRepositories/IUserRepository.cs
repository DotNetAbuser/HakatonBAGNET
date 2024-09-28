namespace HakatonBAGNET.Application.IRepositories;

public interface IUserRepository : IRepository<UserEntity, int>
{
    Task<bool> IsExistByUserIdAsync(int userId, CancellationToken cancellationToken);
}