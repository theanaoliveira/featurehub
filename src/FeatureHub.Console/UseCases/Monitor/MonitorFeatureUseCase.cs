using FeatureHub.Application.Repositories.DataAccess;
using FeatureHub.Domain.Hub;
using FeatureHubSDK;

namespace FeatureHub.Console.UseCases.Monitor
{
    public class MonitorFeatureUseCase : IMonitorFeatureUseCase
    {
        private readonly IFeatureHubConfig featureHubConfig;
        private readonly IFeatureRepository featureRepository;

        public MonitorFeatureUseCase(IFeatureHubConfig featureHubConfig, IFeatureRepository featureRepository)
        {
            this.featureHubConfig = featureHubConfig;
            this.featureRepository = featureRepository;
        }

        public void Execute()
        {
            if (!featureHubConfig.ServerEvaluation)
                throw new Exception("Service not started");
            else
            {
                var repository = featureHubConfig.Repository;
                var features = featureRepository.GetFeatures();

                features.ForEach(f => repository.GetFeature(f.Name).FeatureUpdateHandler += (object sender, IFeature holder) =>
                {
                    f.SetActive((bool)holder.Value);
                    featureRepository.Update(f);
                });
            }
        }
    }
}
