namespace ProgramsApp.API.Repositories.Interfaces
{
    public interface ISubmitAppRepository
    {
        Task<bool> IsApplicationExist(string id);
        Task<bool> SubmitApplication(Dictionary<string, string> applicationForm);
    }
}
