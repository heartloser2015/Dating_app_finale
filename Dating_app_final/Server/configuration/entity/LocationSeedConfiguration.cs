using Dating_app_final.Shared.Domin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dating_app_final.Server.Areas.configuration.entity
{
    public class LocationSeedConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasData(
                new Location
                {
                    Id = 1,
                    Location_Gps = "Black",
                },
                new Location
                {
                    Id = 2,
                    Location_Gps = "Blue",
                        
                }
                );
        }
    }
}