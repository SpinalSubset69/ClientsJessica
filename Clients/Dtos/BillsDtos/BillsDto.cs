namespace Clients.Dtos.BillsDtos
{
    public class BillsDto
    {
        public Guid Id { get; set; }
        public string? RFC { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? CURP { get; set; }
    }
}
