namespace HakatonBAGNET.Application.IServices;

public interface IQuestionService
{
    Task<IResult<PaginatedData<QuestionResponse>>> GetPaginatedByCategoryId(
        int pageNumber, int pageSize,
        int categoryId, 
        CancellationToken cancellationToken);
    Task<IResult<PaginatedData<QuestionResponse>>> GetPaginatedByUserId(
        int pageNumber, int pageSize, int userId, CancellationToken cancellationToken);


    Task<IResult> CreateAsync(CreateQuestionRequest request, CancellationToken cancellationToken);
}