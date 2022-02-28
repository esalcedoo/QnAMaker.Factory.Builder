using Microsoft.Bot.Builder.AI.QnA;
using System.Collections.Generic;

namespace QnAMaker.Factory.Builder
{
    public class QnAMakerFactoryOptions
    {
        /// <summary>
        /// Dictionary where keys are languages in twoLetterISOCode and values their associate QnAMakerEndpoint
        /// </summary>
        public Dictionary<string, QnAMakerEndpoint> Endpoints { get; } = new Dictionary<string, QnAMakerEndpoint>();

        /// <summary>
        /// Dictionary where keys are languages in twoLetterISOCode and values their associate minimum Score threshold
        /// </summary>
        public Dictionary<string, float> MinScores { get; } = new Dictionary<string, float>();
    }
}
