namespace HakatonBAGNET.Models.Responses;

public record UserResponse(
    int UserId,
    string FirstName,
    string LastName,
    int PointsCount);