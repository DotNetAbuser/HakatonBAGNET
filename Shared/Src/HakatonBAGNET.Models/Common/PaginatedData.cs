namespace HakatonBAGNET.Models.Common;

public record PaginatedData<TItem>(
    [property: JsonPropertyName("list")]
    IEnumerable<TItem> List,
    [property: JsonPropertyName("total_count")]
    int TotalCount);
