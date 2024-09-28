namespace HakatonBAGNET.Domain.Configurations;

public class AnswerEntityConfiguration 
    : IEntityTypeConfiguration<AnswerEntity>
{
    public void Configure(EntityTypeBuilder<AnswerEntity> builder)
    {
        builder.ToTable("answers");
        
        builder
            .HasQueryFilter(x => !x.IsDeleted);
        
        builder
            .HasKey(x => x.Id);
        
        builder
            .Property(x => x.Id)
            .HasColumnName("answer_id")
            .IsRequired();
        
        builder
            .Property(x => x.UserId)
            .HasColumnName("user_id")
            .IsRequired();
        
        builder
            .Property(x => x.QuestionId)
            .HasColumnName("question_id")
            .IsRequired();
        
        builder
            .Property(x => x.AnswerContent)
            .HasColumnName("answer_content")
            .IsRequired();
        
        builder
            .Property(x => x.IsModerated)
            .HasColumnName("is_moderated");
        
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

        // builder
        //     .HasOne<UserEntity>(x => x.User)
        //     .WithMany(x => x.AnsweredQuestions)
        //     .HasForeignKey(x => x.UserId);
        // builder
        //     .HasOne<QuestionEntity>(x => x.Question)
        //     .WithMany(x => x.Answeres)
        //     .HasForeignKey(x => x.QuestionId);
    }
}