using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace QnAMaker.Factory.Builder
{
    public static class QnAServicesCollectionExtension
    {
        /// <summary>
        /// Adds services required for using options 
        /// and QnAMakerFactory as a Singleton service to the collection if the service type hasn't already been registered.
        /// </summary>
        /// <param name="services"></param>
        /// <returns>QnAMakerFactoryBuilder, used to add supported languages.</returns>
        public static QnAMakerFactoryBuilder AddQnAMakerFactory(this IServiceCollection services)
        {
            services.AddOptions();
            services.TryAddSingleton<QnAMakerFactory>();
            return new QnAMakerFactoryBuilder(services);
        }
    }
}
