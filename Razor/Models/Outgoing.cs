using System;
using System.Text.Json.Serialization;


namespace Razor.Models
{
    public class Outgoing
    {
        public Outgoing(string projectNumber, string projectName, string elementNumber, string elementName)
        {
            ProjectNumber = projectNumber;
            ProjectName = projectName;
            ElementNumber = Convert.ToChar(elementNumber);
            //ElementNumber = elementNumber.Length == 1 ? Convert.ToChar(elementNumber) : throw new ArgumentException(String.Format("Hello dude, {0} contains more than one characters", elementNumber));
            ElementName = elementName;
            //Convert.ToChar(elementNumber);
        }

        [JsonIgnore]
        public int Id { get; set; }

        public string ProjectNumber { get; set; }

        public string ProjectName { get; set; }

        public char ElementNumber { get; set; }

        public string ElementName { get; set; }


        public class OutGoingData
        {
            public Outgoing data { get; set; }
        }

    }
}
