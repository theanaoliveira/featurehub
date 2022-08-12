using FeatureHub.Domain.Hub;
using System.Linq.Expressions;

namespace FeatureHub.Application.Repositories.DataAccess
{
    public interface IFeatureRepository
    {
        List<Features> GetFeatures();
        Features GetFeatures(Expression<Func<Features, bool>> expression);
        void Update(Features features);
    }
}
