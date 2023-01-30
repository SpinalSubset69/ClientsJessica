using Clients.Core.Entities;
using Clients.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Clients.DataAccess.Repositories
{
    public class BillRepository : IBillRepository
    {
        private ClientsDbContext _context;        

        public BillRepository(ClientsDbContext context)
        {
            _context = context;

        }

        public void AddElement(Bill element)
        {            
            _context.Add(element);            
        }

        public async Task<IEnumerable<Bill>> GetAllAsync()
        {            
            return await _context.Bills.ToListAsync();
        }

        public async Task<Bill?> GetByRFCAsync(string RFC)
        {
            return await _context.Bills.Where(x => x.RFC == RFC).FirstOrDefaultAsync();
        }

        public async Task<List<Bill>> GetElementAsync(Func<Bill, bool> whereCluasule)
        {
            var query = await _context.Bills.ToListAsync();           
            return query.Where(whereCluasule).ToList();
        }

        public async Task<Bill?> GetElementByIdAsync(Guid id)
        {
            return await _context.Bills.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public void RemoveElement(Bill element)
        {
            _context.Bills.Remove(element);            
        }

        /// <summary>
        /// To save changes on DB After Insert, Update and Delete Methods
        /// </summary>
        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
