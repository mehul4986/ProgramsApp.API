using ProgramsApp.API.Models;
using ProgramsApp.API.Repositories;
using ProgramsApp.API.Repositories.Interfaces;
using ProgramsApp.API.Services.Interfaces;

namespace ProgramsApp.API.Services
{
    public class SubmitAppService : ISubmitAppService
    {
        private readonly ISubmitAppRepository _submitAppRepository;

        public SubmitAppService(ISubmitAppRepository submitAppRepository)
        {
            _submitAppRepository = submitAppRepository;
        }

        public async Task<bool> IsApplicationExist(string id)
        {
            return await _submitAppRepository.IsApplicationExist(id);
        }

        public async Task<bool> SubmitApplication(ApplicationFormDTO applicationForm)
        {
            var columns = new Dictionary<string, string>();

            columns.Add("id", applicationForm.id);
            columns.Add("programTitle", applicationForm.programDescription);
            columns.Add("programDescription", applicationForm.programTitle);

            List<Questionfield> lstAppQDTO = new();
            List<Fields> lstAppAQDTO = new();

            if (applicationForm.Questionfields != null && applicationForm.Questionfields.Count > 0)
            {
                foreach (var qitem in applicationForm.Questionfields)
                {
                    columns.Add(qitem.fieldTitle, qitem.fieldValue);
                }
            }

            if (applicationForm.AdditionalQuestionfield != null && applicationForm.AdditionalQuestionfield.Count > 0)
            {
                foreach (var qitem in applicationForm.AdditionalQuestionfield)
                {
                    columns.Add(qitem.fieldTitle, qitem.fieldValue);
                }
            }
            return await _submitAppRepository.SubmitApplication(columns);
        }
    }
}
