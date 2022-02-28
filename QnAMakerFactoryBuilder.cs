using Microsoft.Bot.Builder.AI.QnA;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace QnAMaker.Factory.Builder
{
    public class QnAMakerFactoryBuilder
    {
        public QnAMakerFactoryBuilder(IServiceCollection serviceCollection)
        {
            Services = serviceCollection;
        }

        public IServiceCollection Services { get; }

        /// <summary>
        /// QnAMaker Factory Builder adds new language and their associate QnAMakerEndpoint
        /// </summary>
        /// <param name="lang">twoLetterISOCode</param>
        /// <param name="qnAMakerEndpoint"></param>
        /// <returns></returns>
        public QnAMakerFactoryBuilder AddLanguage(string lang, QnAMakerEndpoint qnAMakerEndpoint)
        {
            if (qnAMakerEndpoint is null)
            {
                throw new ArgumentNullException(nameof(qnAMakerEndpoint));
            }

            Services.Configure<QnAMakerFactoryOptions>(options =>
            {
                if (options.Endpoints.TryAdd(lang, qnAMakerEndpoint))
                {
                    options.Endpoints[lang] = qnAMakerEndpoint;
                }
            });
            return this;
        }
    }
}
