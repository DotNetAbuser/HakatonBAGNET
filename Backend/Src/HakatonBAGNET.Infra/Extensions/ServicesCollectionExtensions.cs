namespace HakatonBAGNET.Infra.Extensions;

public static class ServicesCollectionExtensions
{
    public static void AddUnitOfWork(this IServiceCollection services)
    {
        services
            .AddTransient<IUnitOfWork, UnitOfWork>();
    }
    
    public static void AddRepositories(this IServiceCollection services)
    {
        services
            .AddTransient<ICategoryRepository, CategoryRepository>()
            .AddTransient<IUserRepository, UserRepository>()
            .AddTransient<IAnswerRepository, AnswerRepository>()
            .AddTransient<IQuestionRepository, QuestionRepository>()
            .AddTransient<IReactionRepository, ReactionRepository>();
    }

    public static void AddServices(this IServiceCollection services)
    {
        services
            .AddTransient<ICategoryService, CategoryService>()
            .AddTransient<IUserService, UserService>()
            .AddTransient<IAnswerService, AnswerService>()
            .AddTransient<IQuestionService, QuestionService>()
            .AddTransient<IReactionService, ReactionService>();
    }
}