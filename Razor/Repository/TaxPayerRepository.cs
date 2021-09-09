using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using IronPdf;
using Microsoft.EntityFrameworkCore;
using Razor.Interfaces;
using Razor.Models;

namespace Razor.Repository
{
    public class TaxPayerRepository : ITaxPayerRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IViewRenderService _viewRenderService;

        public TaxPayerRepository(AppDbContext dbContext, IViewRenderService viewRenderService)
        {
            _dbContext = dbContext;
            _viewRenderService = viewRenderService;
        } 

         public async Task<List<TaxPayer>> GetAllTaxPayersAsync()
        {
            return await _dbContext.TaxPayers.ToListAsync();
        }

        public async Task<TaxPayer> GetTaxPayerByIdAsync(int id)
        {
            return await _dbContext.TaxPayers.FirstOrDefaultAsync(payers => payers.Id == id);
        }

        public async Task<TaxPayer> GetTaxPayerByNameAsync(string name)
        {
            return await _dbContext.TaxPayers.FirstOrDefaultAsync(payers => payers.PlayerName.Contains(name));
        }

        public async Task<List<TaxPayer>> DownloadAllTaxPayerInfo()
        {
            var taxPayerInfo = await _dbContext.TaxPayers.ToListAsync();
            var result = await _viewRenderService.RenderToStringAsync("Home/Index", taxPayerInfo);
            var Renderer = new HtmlToPdf();
            Renderer.RenderHtmlAsPdf(result).SaveAs("test.pdf");
            return taxPayerInfo;
        }


    }
}
