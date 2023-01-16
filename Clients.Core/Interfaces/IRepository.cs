using Clients.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clients.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T?> GetElementByIdAsync(Guid id);
        Task<T?> GetElementAsync(Func<Bill, bool>? whereCluasule = null);
        Task<IEnumerable<T>> GetAllAsync(Func<Bill, bool>? whereCluasule = null);
        void AddElement(T element);
        void RemoveElement(T element);
        Task SaveChangesAsync();
    }
}
