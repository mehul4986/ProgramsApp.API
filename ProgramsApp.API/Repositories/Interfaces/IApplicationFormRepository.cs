using ProgramsApp.API.Models;

namespace ProgramsApp.API.Repositories.Interfaces
{
    public interface IApplicationFormRepository
    {
        Task<ApplicationForm> CreateApplication(ApplicationForm applicationForm);
        Task<ApplicationForm> GetApplicationById(string id);
        Task<bool> IsApplicationExist(string id);
        Task<ApplicationForm> UpdateApplication(ApplicationForm applicationForm);
    }
}
