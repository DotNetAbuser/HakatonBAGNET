using Microsoft.AspNetCore.Mvc;

namespace HakatonBAGNET.Api.Controllers.Base;

[ApiController]
[Route("api/[controller]")]
public class BaseController<TController> : ControllerBase
{
    protected readonly ILogger<TController> _logger;

    public BaseController(
        ILogger<TController> logger)
    {
        _logger = logger;
    }
}