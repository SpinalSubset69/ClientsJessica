using Clients.Core.Entities;

namespace Clients.Core.Interfaces.Repositories
{
    public interface IBillRepository : IRepository<Bill>
    {
        public Task<Bill?> GetByRFCAsync(string RFC);
    }
}
