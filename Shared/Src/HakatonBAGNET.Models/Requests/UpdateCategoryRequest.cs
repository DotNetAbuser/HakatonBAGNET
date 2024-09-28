namespace HakatonBAGNET.Models.Requests;

public class UpdateCategoryRequest
{
    [JsonPropertyName("title")]
    public string Title { get; set; }
}