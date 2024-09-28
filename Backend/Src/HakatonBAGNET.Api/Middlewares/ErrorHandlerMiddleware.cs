namespace HakatonBAGNET.Api.Middlewares;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next) => _next = next;

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            var responseModel = await Result<string>.FailAsync(error.Message);

            response.StatusCode = error switch
            {
                _ => (int)HttpStatusCode.InternalServerError
            };

            var result = JsonSerializer.Serialize(responseModel);
            await response.WriteAsync(result);
        }
    }

}