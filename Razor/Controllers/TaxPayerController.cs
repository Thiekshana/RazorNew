using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Razor.Interfaces;
using Razor.Models;
using System.Text.Json;
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

        [HttpPost]
        [Route("postData")]
        public async Task<IActionResult> Postjson()
        {
            var content = @"{""Id"": 1,""ProjectNumber"": ""5"",""ProjectName"": ""fdsfjhgjhkre"",""ElementNumber"": 45,""ElementName"": ""Element 1""}";


            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters =
                {
                    new CustomJsonConverter()
                }
            };
            options.Converters.Add(new CustomJsonConverter());
            Outgoing model = JsonSerializer.Deserialize<Outgoing>(content, options);
            //Outgoing outgoingModel = new Outgoing(model.Id, model.ProjectNumber, model.ProjectName, model.ElementNumber, model.ElementName);

            //string json = JsonSerializer.Serialize(outgoingModel);

            return Ok();
        }


    }
}
