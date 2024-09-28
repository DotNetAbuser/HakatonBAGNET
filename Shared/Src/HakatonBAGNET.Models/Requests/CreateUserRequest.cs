namespace HakatonBAGNET.Models.Requests;

public class CreateUserRequest
{
    [JsonPropertyName("user_id")]
    public int UserId { get; set; }
    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }
    [JsonPropertyName("last_name")]
    public string LastName { get; set; }
}