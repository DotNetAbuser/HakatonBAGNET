namespace HakatonBAGNET.Models.Responses;

public record UserResponse(
    [property: JsonPropertyName("user_id")]
    int UserId,
    [property: JsonPropertyName("first_name")]
    string FirstName,
    [property: JsonPropertyName("last_name")]
    string LastName,
    [property: JsonPropertyName("points_counts")]
    int PointsCount);