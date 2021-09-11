using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Razor.Interfaces;
using Razor.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Razor.Repository
{
    public class ProjectRepository: IProjectRepository
    {
        private readonly AppDbContext _context;

        public ProjectRepository(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<ActionResult<IEnumerable<Project>>> GetProjectRecords()
        {
            return await _context.ProjectRecords.ToListAsync();
        }

        public async Task<ActionResult<int>> SaveProjectRecords(Project project)
        {
            _context.Add(project);
            await _context.SaveChangesAsync();
            return project.Id;
        }
    }
}
