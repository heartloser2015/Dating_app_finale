using Dating_app_final.Server.Areas.configuration.entity;
using Dating_app_final.Server.Models;
using Dating_app_final.Shared.Domin;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dating_app_final.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Match> Match { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Notify> Notify { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Payment> Subscription { get; set; }

        public DbSet<BlockedUser> BlockedUser { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new LocationSeedConfiguration());
            builder.ApplyConfiguration(new MessageSeedConfiguration());



        }
    }
    }

