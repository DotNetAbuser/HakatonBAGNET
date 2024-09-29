namespace HakatonBAGNET.Application.IServices;

public interface IAnswerService
{
    Task<IResult<PaginatedData<AnswerResponse>>> GetPaginatedByUserIdAsync(
        int pageNumber, int pageSize, int id, CancellationToken cancellationToken);

    Task<IResult> CreateAsync(CreateAnswerRequest request, CancellationToken cancellationToken);
}