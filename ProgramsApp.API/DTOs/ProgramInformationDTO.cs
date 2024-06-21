namespace ProgramsApp.API.Models
{
    public class FieldsDTO
    {
        public string fieldId { get; set; }
        public string fieldTitle { get; set; }
        public string fieldType { get; set; }
        public List<string>? Options { get; set; }
        public bool required { get; set; } = false;
        public string? fieldValue { get; set; }
    }

    public class QuestionfieldDTO : FieldsDTO
    {
        public bool @internal { get; set; } = false;
        public bool hide { get; set; } = false;
    }

    public class ApplicationFormDTO : ProgramModel
    {
        public List<Questionfield>? Questionfields { get; set; }
        public List<Fields>? AdditionalQuestionfield { get; set; }
    }




}
