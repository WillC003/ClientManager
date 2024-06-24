using Microsoft.EntityFrameworkCore;
using ClientManager.Models;

namespace ClientManager.Data
{
    public class ClientContext : DbContext
    {
        public ClientContext( DbContextOptions<ClientContext> options) :base(options)
        { 
        }
         public DbSet<User> Users { get; set; }
         public DbSet<Client> Client { get; set; }
         public DbSet<Gym> Gym { get; set; }
         public DbSet<ClientNotes> ClientNotes { get; set; }
         public DbSet<Membership> Memberships { get; set; }
         public DbSet<Membership_Status> MembershipStatus { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

        }

    }
}
