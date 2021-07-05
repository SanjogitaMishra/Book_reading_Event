
using BookReadingEventMVC.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadingEventMVC.Data
{
    public class EventsContext : IdentityDbContext
    {
        public EventsContext(DbContextOptions<EventsContext> options)
            : base(options)
        {

        }
        public DbSet<Event> Events { get; set; }

        public DbSet<Event_Comments> EventComments { get; set; }

        public DbSet<EventInvited> EventInviteds { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<EventInvitation> EventsInvitation { get; set; }
        public DbSet<Entities.User> Userss { get; set; }
    }
}
