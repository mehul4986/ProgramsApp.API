using ProgramsApp.API.Models;

namespace ProgramsApp.API.Services.Interfaces
{
    public interface IApplicationFormService
    {
        Task<ApplicationForm> CreateApplication(ApplicationFormDTO applicationForm);
        Task<ApplicationForm> GetApplicationById(string id);
        Task<bool> IsApplicationExist(string id);
        Task<ApplicationForm> UpdateApplication(ApplicationFormDTO applicationForm);
    }
}
