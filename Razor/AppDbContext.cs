using Microsoft.EntityFrameworkCore;
using Razor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razor
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }
            public DbSet<TaxPayer> TaxPayers { get; set; }
    }
}
