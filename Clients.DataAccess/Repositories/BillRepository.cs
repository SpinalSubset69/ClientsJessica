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

        public async Task<IEnumerable<Bill>> GetAllAsync(Func<Bill, bool>? whereCluasule = null)
        {
            var query = _context.Bills;
            if(whereCluasule != null) query.Where(whereCluasule);
            return await query.ToListAsync();
        }

        public async Task<Bill?> GetElementAsync(Func<Bill, bool>? whereCluasule = null)
        {
            var query = _context.Bills;
            if (whereCluasule != null) query.Where(whereCluasule);
            return await query.FirstOrDefaultAsync();
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
