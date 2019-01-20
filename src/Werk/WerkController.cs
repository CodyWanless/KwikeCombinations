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
        [return: Queue("werkerqueue-items")]
        public static Task<string> Run(
            [QueueTrigger("werkerqueue-items", Connection = "storageAccount")]string myQueueItem,
            ILogger log)
        {
            var req = JsonConvert.DeserializeObject<QueueRequest>(myQueueItem);
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");

            // preferably done via a handler foreach algorithm type
            if (req.AlgorithmType == AlgorithmType.Done)
            {
                Console.WriteLine("Quitting.");
                return Task.FromResult<string>(null);
            }

            var repoFactory = new RepositoryFactory();
            var repo = repoFactory.GetRepository<IItem>();

            var result = new
            {
                Id = Guid.NewGuid(),
                NextStepType = AlgorithmType.Done,
                Output = "Arbitrary Done Message"
            };
            var resultString = JsonConvert.SerializeObject(result);

            return Task.FromResult(resultString);
        }

        private sealed class QueueRequest
        {
            public AlgorithmType AlgorithmType { get; set; }
            public Guid Id { get; set; }
        }
    }
}
