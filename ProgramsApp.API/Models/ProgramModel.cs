using Newtonsoft.Json;

namespace ProgramsApp.API.Models
{
    public class ProgramModel
    {
        [JsonProperty("id")]
        public string id { get; set; }

        public string programTitle { get; set; }
        public string programDescription { get; set; }
    }
    public class Fields
    {
        public string fieldId { get; set; }
        public string fieldTitle { get; set; }
        public string fieldType { get; set; }
        public List<string>? Options { get; set; }
        public bool required { get; set; } = false;
        public string? fieldValue { get; set; }
    }

    public class Questionfield : Fields
    {
        public bool @internal { get; set; } = false;
        public bool hide { get; set; } = false;
    }

    public class ApplicationForm : ProgramModel
    {
        public List<Questionfield>? Questionfields { get; set; }
        public List<Fields>? AdditionalQuestionfield { get; set; }
    }
}
