using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Razor.Interfaces;
using Razor.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Razor.Repository
{
    public class OutGoingEventsRepository : IOutGoingEventsRepository
    {
        private readonly AppDbContext _context;

        public OutGoingEventsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<OutGoingEvent>>> GetOutGoingEventsAsync()
        {
            return await _context.OutGoingEvent.ToListAsync();
        }

        public async Task<ActionResult<string>> SaveOutGoingEventsAsync(OutGoingEvent outgoingEvent)
        {
            _context.Add(outgoingEvent);
            await _context.SaveChangesAsync();
            return outgoingEvent.Id.ToString();
        }
    }
}
