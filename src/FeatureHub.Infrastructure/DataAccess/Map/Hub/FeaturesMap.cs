using FeatureHub.Domain.Hub;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FeatureHub.Infrastructure.DataAccess.Map.Hub
{
    public class FeaturesMap : IEntityTypeConfiguration<Features>
    {
        public void Configure(EntityTypeBuilder<Features> builder)
        {
            builder.ToTable("Features", "Hub");
            builder.HasKey(k => k.Id);
        }
    }
}
