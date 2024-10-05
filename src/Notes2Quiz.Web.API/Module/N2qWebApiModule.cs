using Notes2Quiz.BL.Module;
using Notes2Quiz.Web.API.Controllers;

namespace Notes2Quiz.Web.API.Module
{
    public class N2qWebApiModule : IModule
    {
        public void RegisterTypes(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IQuizController, QuizController>();
        }
    }
}
