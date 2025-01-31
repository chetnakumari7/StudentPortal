using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPortal.Services.DTOs
{
    public class BankDTO
    {
        public DateOnly? Date { get; set; }
        public int? Id { get; set; }
        public string? TransactionId { get; set; }
        public decimal? Credit { get; set; }
        public decimal? Debit { get; set; }
        public decimal? Balance { get; set; }

    }
}
