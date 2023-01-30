using Clients.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clients.Core.Interfaces
{
    public interface IExcel
    {
        string CreateExcel(List<Bill> lst);
    }
}
