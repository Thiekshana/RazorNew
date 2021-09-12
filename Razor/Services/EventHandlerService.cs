using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Razor.Interfaces;
using Razor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Razor.Services
{
    public class EventHandlerService : IEventHandlerService, IIntegrationEventHandler
    {
        private readonly IOutGoingEventsRepository _outgoingEventsRepo;

        public EventHandlerService(IOutGoingEventsRepository outgoingEventsRepo)
        {
            _outgoingEventsRepo = outgoingEventsRepo;
        }

        public async Task postJson(string jsonData)
        {

            var endPoint = "http://localhost:5000/api/ServerEndPoint";
            using var httpClient = new HttpClient();
            var stringContent = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");

            var respone = await httpClient.PostAsync(endPoint, stringContent);


            if (respone.IsSuccessStatusCode)
            {
                var id = await respone.Content.ReadAsStringAsync();

                var outGoingEventRecord = new OutGoingEvent(Guid.NewGuid(), jsonData, "Processed", DateTimeOffset.Now, DateTimeOffset.Now);

                var record = await _outgoingEventsRepo.SaveOutGoingEventsAsync(outGoingEventRecord);

                Console.WriteLine($"Id {id} is Created!");
                // return Ok($"Id {id} is Created!");
            }

            else
            {

                var expConverter = new ExpandoObjectConverter();
                var errorMessage = JsonConvert.DeserializeObject<dynamic>(respone.Content.ReadAsStringAsync().Result, expConverter);
                var errorvalues = Convert.ToString(errorMessage.errors);
                var outGoingEventRecord = new OutGoingEvent(Guid.NewGuid(), jsonData, errorvalues, DateTimeOffset.Now, DateTimeOffset.Now);
                var record = await _outgoingEventsRepo.SaveOutGoingEventsAsync(outGoingEventRecord);
            }
        }
    }
}
