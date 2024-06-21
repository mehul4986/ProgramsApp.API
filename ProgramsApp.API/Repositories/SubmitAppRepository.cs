using Microsoft.Azure.Cosmos;
using ProgramsApp.API.Helper;
using ProgramsApp.API.Models;
using ProgramsApp.API.Repositories.Interfaces;

namespace ProgramsApp.API.Repositories
{
    public class SubmitAppRepository : ISubmitAppRepository
    {
        private readonly Microsoft.Azure.Cosmos.Container _container;

        public SubmitAppRepository()
        {
            _container = ConnectionHelper.AppContainerClient();
        }

        public async Task<bool> IsApplicationExist(string id)
        {
            bool isExist = false;
            try
            {
                var response = await _container.ReadItemAsync<ApplicationForm>(id, new PartitionKey(id));
                if (response != null)
                {
                    isExist = true;
                }
            }
            catch (Exception ex)
            {
                isExist = false;

            }
            return isExist;
        }

        public async Task<bool> SubmitApplication(Dictionary<string, string> applicationForm)
        {
            var response = await _container.CreateItemAsync(applicationForm, new PartitionKey(applicationForm["id"]));
            return response.StatusCode == System.Net.HttpStatusCode.Created ? true : false;
        }
    }
}
