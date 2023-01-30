namespace Clients.Dtos.BillsDtos
{
    public class BillsDto
    {
        public Guid Id { get; set; }
        public string? Reason { get; set; } //name of "doctor"
        public string? RFC { get; set; }
        public string? Name { get; set; }
        public string? FirstLastName { get; set; }
        public string? SecondLastName { get; set; }
        public string? CURP { get; set; }
        public string? CP { get; set; }
        public int Number { get; set; }
        public string? Street { get; set; }
        public string? Sector { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime Created { get; set; }
        public string? PaymentMethod { get; set; }
        public string? TaxRegime { get; set; }
        public string? CFDI { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
    }
}
