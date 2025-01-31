namespace StudentPortal.Data.Models.Entities
{
    public class BankDetails
    {
        public Guid Id { get; set; }
        public DateOnly? Date { get; set; }
        public string? TransactionId { get; set; }
        public decimal? Credit { get; set; }
        public decimal? Debit { get; set; }
        public decimal? Balance { get; set; }
    }
}
