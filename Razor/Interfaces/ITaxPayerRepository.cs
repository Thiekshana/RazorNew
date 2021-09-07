using Razor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razor.Interfaces
{
    public interface ITaxPayerRepository
    {
        Task<List<TaxPayer>> GetAllTaxPayersAsync();
        Task<TaxPayer> GetTaxPayerByIdAsync(int id);
        Task<TaxPayer> GetTaxPayerByNameAsync(string name);
        Task<List<TaxPayer>> DownloadAllTaxPayerInfo();
    }
}
