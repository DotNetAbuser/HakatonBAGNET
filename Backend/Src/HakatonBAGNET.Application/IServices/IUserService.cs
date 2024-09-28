namespace HakatonBAGNET.Application.IServices;

public interface IUserService
{
    Task<IResult<PaginatedData<UserResponse>>> GetPaginatedByRatingAsync(
        int pageNumber, int pageSize,
        CancellationToken cancellationToken);

    Task<IResult<PaginatedData<UserResponse>>> GetPaginatedAsync(
        int pageNumber, int pageSize, 
        string? searchTerms, 
        CancellationToken cancellationToken);
    
    Task<IResult<UserResponse>> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task<IResult> AddUserAsync(
        CreateUserRequest request, 
        CancellationToken cancellationToken);

}