using Microsoft.Extensions.DependencyInjection;
using Notes2Quiz.BL.Application;
using Notes2Quiz.BL.Impl.Application;
using Notes2Quiz.BL.Impl.Models.Factories;
using Notes2Quiz.BL.Impl.Services;
using Notes2Quiz.BL.Models.Factories;
using Notes2Quiz.BL.Module;
using Notes2Quiz.BL.Services;

namespace Notes2Quiz.BL.Impl.Module
{
    public class BusinessLogicModule : IModule
    {
        public void RegisterTypes(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IQuizService, QuizService>();
            serviceCollection.AddTransient<IUserService, UserService>();

            serviceCollection.AddTransient<IUserFactory, UserFactory>();

            serviceCollection.AddTransient<IApplicationSettings, ApplicationSettings>();
        }
    }
}
