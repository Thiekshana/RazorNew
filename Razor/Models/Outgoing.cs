using System.Text.Json.Serialization;


namespace Razor.Models
{
    public class Outgoing
    {
        public int Id { get; set; }
     
        public string ProjectNumber { get; set; }
    
        public string ProjectName { get; set; }
     
        public string ElementNumber { get; set; }
      
        public string ElementName { get; set; }


    }

    public class OutGoingData
    {
        public Outgoing data { get; set; }
    }
}
