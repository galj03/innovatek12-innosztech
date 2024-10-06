using Microsoft.Extensions.DependencyInjection;

namespace Notes2Quiz.BL.Module
{
    /// <summary>
    /// This class is a module abstraction used for implementing dependency inversion.
    /// </summary>
    public interface IModule
    {
        /// <summary>
        /// Registers the required types from a module.
        /// </summary>
        /// <param name="serviceCollection">The service collection instance.</param>
        void RegisterTypes(IServiceCollection serviceCollection);
    }
}
