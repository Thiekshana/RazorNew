using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razor.Models
{
    public class TaxPayer
    {
        public int Id { get; set; }
        public string PlayerName { get; set; }
        public string PlayerAddress { get; set; }
        public string IdentificationNumber { get; set; }
    }
}
