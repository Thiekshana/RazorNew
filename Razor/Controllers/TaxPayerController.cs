using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Razor.Interfaces;
using Razor.Models;
using System;
using System.Net.Http;
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
            var endPoint = "http://localhost:5000/api/ServerEndPoint";
            Outgoing modelOutgoing = new Outgoing(model.ProjectNumber, model.ProjectName, model.ElementNumber, model.ElementName);

            string json = JsonConvert.SerializeObject(modelOutgoing);

            using var httpClient = new HttpClient();
            var stringContent = new StringContent(json, System.Text.Encoding.UTF8,"application/json");

            var respone = await httpClient.PostAsync(endPoint, stringContent);

            if(respone.IsSuccessStatusCode)
            {
                var id = await respone.Content.ReadAsStringAsync();
                Console.WriteLine($"Id {id} is Created!");
                return Ok($"Id {id} is Created!");
            }

            else
            {
                return BadRequest(respone.Content.ReadAsStringAsync().Result);
            }
                //var options = new JsonSerializerOptions
                //{
                //    WriteIndented = true,
                //    Converters =
                //{
                //    new CustomJsonConverter()
                //}
                //};
                //options.Converters.Add(new CustomJsonConverter());

        }


    }
}
