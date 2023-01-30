using Clients.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clients.DataAccess
{
    public class ClientsDbContext : DbContext
    {
        public ClientsDbContext(DbContextOptions<ClientsDbContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>()
                .Property(p => p.Created)
                .HasDefaultValue(DateTime.UtcNow);

            modelBuilder.Entity<Bill>()
                .Property(p => p.Amount)
                .HasColumnType("decimal(30,6)");
        }

        //Tables on the DATABASE
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Mail> Mails { get; set; }
    }
}
