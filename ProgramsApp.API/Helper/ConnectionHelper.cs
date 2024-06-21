using Microsoft.Azure.Cosmos;

namespace ProgramsApp.API.Helper
{
    public class ConnectionHelper
    {
        public static string AccountUri => System.Environment.GetEnvironmentVariable("CosmosDBAccountUri") ?? "https://localhost:8081";
        public static string AccountPrimaryKey => System.Environment.GetEnvironmentVariable("CosmosDBAccountPrimaryKey") ?? "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        public static string DbName => System.Environment.GetEnvironmentVariable("CosmosDbName") ?? "ProgramApp";
        public static string DbContainerName => System.Environment.GetEnvironmentVariable("CosmosDbContainerName") ?? "Program";
        public static string AppDbContainerName => System.Environment.GetEnvironmentVariable("CosmosAppDbContainerName") ?? "Applications";

        public static Container ContainerClient()
        {
            CosmosClient cosmosDbClient = new CosmosClient(AccountUri, AccountPrimaryKey);
            Container containerClient = cosmosDbClient.GetContainer(DbName, DbContainerName);
            return containerClient;
        }

        public static Container AppContainerClient()
        {
            CosmosClient cosmosDbClient = new CosmosClient(AccountUri, AccountPrimaryKey);
            Container containerClient = cosmosDbClient.GetContainer(DbName, AppDbContainerName);
            return containerClient;
        }
    }
}
