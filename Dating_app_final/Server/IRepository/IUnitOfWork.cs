using Dating_app_final.Shared.Domin;
using Dating_app_final.Server.IRepository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dating_app_final.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<Message> Messages { get; }
        IGenericRepository<User> Users { get; }

        IGenericRepository<Match> Matches { get; }

        IGenericRepository<Location> Locations { get; }

        IGenericRepository<Subscription> Subscriptions { get; }

        IGenericRepository<Notify> Notifies { get; }

        IGenericRepository<Payment> Payments { get; }
        IGenericRepository<BlockedUser> BlockedUsers { get; }



    }
}