namespace HakatonBAGNET.Domain.Entities;

public class CategoryEntity : BaseEntity<int>
{
    internal CategoryEntity(
        int id,
        string title)
    {
        Id = id;
        Title = title;  
    }

    public CategoryEntity(
        string title)
    {
        Title = title;
    }
    
    public string Title { get; set; }

    public ICollection<QuestionEntity> Questions { get; } = [];
}