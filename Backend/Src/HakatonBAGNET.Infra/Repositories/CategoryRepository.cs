namespace HakatonBAGNET.Infra.Repositories;

public class CategoryRepository : Repository<CategoryEntity, int>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> IsExistByTitleAsync(string title, CancellationToken cancellationToken)
    {
        return await _dbSet.AnyAsync(c => c.Title == title, cancellationToken);
    }

    public async Task<bool> IsExistForUpdateByTitleAsync(int id, string title, CancellationToken cancellationToken)
    {
        return await _dbSet.AnyAsync(c => c.Title == title && c.Id != id, cancellationToken);
    }
} 
