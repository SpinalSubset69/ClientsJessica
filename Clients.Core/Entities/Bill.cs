using Microsoft.EntityFrameworkCore;

namespace Clients.Core.Entities
{
    [Index(nameof(RFC), nameof(CURP), nameof(LastName))]
    public class Bill : BaseEntity
    {
        public string? RFC { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? CURP { get; set; }
    }
}
