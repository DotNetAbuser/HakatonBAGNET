namespace HakatonBAGNET.Api.Controllers;

public class QuestionController : BaseController
{

    private readonly IQuestionService _questionService;
    
    public QuestionController(
        IQuestionService questionService)
    {
        _questionService = questionService;
    }

    [HttpGet("get-paginated-by-category_id/{categoryId:int}")]
    public async Task<IActionResult> GetPaginatedByCategoryIdAsync(
        int pageNumber, int pageSize,
        int categoryId, 
        CancellationToken cancellationToken = default)
    {
        return Ok(await _questionService.GetPaginatedByCategoryId(pageNumber, pageSize, categoryId, cancellationToken));
    }

    [HttpGet("get-paginated-by-user-id/{userId:int}")]
    public async Task<IActionResult> GetPaginatedByUserId(
        int pageNumber, int pageSize,
        int userId, 
        CancellationToken cancellationToken = default)
    {
        return Ok(await _questionService.GetPaginatedByUserId(pageNumber, pageSize, userId, cancellationToken));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        CreateQuestionRequest request, 
        CancellationToken cancellationToken = default )
    {
        return Ok(await _questionService.CreateAsync(request, cancellationToken));
    }
    
    
    
}