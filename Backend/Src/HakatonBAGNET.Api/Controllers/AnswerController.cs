namespace HakatonBAGNET.Api.Controllers;

public class AnswerController : BaseController
{
    private readonly IAnswerService _answerService;
    
    public AnswerController(
        IAnswerService answerService)
    {
        _answerService = answerService;
    }
    
    [HttpGet("get-paginated-by-user-id/{id:int}")]
    public async Task<IActionResult> GetPaginatedByUserIdAsync(
        int pageNumber, int pageSize,
        int id, 
        CancellationToken cancellationToken = default)
    {
        return Ok(await _answerService.GetPaginatedByUserIdAsync(
            pageNumber, pageSize, id, cancellationToken));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        CreateAnswerRequest request,
        CancellationToken cancellationToken = default)
    {
        return Ok(await _answerService.CreateAsync(request, cancellationToken));
    }
    
}