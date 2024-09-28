namespace HakatonBAGNET.Api.Controllers;

public class UserController : BaseController
{
    private readonly IUserService _userService;
    
    public UserController(
        IUserService userService) 
    {
        _userService = userService;
    }

    [HttpGet("get-paginated")]
    public async Task<IActionResult> GetPaginatedAsync(
        int pageNumber, int pageSize,
        string? searchTerms,
        CancellationToken cancellationToken = default)
    {
        return Ok(await _userService.GetPaginatedAsync(
            pageNumber, pageSize, searchTerms, cancellationToken));
    }
    
    [HttpGet("get-paginted-by-rating")]
    public async Task<IActionResult> GetPaginatedByRatingAsync(
        int pageNumber, int pageSize,
        CancellationToken cancellationToken = default)
    {
        return Ok(await _userService.GetPaginatedByRatingAsync(
            pageNumber, pageSize, cancellationToken));
    }

    [HttpPost("add-telegram-user")]
    public async Task<IActionResult> AddTelegramUserAsync(
        CreateUserRequest request,
        CancellationToken cancellationToken = default)
    {
        return Ok(await _userService.AddUserAsync(request, cancellationToken));
    }
    
}