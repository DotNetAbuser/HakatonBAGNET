namespace HakatonBAGNET.Domain.Configurations;

public class ReactionEntityConfiguration
    : IEntityTypeConfiguration<ReactionEntity>
{
    public void Configure(EntityTypeBuilder<ReactionEntity> builder)
    {
        builder.ToTable("reactions");
        
        builder
            .HasQueryFilter(x => !x.IsDeleted);
        
        builder
            .HasKey(x => x.Id);
        
        builder
            .Property(x => x.UserId)
            .HasColumnName("user_id")
            .IsRequired();
        
        builder
            .Property(x => x.QuestionId)
            .HasColumnName("question_id")
            .IsRequired();
        
        builder
            .Property(x => x.AnswerId)
            .HasColumnName("answer_id")
            .IsRequired();

        builder
            .Property(x => x.IsLiked)
            .HasColumnName("is_liked");
         
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
        //     .WithMany(x => x.CreatedReactionsByUser)
        //     .HasForeignKey(x => x.UserId);
        // builder
        //     .HasOne<QuestionEntity>(x => x.Question)
        //     .WithMany(x => x.Reactions)
        //     .HasForeignKey(x => x.QuestionId);
        // builder
        //     .HasOne<AnswerEntity>(x => x.Answer)
        //     .WithMany(x => x.Reactions)
        //     .HasForeignKey(x => x.AnswerId);
    }
}