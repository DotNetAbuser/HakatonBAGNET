namespace HakatonBAGNET.Infra.Services;

public class QuestionService : IQuestionService
{
    private readonly IQuestionRepository _questionRepository;

    public QuestionService(
        IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }
    
    public async Task<IResult<PaginatedData<QuestionResponse>>> GetPaginatedByCategoryId(
        int pageNumber, int pageSize,
        int categoryId,
        CancellationToken cancellationToken)
    {
        var (questionsEntities, totalCount) = await _questionRepository
            .GetPaginatedAsync(
                pageNumber: pageNumber,
                pageSize: pageSize,
                predicate: c => c.CategoryId == categoryId,
                include: x => x.Include(q => q.Category),
                cancellationToken: cancellationToken);

        var questionsResponse = questionsEntities
            .Select(questionEntity => 
                new QuestionResponse(
                    questionEntity.Id,
                    questionEntity.Category.Title,
                    questionEntity.QuestionContent,
                    questionEntity.CorrectPointsCount,
                    questionEntity.IncorrectPointsCount,
                    questionEntity.IsModerated,
                    questionEntity.IsActive));
        var paginatedResponse = new PaginatedData<QuestionResponse>(
            questionsResponse, totalCount);
        return await Result<PaginatedData<QuestionResponse>>.SuccessAsync(paginatedResponse);
    }
}