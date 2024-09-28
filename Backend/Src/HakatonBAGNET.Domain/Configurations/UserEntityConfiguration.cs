namespace HakatonBAGNET.Domain.Configurations;

public class UserEntityConfiguration
    : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("users");
        
        builder
            .HasQueryFilter(x => !x.IsDeleted);
        
        builder
            .HasKey(x => x.Id);
        
        builder
            .HasIndex(x => x.Id)
            .IsUnique();

        builder
            .Property(x => x.Id)
            .HasColumnName("user_id");
        
        builder
            .Property(x => x.FirstName)
            .HasColumnName("first_name");
        
        builder
            .Property(x => x.LastName)
            .HasColumnName("last_name");
        
        builder
            .Property(x => x.PointsCount)
            .HasColumnName("points_count");
        
        builder
            .Property(x => x.IsActive)
            .HasColumnName("is_active");
               
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

    private static IEnumerable<UserEntity> SeedData()
    {
        return new List<UserEntity>
        {
            new UserEntity(10000, "Сережа", "Батист"),
            new UserEntity(1, "Илья", "Олейник"),
            new UserEntity(2, "Кашелот", "Кашов"),
            new UserEntity(3, "Андрей", "Чуба"),
            new UserEntity(4, "Глеб", "Сергеев"),
            new UserEntity(5, "Анастасия", "Каторга"),
            new UserEntity(6, "Алена", "БэбиБон"),
            new UserEntity(7, "Маст", "Хэв"),
            new UserEntity(8, "Аленка", "Радушная"),
            new UserEntity(9, "Каша", "Бэбибонов"),
            new UserEntity(10, "Чупачупс", "Архангельский"),
            new UserEntity(11, "Кама", "Пуля"),
        };
    }
}