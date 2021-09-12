using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Razor.Models
{
    public class Project
    {
        public int Id { get; set; }

        public string ProjectNumber { get; set; }
        [Required]
        public string ProjectName { get; set; }

        public char ElementNumber { get; set; }

        public string ElementName { get; set; }
    }
}
