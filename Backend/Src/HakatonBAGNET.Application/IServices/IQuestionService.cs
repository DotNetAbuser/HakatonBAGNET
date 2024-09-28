namespace HakatonBAGNET.Application.IServices;

public interface IQuestionService
{
    Task<IResult<PaginatedData<QuestionResponse>>> GetPaginatedByCategoryId(
        int pageNumber, int pageSize,
        int categoryId, 
        CancellationToken cancellationToken);
}