using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Skunkworks
{
    public static class WerkController
    {
        [FunctionName("WerkController")]
        [return: Blob("output-container:{id}")]
        public static void Run([QueueTrigger("werkerqueue-items", Connection = "storageAccount")]string myQueueItem, ILogger log)
        {
            
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
