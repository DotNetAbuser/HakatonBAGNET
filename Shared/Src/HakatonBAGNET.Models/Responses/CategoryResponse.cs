namespace HakatonBAGNET.Models.Responses;

public record CategoryResponse(
    [property: JsonPropertyName("category_id")]
    int CategoryId,
    [property: JsonPropertyName("title")]
    string Title);