namespace HakatonBAGNET.Domain.Configurations;

public class QuestionEntityConfiguration
    :IEntityTypeConfiguration<QuestionEntity>
{
    public void Configure(EntityTypeBuilder<QuestionEntity> builder)
    {
        builder.ToTable("questions");
        
        builder
            .HasQueryFilter(x => !x.IsDeleted);
        
        builder
            .HasKey(x => x.Id);
        
        builder
            .Property(x => x.Id)
            .HasColumnName("question_id")
            .IsRequired();
        
        builder
            .Property(x => x.CategoryId)
            .HasColumnName("category_id")
            .IsRequired();
        
        builder
            .Property(x => x.UserId)
            .HasColumnName("user_id")
            .IsRequired();
        
        builder
            .Property(x => x.QuestionContent)
            .HasColumnName("question_content")
            .IsRequired();
        
        builder
            .Property(x => x.CorrectPointsCount)
            .HasColumnName("correct_points_count")
            .IsRequired();
        
        builder
            .Property(x => x.IncorrectPointsCount)
            .HasColumnName("incorrect_points_count")
            .IsRequired();
        
        builder
            .Property(x => x.IsModerated)
            .HasColumnName("is_moderated")
            .IsRequired();
        
        builder
            .Property(x => x.IsActive)
            .HasColumnName("is_active")
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

        builder
            .HasOne<UserEntity>(x => x.User)
            .WithMany(x => x.CreatedQuestions)
            .HasForeignKey(x => x.UserId);
        builder
            .HasOne<CategoryEntity>(x => x.Category)
            .WithMany(x => x.Questions)
            .HasForeignKey(x => x.CategoryId);
    }
}