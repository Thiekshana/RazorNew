using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Razor.EventHandlers;
using Razor.Interfaces;
using Razor.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static Razor.Models.ErrorResponseModel;

namespace Razor.Controllers
{
    [Route("api/[controller]")]
    public class TaxPayerController : Controller
    {

        private readonly ITaxPayerRepository _taxPayers;
        private readonly IOutGoingEventsRepository _outgoingEventsRepo;
        private readonly ILogger _logger;
        //private readonly IIntegrationEventHandler _eventhandlerService;
        private readonly IEventHandlerService _eventHandlerService;
       public TaxPayerController(ITaxPayerRepository taxPayers, ILogger logger, IOutGoingEventsRepository outgoingEventsRepo, IEventHandlerService eventhandlerService)
        {
            _taxPayers = taxPayers;
            _logger = logger;
            _outgoingEventsRepo = outgoingEventsRepo;
            _eventHandlerService = eventhandlerService;
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("postData")]
        public async Task<IActionResult> Postjson([FromBody] Incoming model)
        {
  
            Outgoing modelOutgoing = new Outgoing(model.ProjectNumber, model.ProjectName, model.ElementNumber, model.ElementName);

            string json = JsonConvert.SerializeObject(modelOutgoing);

            await _eventHandlerService.postJson(json);

            return Ok();
 
        }

    }

}
