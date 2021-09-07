using System.Text.Json.Serialization;


namespace Razor.Models
{
    public class Outgoing
    {
        public string IdX { get; set; }
        [JsonPropertyName("PROJ_NUM")]
        public string ProjectNumberX { get; set; }
        [JsonPropertyName("PROJ_NAME")]
        public string ProjectNameX { get; set; }
        [JsonPropertyName("ELEM_NUM")]
        public string ElementNumberX { get; set; }
        [JsonPropertyName("ELEM_NAME")]
        public string ElementNameX { get; set; }
        public Outgoing(int idX, int projectNumberX, string projectNameX, int elementNumberX, string elementNameX)
        {
            IdX = idX.ToString();
            ProjectNumberX = projectNumberX.ToString();
            ProjectNameX = projectNameX;
            ElementNumberX = elementNumberX.ToString();
            ElementNameX = elementNameX;
        }

    }
}
