namespace HakatonBAGNET.Api.Controllers;

public class QuestionController : BaseController
{

    private readonly IQuestionService _questionService;
    
    public QuestionController(
        IQuestionService questionService)
    {
        _questionService = questionService;
    }

    [HttpGet("get-paginated-by-category_id/{categoryId}")]
    public async Task<IActionResult> GetPaginatedByCategoryIdAsync(
        int pageNumber, int pageSize,
        int categoryId, 
        CancellationToken cancellationToken = default)
    {
        return Ok(await _questionService.GetPaginatedByCategoryId(pageNumber, pageSize, categoryId, cancellationToken));
    }
}