using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Skunkworks.Model.Interfaces;
using Skunkworks.Werk;

namespace Skunkworks
{
    public static class WerkController
    {
        [FunctionName("WerkController")]
        [return: Blob("kartoutput-container:{id}")]
        public static Task<string> Run([QueueTrigger("werkerqueue-items", Connection = "storageAccount")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");

            var repoFactory = new RepositoryFactory();
            var repo = repoFactory.GetRepository<IItem>();

            Console.WriteLine("Hi");

            return Task.FromResult("Tussin");
        }
    }
}
