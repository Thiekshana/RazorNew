using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Razor.Interfaces;
using Razor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Razor.EventHandlers
{
    public class EventHandlerService : IIntegrationEventHandler
    {
        private readonly IOutGoingEventsRepository _outgoingEventsRepo;
        public event EventHandler ProcessCompleted;
        public async Task PostRecords()
        {
            //var endPoint = "http://localhost:5000/api/ServerEndPoint";
            //Outgoing modelOutgoing = new Outgoing(model.ProjectNumber, model.ProjectName, model.ElementNumber, model.ElementName);

            //string json = JsonConvert.SerializeObject(modelOutgoing);

            //using var httpClient = new HttpClient();
            //var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            //var respone = await httpClient.PostAsync(endPoint, stringContent);


            //if (respone.IsSuccessStatusCode)
            //{
            //    var id = await respone.Content.ReadAsStringAsync();

            //    var outGoingEventRecord = new OutGoingEvent(Guid.NewGuid(), json, "Processed", DateTimeOffset.Now, DateTimeOffset.Now);

            //    var record = await _outgoingEventsRepo.SaveOutGoingEventsAsync(outGoingEventRecord);

            //    Console.WriteLine($"Id {id} is Created!");
            //   // return Ok($"Id {id} is Created!");
            //}

            //else
            //{

            //    var expConverter = new ExpandoObjectConverter();
            //    var errorMessage = JsonConvert.DeserializeObject<dynamic>(respone.Content.ReadAsStringAsync().Result, expConverter);
            //    var errorvalues = Convert.ToString(errorMessage.errors);
            //    var outGoingEventRecord = new OutGoingEvent(Guid.NewGuid(), json, errorvalues, DateTimeOffset.Now, DateTimeOffset.Now);
            //    var record = await _outgoingEventsRepo.SaveOutGoingEventsAsync(outGoingEventRecord);
            //  //  return BadRequest(respone.Content.ReadAsStringAsync().Result);
            //}
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
