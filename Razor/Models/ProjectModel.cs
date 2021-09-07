using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Razor.Models
{
    [Serializable]

    public class ProjectModel
    {

        public int Id { get; set; }
      
        public int ProjectNumber { get; set; }
     
        public string ProjectName { get; set; }
      
        public int ElementNumber { get; set; }
      
        public string ElementName { get; set; }

    }
}
