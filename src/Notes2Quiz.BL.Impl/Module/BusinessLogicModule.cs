using Microsoft.Extensions.DependencyInjection;
using Notes2Quiz.BL.Impl.Services;
using Notes2Quiz.BL.Module;
using Notes2Quiz.BL.Services;

namespace Notes2Quiz.BL.Impl.Module
{
    public class BusinessLogicModule : IModule
    {
        public void RegisterTypes(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IQuizService, QuizService>();
            serviceCollection.AddTransient<IAuthService, AuthService>();

            //TODO: factories, etc.
        }
    }
}
