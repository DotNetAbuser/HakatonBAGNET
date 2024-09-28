namespace HakatonBAGNET.Models.Requests;

public class CreateCategoryRequest
{
    [JsonPropertyName("title")]
    public string Title { get; set; }
}