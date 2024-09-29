namespace HakatonBAGNET.Infra.Services;

public class QuestionService : IQuestionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IQuestionRepository _questionRepository;

    public QuestionService(
        IUnitOfWork unitOfWork,
        IQuestionRepository questionRepository)
    {
        _unitOfWork = unitOfWork;
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

    public async Task<IResult<PaginatedData<QuestionResponse>>> GetPaginatedByUserId(int pageNumber, int pageSize, int userId, CancellationToken cancellationToken)
    {
        var (questionsEntities, totalCount) = await _questionRepository
            .GetPaginatedAsync(
                pageNumber: pageNumber,
                pageSize: pageSize,
                predicate: c => c.UserId == userId,
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

    public async Task<IResult> CreateAsync(CreateQuestionRequest request, CancellationToken cancellationToken)
    {
        var questionEntity = new QuestionEntity(
            request.CategoryId,
            request.UserId, 
            request.QuestionContent,
            request.CorrectPointsCount,
            request.IncorrectPointsCount);
        
        await _questionRepository.AddAsync(questionEntity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return await Result.SuccessAsync();
    }
}