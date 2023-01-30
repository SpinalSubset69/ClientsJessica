using Clients.Core.Entities;
using Clients.Core.Interfaces;
using Clients.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clients.DataAccess.Repositories
{
    public class MailRepository : IMailRepository
    {
        private readonly ClientsDbContext _context;

        public MailRepository(ClientsDbContext context)
        {
            _context = context;
        }

        public void AddElement(Mail element)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Mail>> GetAllAsync()
        {
            return await _context.Mails.ToListAsync();
        }

        public Task<Mail?> GetElementAsync(Func<Bill, bool>? whereCluasule = null)
        {
            throw new NotImplementedException();
        }

        public Task<Mail?> GetElementByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void RemoveElement(Mail element)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        Task<List<Mail>> IRepository<Mail>.GetElementAsync(Func<Bill, bool>? whereCluasule)
        {
            throw new NotImplementedException();
        }
    }
}
