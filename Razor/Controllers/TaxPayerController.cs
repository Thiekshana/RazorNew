using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Razor.Interfaces;
using Razor.Models;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Razor.Controllers
{
    [Route("api/[controller]")]
    public class TaxPayerController : Controller
    {

        private readonly ITaxPayerRepository _taxPayers;
        private readonly ILogger _logger;
        public TaxPayerController(ITaxPayerRepository taxPayers, ILogger logger)
        {
            _taxPayers = taxPayers;
            _logger = logger;
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

        [HttpPost]
        [Route("postData")]
        public async Task<IActionResult> Postjson([FromBody] Incoming model)
        {

            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //try
            //{
            Outgoing modelOutgoing = new Outgoing(model.Id, model.ProjectName, model.ProjectName, model.ElementNumber, model.ElementName);

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters =
                {
                    new CustomJsonConverter()
                }
                };
                options.Converters.Add(new CustomJsonConverter());
                return Ok();

            //}

            //catch (Exception ex)
            //{
            //    _logger.LogError($"Error Message: { ex.Message}");
            //    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            //}


            

        }


    }
}
