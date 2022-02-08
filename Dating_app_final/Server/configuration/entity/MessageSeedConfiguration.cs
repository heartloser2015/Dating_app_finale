using Dating_app_final.Shared.Domin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dating_app_final.Server.Areas.configuration.entity
{
    public class MessageSeedConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasData(
                new Message
                {
                    Id = 1,
                    Message_content = "joeys",
                    Message_timestamp = DateTime.Now,
                    Message_read = "Read"
                },
                new Message
                {
                    Id = 2,
                    Message_content = "joey",
                    Message_timestamp = DateTime.Now,
                    Message_read = "Not Read"
                });
        }
    }
}
