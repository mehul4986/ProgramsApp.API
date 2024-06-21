using Microsoft.Azure.Cosmos;
using ProgramsApp.API.Helper;
using ProgramsApp.API.Models;
using ProgramsApp.API.Repositories.Interfaces;

namespace ProgramsApp.API.Repositories
{
    public class ApplicationFormRepository : IApplicationFormRepository
    {
        private readonly Microsoft.Azure.Cosmos.Container _container;

        public ApplicationFormRepository()
        {
            _container = ConnectionHelper.ContainerClient();
        }

        public async Task<ApplicationForm> CreateApplication(ApplicationForm applicationForm)
        {
            var response = await _container.CreateItemAsync(applicationForm, new PartitionKey(applicationForm.id));
            return response.Resource;
        }

        public async Task<ApplicationForm> GetApplicationById(string id)
        {
            ItemResponse<ApplicationForm>? response = await _container.ReadItemAsync<ApplicationForm>(id, new PartitionKey(id));
            return response.Resource;
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

        public async Task<ApplicationForm> UpdateApplication(ApplicationForm newApplicationForm)
        {
            var updateRes = await _container.ReplaceItemAsync(newApplicationForm, newApplicationForm.id, new PartitionKey(newApplicationForm.id));
            return updateRes.Resource;
        }
    }
}
