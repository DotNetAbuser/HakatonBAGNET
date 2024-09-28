namespace HakatonBAGNET.Application.IServices;

public interface ICategoryService
{
    Task<IResult<IEnumerable<CategoryResponse>>> GetAllAsync(CancellationToken cancellationToken);
    Task<IResult<CategoryResponse>> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<IResult> CreateAsync(CreateCategoryRequest request, CancellationToken cancellationToken);
    Task<IResult> UpdateAsync(int id, UpdateCategoryRequest request, CancellationToken cancellationToken);
    Task<IResult> DeleteAsync(int id, CancellationToken cancellationToken);
}