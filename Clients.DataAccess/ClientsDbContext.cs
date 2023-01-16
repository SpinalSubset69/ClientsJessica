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

        //Tables on the DATABASE
        public DbSet<Bill> Bills { get; set; }
    }
}
