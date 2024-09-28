namespace HakatonBAGNET.Infra.Services;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(
        IUnitOfWork unitOfWork,
        ICategoryRepository categoryRepository)
    {
        _unitOfWork = unitOfWork;
        _categoryRepository = categoryRepository;
    }

    public async Task<IResult<IEnumerable<CategoryResponse>>> GetAllAsync(CancellationToken cancellationToken)
    {
        var categoriesEntities = await _categoryRepository.GetAllAsync(cancellationToken);
        var categoriesResponse = categoriesEntities
            .Select(categoryEntity => 
                new CategoryResponse(categoryEntity.Id, categoryEntity.Title));
        return await Result<IEnumerable<CategoryResponse>>.SuccessAsync(categoriesResponse);
    }
    
    public async Task<IResult<CategoryResponse>> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        if (id == default)
        {
            return await Result<CategoryResponse>.FailAsync("Некорректный формат идентификатора!");
        }
        
        var categoryEntity = await _categoryRepository
            .GetByIdAsync(id, cancellationToken);
        if (categoryEntity == null)
        {
            return await Result<CategoryResponse>.FailAsync("Категория с данным идентификатором не найдена!");
        }

        var categoryResponse = new CategoryResponse(categoryEntity.Id, categoryEntity.Title);
        return await Result<CategoryResponse>.SuccessAsync(categoryResponse);
    }

    public async Task<IResult> CreateAsync(CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        var isExistByTitle = await _categoryRepository
            .IsExistByTitleAsync(request.Title, cancellationToken);
        if (isExistByTitle)
        {
            return await Result.FailAsync("Категория с данным названием уже существует!");
        }

        var categoryEntity = new CategoryEntity(
            request.Title);
        await _categoryRepository.AddAsync(categoryEntity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return await Result.SuccessAsync();
    }

    public async Task<IResult> UpdateAsync(int id, UpdateCategoryRequest request, CancellationToken cancellationToken)
    {
        if (id == default)
        {
            return await Result.FailAsync("Некорректный формат идентификатора!");
        }
        
        var isExistForUpdateByTitle = await _categoryRepository
            .IsExistForUpdateByTitleAsync(id, request.Title, cancellationToken);
        if (isExistForUpdateByTitle)
        {
            return await Result.FailAsync("Категория с данным названием уже существует!");
        }
        
        var categoryEntity = await _categoryRepository.GetByIdAsync(id, cancellationToken);
        if (categoryEntity == null)
        {
            return await Result<CategoryResponse>.FailAsync("Категория с данным идентификатором не найдена!");
        }
        
        categoryEntity.Title = request.Title;
        categoryEntity.UpdatedAt = DateTime.UtcNow;
        
        await _categoryRepository.UpdateAsync(categoryEntity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return await Result.SuccessAsync();
    }

    public async Task<IResult> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        if (id == default)
        {
            return await Result.FailAsync("Некорректный формат идентификатора!");
        }
        
        var categoryEntity = await _categoryRepository.GetByIdAsync(id, cancellationToken);
        if (categoryEntity == null)
        {
            return await Result<CategoryResponse>.FailAsync("Категория с данным идентификатором не найдена!");
        }
        
        categoryEntity.IsDeleted = true;
        categoryEntity.DeletedAt = DateTime.UtcNow;
        
        await _categoryRepository.UpdateAsync(categoryEntity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return await Result.SuccessAsync();
    }
}