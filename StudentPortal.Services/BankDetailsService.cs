using StudentPortal.Data.Models.Entities;
using StudentPortal.Services.DTOs;
using StudentPortal.Services;
using StudentPortal.Web.data;
using Microsoft.AspNetCore.Http;
using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;

public class BankDetailsService : IBankDetailsService
{
    private readonly ApplicationDbContext _applicationDbContext;

    public BankDetailsService(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task SaveBankDetailsAsync(IFormFile file)
    {

        using StreamReader reader = new StreamReader(file.OpenReadStream());
        using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true
        });

        var records = csv.GetRecords<BankDTO>().ToList();

        foreach (var record in records)
        {
            var exsitingBankDetals = _applicationDbContext.BankDetails.Any(x => x.Date == record.Date && x.TransactionId == record.TransactionId);

            if(exsitingBankDetals)
            {
                continue;
            }

            var bank = new BankDetails
            {
                Date = record.Date,
                Id = Guid.NewGuid(),
                TransactionId = record.TransactionId,
                Credit = record.Credit,
                Debit = record.Debit,
                Balance = record.Balance,
            };

            await _applicationDbContext.BankDetails.AddAsync(bank);
            await _applicationDbContext.SaveChangesAsync();
           
        }
      
        
            
    }
      
}
