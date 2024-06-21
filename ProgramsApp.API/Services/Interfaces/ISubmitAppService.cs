using ProgramsApp.API.Models;

namespace ProgramsApp.API.Services.Interfaces
{
    public interface ISubmitAppService
    {
        Task<bool> IsApplicationExist(string id);
        Task<bool> SubmitApplication(ApplicationFormDTO applicationForm);
    }
}
