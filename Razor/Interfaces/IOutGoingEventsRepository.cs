using Microsoft.AspNetCore.Mvc;
using Razor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razor.Interfaces
{
    public interface IOutGoingEventsRepository
    {
        Task<ActionResult<IEnumerable<OutGoingEvent>>> GetOutGoingEventsAsync();
        Task<ActionResult<string>> SaveOutGoingEventsAsync(OutGoingEvent outgoingEvent);
    }
}
