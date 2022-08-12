using FeatureHub.Infrastructure.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FeatureHub.Api.Filters
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class FeaturesAttribute : ActionFilterAttribute
    {
        private string feature;

        public FeaturesAttribute(string featuresNames)
        {
            feature = featuresNames;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var features = new FeatureRepository().GetFeatures(w => w.Name.ToUpper().Equals(feature.ToUpper()));

            if (features is null || !features.Active)
            {
                context.Result = new NotFoundObjectResult("");
            }
        }
    }
}
