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
        #region Inherited members
        public void RegisterTypes(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IQuizService, SingleChoiceQuestionQuizService>();
            serviceCollection.AddTransient<IAuthService, AuthService>();

            serviceCollection.AddTransient<IApplicationSettings, ApplicationSettings>();

            serviceCollection.AddTransient<IQuizFactory, QuizFactory>();
            serviceCollection.AddTransient<IQuestionFactory, QuestionFactory>();
            serviceCollection.AddTransient<IByteParserService, OcrByteParserService>();//TODO: caution, not implemented
        }
        #endregion
    }
}
