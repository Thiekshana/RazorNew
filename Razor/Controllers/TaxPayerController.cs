using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Razor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razor.Controllers
{
    [Route("api/[controller]")]
    public class TaxPayerController : Controller
    {

        private readonly ITaxPayerRepository _taxPayers;

        public TaxPayerController(ITaxPayerRepository taxPayers)
        {
            _taxPayers = taxPayers;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTaxPayersAsync()
        {
            var result= await _taxPayers.GetAllTaxPayersAsync();
            return Ok(result);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTaxPayerByIdAsync(int id)
        {
            var result = await _taxPayers.GetTaxPayerByIdAsync(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("name")]
        public async Task<IActionResult> GetTaxPayerByNameAsync([FromQuery] string name)
        {
            var result = await _taxPayers.GetTaxPayerByNameAsync(name);
            return Ok(result);
        }


        [HttpGet]
        [Route("download")]
        public async Task<IActionResult> DownloadAllTaxPayerInfo()
        {
            var result = await _taxPayers.DownloadAllTaxPayerInfo();
            return Ok(result);
        }

    }
}
