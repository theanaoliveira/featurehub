using FeatureHubSDK;

namespace FeatureHub.Console.UseCases.Sum
{
    public class SumUseCase : ISumUseCase
    {
        private readonly IFeatureHubConfig featureHubConfig;

        public SumUseCase(IFeatureHubConfig featureHubConfig)
        {
            this.featureHubConfig = featureHubConfig;
        }

        public int Sum(int value1, int value2)
        {
            if (!featureHubConfig.ServerEvaluation)
                throw new Exception("Service not started");

            var context = featureHubConfig.NewContext().Build().Result;
            var feature = context["soma"].BooleanValue ?? false;

            if (feature)
                return (value1 + value2);
            else
                throw new Exception("Feature was disabled");
        }
    }
}
