using Dating_app_final.Server.Data;
using Dating_app_final.Server.IRepository;
using Dating_app_final.Server.Models;
using Dating_app_final.Shared.Domin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Dating_app_final.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<Message> _messages;
        private IGenericRepository<User> _users;
        private IGenericRepository<Location> _locations;
        private IGenericRepository<Match> _matches;
        private IGenericRepository<Payment> _payments;
        private IGenericRepository<Subscription> _subscriptions;
        private IGenericRepository<Notify> _notifies;
        private IGenericRepository<BlockedUser> _blockedusers;


        private UserManager<ApplicationUser> _userManager;

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IGenericRepository<Message> Messages
            => _messages ??= new GenericRepository<Message>(_context);

        public IGenericRepository<User> Users
            => _users ??= new GenericRepository<User>(_context);

        public IGenericRepository<Location> Locations
            => _locations ??= new GenericRepository<Location>(_context);

        public IGenericRepository<Match> Matches
            => _matches ??= new GenericRepository<Match>(_context);
        public IGenericRepository<Payment> Payments
            => _payments ??= new GenericRepository<Payment>(_context);
        public IGenericRepository<Subscription> Subscriptions
            => _subscriptions ??= new GenericRepository<Subscription>(_context);

        public IGenericRepository<Notify>Notifies
            => _notifies ??= new GenericRepository<Notify>(_context);

        public IGenericRepository<BlockedUser> BlockedUsers
            => _blockedusers ??= new GenericRepository<BlockedUser>(_context);




        public IGenericRepository<BlockedUser> Blockedusers => throw new NotImplementedException();

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save(HttpContext httpContext)
        {
            //To be implemented
            string user = "System";

            var entries = _context.ChangeTracker.Entries()
                .Where(q => q.State == EntityState.Modified ||
                    q.State == EntityState.Added);
            await _context.SaveChangesAsync();
        }
    }
    }
   