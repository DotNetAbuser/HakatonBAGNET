namespace HakatonBAGNET.Infra.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IResult<PaginatedData<UserResponse>>> GetPaginatedByRatingAsync(
        int pageNumber, int pageSize,
        CancellationToken cancellationToken)
    {
        var (usersEntities, totalCount) = await _userRepository
            .GetPaginatedAsync(
                pageNumber: pageNumber, 
                pageSize: pageSize,
                orderBy: x => x.OrderByDescending(x => x.PointsCount),
                cancellationToken: cancellationToken);
        var usersWithPointsResponse = usersEntities
            .Select(userEntity =>
                new UserResponse(
                    userEntity.Id,
                    userEntity.FirstName,
                    userEntity.LastName,
                    userEntity.PointsCount));
        var paginatedResponse = new PaginatedData<UserResponse>(
            usersWithPointsResponse, totalCount);
        return await Result<PaginatedData<UserResponse>>.SuccessAsync(paginatedResponse);
    }

    public async Task<IResult<PaginatedData<UserResponse>>> GetPaginatedAsync(
        int pageNumber, int pageSize,
        string? searchTerms, CancellationToken cancellationToken)
    {
        var (usersEntities, totalCount) = await _userRepository
            .GetPaginatedAsync(
                pageNumber: pageNumber, 
                pageSize: pageSize,
                predicate: searchTerms != null ? x =>
                    x.FirstName.Contains(searchTerms) || x.LastName.Contains(searchTerms) : null,
                orderBy: x => x.OrderByDescending(x => x.CreatedAt),
                cancellationToken: cancellationToken);
        var usersWithPointsResponse = usersEntities
            .Select(userEntity =>
                new UserResponse(
                    userEntity.Id,
                    userEntity.FirstName,
                    userEntity.LastName,
                    userEntity.PointsCount));
        var paginatedResponse = new PaginatedData<UserResponse>(
            usersWithPointsResponse, totalCount);
        return await Result<PaginatedData<UserResponse>>.SuccessAsync(paginatedResponse);
    }

    public async Task<IResult> AddUserAsync(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var isExistByUserId = await _userRepository.IsExistByUserIdAsync(request.UserId, cancellationToken);
        if (isExistByUserId)
        {
            return await Result.SuccessAsync("Пользователь уже есть в системе!");
        }

        var userEntity = new UserEntity(request.UserId, request.FirstName, request.LastName);
        
        await _userRepository.AddAsync(userEntity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return await Result.SuccessAsync();
    }
}