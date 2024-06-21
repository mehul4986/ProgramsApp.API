using ProgramsApp.API.Models;
using ProgramsApp.API.Repositories.Interfaces;
using ProgramsApp.API.Services.Interfaces;

namespace ProgramsApp.API.Services
{
    public class ApplicationFormService : IApplicationFormService
    {
        private readonly IApplicationFormRepository _applicationFormRepository;

        public ApplicationFormService(IApplicationFormRepository applicationFormRepository)
        {
            _applicationFormRepository = applicationFormRepository;
        }

        public async Task<ApplicationForm> CreateApplication(ApplicationFormDTO applicationForm)
        {
            List<Questionfield> lstAppQDTO = new();
            List<Fields> lstAppAQDTO = new();

            if (applicationForm.Questionfields != null && applicationForm.Questionfields.Count > 0)
            {
                foreach (var qitem in applicationForm.Questionfields)
                {
                    var appQDTO = new Questionfield
                    {
                        fieldId = qitem.fieldId,
                        fieldTitle = qitem.fieldTitle,
                        fieldType = qitem.fieldType,
                        fieldValue = null,
                        Options = qitem.Options,
                        required = qitem.required,
                        @internal = qitem.@internal,
                        hide = qitem.hide
                    };
                    lstAppQDTO.Add(appQDTO);
                }
            }

            if (applicationForm.AdditionalQuestionfield != null && applicationForm.AdditionalQuestionfield.Count > 0)
            {
                foreach (var qitem in applicationForm.AdditionalQuestionfield)
                {
                    var appAQDTO = new Fields
                    {
                        fieldId = qitem.fieldId,
                        fieldTitle = qitem.fieldTitle,
                        fieldType = qitem.fieldType,
                        fieldValue = null,
                        Options = qitem.Options,
                        required = qitem.required
                    };
                    lstAppAQDTO.Add(appAQDTO);
                }
            }

            var appDTO = new ApplicationForm
            {
                id = applicationForm.id,
                programTitle = applicationForm.programTitle,
                programDescription = applicationForm.programDescription,
                Questionfields = lstAppQDTO,
                AdditionalQuestionfield = lstAppAQDTO
            };

            return await _applicationFormRepository.CreateApplication(appDTO);
        }

        public async Task<ApplicationForm> GetApplicationById(string id)
        {
            return await _applicationFormRepository.GetApplicationById(id);
        }

        public async Task<bool> IsApplicationExist(string id)
        {
            return await _applicationFormRepository.IsApplicationExist(id);
        }

        public async Task<ApplicationForm> UpdateApplication(ApplicationFormDTO applicationForm)
        {
            ApplicationForm existingItem = new();
            List<Questionfield> lstAppQDTO = new();
            List<Fields> lstAppAQDTO = new();
            ApplicationForm appForm = new();

            existingItem = await GetApplicationById(applicationForm.id);

            if (applicationForm.Questionfields != null && applicationForm.Questionfields.Count > 0)
            {
                foreach (var qitem in applicationForm.Questionfields)
                {
                    var appQDTO = new Questionfield
                    {
                        fieldId = qitem.fieldId,
                        fieldTitle = qitem.fieldTitle,
                        fieldType = qitem.fieldType,
                        fieldValue = null,
                        Options = qitem.Options,
                        required = qitem.required,
                        @internal = qitem.@internal,
                        hide = qitem.hide
                    };
                    lstAppQDTO.Add(appQDTO);
                }
            }

            if (applicationForm.AdditionalQuestionfield != null && applicationForm.AdditionalQuestionfield.Count > 0)
            {
                foreach (var qitem in applicationForm.AdditionalQuestionfield)
                {
                    var appAQDTO = new Fields
                    {
                        fieldId = qitem.fieldId,
                        fieldTitle = qitem.fieldTitle,
                        fieldType = qitem.fieldType,
                        fieldValue = null,
                        Options = qitem.Options,
                        required = qitem.required
                    };
                    lstAppAQDTO.Add(appAQDTO);
                }
            }

            if (existingItem != null)
            {
                appForm = new ApplicationForm
                {
                    id = existingItem.id,
                    programTitle = existingItem.programTitle,
                    programDescription = existingItem.programDescription,
                    Questionfields = lstAppQDTO,
                    AdditionalQuestionfield = lstAppAQDTO
                };
            }
            else
            {
                appForm = new ApplicationForm
                {
                    id = applicationForm.id,
                    programTitle = applicationForm.programTitle,
                    programDescription = applicationForm.programDescription,
                    Questionfields = lstAppQDTO,
                    AdditionalQuestionfield = lstAppAQDTO
                };
            }

            return await _applicationFormRepository.UpdateApplication(appForm);
        }
    }
}
