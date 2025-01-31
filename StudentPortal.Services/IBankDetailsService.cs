using Microsoft.AspNetCore.Http;

namespace StudentPortal.Services
{
    public interface IBankDetailsService
    {
        Task SaveBankDetailsAsync(IFormFile file);
    }
}
