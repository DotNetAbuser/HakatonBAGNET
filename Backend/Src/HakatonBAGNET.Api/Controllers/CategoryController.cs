namespace HakatonBAGNET.Api.Controllers;

public class CategoryController : BaseController
{
    private readonly ICategoryService _categoryService;
    
    public CategoryController(
        ILogger<CategoryController> logger,
        ICategoryService categoryService) 
    {
        _categoryService = categoryService;
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return Ok(await _categoryService.GetAllAsync(cancellationToken));
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCategoryByIdAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        return Ok(await _categoryService.GetByIdAsync(id, cancellationToken));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        CreateCategoryRequest request,
        CancellationToken cancellationToken = default)
    {
        return Ok(await _categoryService.CreateAsync(request, cancellationToken));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync(
        int id, UpdateCategoryRequest request, 
        CancellationToken cancellationToken = default)
    {
        return Ok(await _categoryService.UpdateAsync(id, request, cancellationToken));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(
        int id, 
        CancellationToken cancellationToken = default)
    {
        return Ok(await _categoryService.DeleteAsync(id, cancellationToken));
    }
    
}
