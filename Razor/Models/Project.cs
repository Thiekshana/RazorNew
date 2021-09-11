using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razor.Models
{
    public class Project
    {
        public int Id { get; set; }

        public string ProjectNumber { get; set; }

        public string ProjectName { get; set; }

        public char ElementNumber { get; set; }

        public string ElementName { get; set; }
    }
}
