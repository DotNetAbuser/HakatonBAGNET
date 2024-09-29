namespace HakatonBAGNET.Infra.Services;

public class AnswerService : IAnswerService
{
    private IUnitOfWork _unitOfWork;
    private readonly IAnswerRepository _answerRepository;
    
    public AnswerService(
        IUnitOfWork unitOfWork,
        IAnswerRepository answerRepository)
    {
        _unitOfWork = unitOfWork;
        _answerRepository = answerRepository;
    }
    
    public async Task<IResult<PaginatedData<AnswerResponse>>> GetPaginatedByUserIdAsync(
        int pageNumber, int pageSize,
        int id,
        CancellationToken cancellationToken)
    {
        var (answersEntities, totalCount) = await _answerRepository
            .GetPaginatedAsync(
                pageNumber: pageNumber,
                pageSize: pageSize, 
                predicate: a => a.UserId == id,
                include: x =>
                    x.Include(a => a.Question)
                        .ThenInclude(q => q.User)
                    .Include(x => x.User),
                cancellationToken: cancellationToken);
        var answersResponse = answersEntities
            .Select(answerEntity =>
                new AnswerResponse(
                    answerEntity.Question.User.FirstName + " " + answerEntity.Question.User.LastName,
                    answerEntity.User.FirstName + " " +answerEntity.User.LastName,
                    answerEntity.Question.QuestionContent,
                    answerEntity.AnswerContent,
                    answerEntity.IsModerated,
                    answerEntity.IsActive));

        var paginatedResponse = new PaginatedData<AnswerResponse>(
            answersResponse, totalCount);
        return await Result<PaginatedData<AnswerResponse>>.SuccessAsync(paginatedResponse);
    }

    public async Task<IResult> CreateAsync(CreateAnswerRequest request, CancellationToken cancellationToken)
    {
        var answerEntity = new AnswerEntity(
            request.UserId,
            request.QuestionId,
            request.AnswerContent);
        
        await _answerRepository.AddAsync(answerEntity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return await Result.SuccessAsync();
    }
}