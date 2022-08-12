using FeatureHub.Application.Repositories.DataAccess;
using FeatureHub.Domain.Hub;
using System.Linq.Expressions;

namespace FeatureHub.Infrastructure.DataAccess.Repositories
{
    public class FeatureRepository : IFeatureRepository
    {
        public List<Features> GetFeatures()
        {
            using var context = new Context();

            return context.Features.ToList();
        }

        public Features GetFeatures(Expression<Func<Features, bool>> expression)
        {
            using var context = new Context();

            return context.Features.Where(expression).FirstOrDefault();
        }

        public void Update(Features features)
        {
            using var context = new Context();

            context.Update(features);
            context.SaveChanges();
        }
    }
}
