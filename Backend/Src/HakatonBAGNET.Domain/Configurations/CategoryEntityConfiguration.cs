namespace HakatonBAGNET.Domain.Configurations;

public class CategoryEntityConfiguration
    : IEntityTypeConfiguration<CategoryEntity>
{
    public void Configure(EntityTypeBuilder<CategoryEntity> builder)
    {
        builder.ToTable("categories");
        
        builder
            .HasQueryFilter(x => !x.IsDeleted);
        
        builder
            .HasKey(x => x.Id);

        
        builder
            .Property(x => x.Id)
            .HasColumnName("category_id")
            .IsRequired();
        
        builder
            .HasIndex(x => x.Title)
            .IsUnique()
            .HasFilter("is_deleted IS NULL");
        builder
            .Property(x => x.Title)
            .HasMaxLength(64)
            .HasColumnName("title")
            .IsRequired();
        
        builder
            .Property(x => x.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();
        builder
            .Property(x => x.UpdatedAt)
            .HasColumnName("updated_at")
            .IsRequired(false);
        builder
            .Property(x => x.IsDeleted)
            .HasColumnName("is_deleted");
        builder
            .Property(x => x.DeletedAt)
            .HasColumnName("deleted_at")
            .IsRequired(false);

        builder.HasData(SeedData());
    }

    private static IEnumerable<CategoryEntity> SeedData() =>
        new List<CategoryEntity>
        {
            new CategoryEntity(1, "Математический анализ"),
            new CategoryEntity(2, "Линейная алгебра"),
            new CategoryEntity(3, "Философия"),
            new CategoryEntity(4, "История России"),
            new CategoryEntity(5, "Физика")
        };
}