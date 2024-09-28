namespace HakatonBAGNET.Application.IRepositories;

public interface ICategoryRepository : IRepository<CategoryEntity, int>
{
    Task<bool> IsExistByTitleAsync(string title, CancellationToken cancellationToken);
    Task<bool> IsExistForUpdateByTitleAsync(int id, string title, CancellationToken cancellationToken);
}