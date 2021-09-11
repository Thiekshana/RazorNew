using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Razor.Models
{
    public class Incoming
    {
        public int Id { get; set; }
        [Required]
        public string ProjectNumber { get; set; }

        public string ProjectName { get; set; }

        public string ElementNumber { get; set; }

        public string ElementName { get; set; }
    }
}
