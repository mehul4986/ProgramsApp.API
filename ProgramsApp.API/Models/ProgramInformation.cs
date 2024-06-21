using Newtonsoft.Json;

namespace ProgramsApp.API.Models
{
    public class ProgramInformation
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        public string programId { get; set; }
        public string programTitle { get; set; }
        public string programDescription { get; set; }
    }
    public class Fields
    {
        public string fieldId { get; set; }
        public string fieldTitle { get; set; }
        public string fieldValue { get; set; }
        public string fieldType { get; set; }
        public List<string>? Options { get; set; }
        public bool required { get; set; }
    }

    public class Questionfield : Fields
    {
        public bool @internal { get; set; }
        public bool hide { get; set; }
    }

    public class ApplicationForm : ProgramInformation
    {
        public List<Fields> AdditionalQuestionfield { get; set; }
        public List<Questionfield> Questionfields { get; set; }
    }




}
