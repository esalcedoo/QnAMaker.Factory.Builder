using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.AI.QnA;
using Microsoft.Extensions.Options;
using System;

namespace QnAMaker.Factory.Builder
{
    public class QnAMakerFactory
    {
        private readonly QnAMakerFactoryOptions _options;
        private readonly IBotTelemetryClient _botTelemetryClient;

        public QnAMakerFactory(IOptions<QnAMakerFactoryOptions> options, IBotTelemetryClient botTelemetryClient)
        {
            _options = options.Value;
            _botTelemetryClient = botTelemetryClient;
        }

        /// <summary>
        /// Creates QnAMaker depending on the language with QnAMakerFactoryOptions provided
        /// </summary>
        /// <param name="lang">twoLetterISOCode</param>
        /// <returns></returns>
        public IQnAMakerClient GetQnAMaker(string lang)
        {
            if (string.IsNullOrEmpty(lang))
            {
                lang = "en";
            }
            if (!_options.Endpoints.ContainsKey(lang))
            {
                throw new ArgumentException($"QnAMaker '{lang}' language not registered", nameof(lang));
            }

            QnAMakerOptions qnAMakerOptions = new QnAMakerOptions();

            if (_options.MinScores.ContainsKey(lang))
            {
                qnAMakerOptions.ScoreThreshold = _options.MinScores[lang];
                qnAMakerOptions.Top = 5;
            }

            return new Microsoft.Bot.Builder.AI.QnA.QnAMaker(_options.Endpoints[lang], qnAMakerOptions, null, telemetryClient: _botTelemetryClient, logPersonalInformation: true);
        }
    }
}
