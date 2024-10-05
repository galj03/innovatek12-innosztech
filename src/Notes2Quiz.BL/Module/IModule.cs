using Microsoft.Extensions.DependencyInjection;

namespace Notes2Quiz.BL.Module
{
    public interface IModule
    {
        void RegisterTypes(IServiceCollection serviceCollection);
    }
}
