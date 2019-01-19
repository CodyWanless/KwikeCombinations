using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using Skunkworks.Model;

namespace Skunkworks
{
    public static class ShoppingCartBFD
    {
        [FunctionName("ShoppingCartBFD")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody;
            using (var streamReader = new StreamReader(req.Body))
            {
                requestBody = await streamReader.ReadToEndAsync();
            }
            var requestObj = JsonConvert.DeserializeObject<BFDRequest>(requestBody);
            var items = requestObj.Areas.Select((a, i) => new Item(i, a)).ToArray();

            var bfdRunner = new BFDRunner();
            var resultingCarts = bfdRunner.Run(items);

            try
            {
                return new OkObjectResult(resultingCarts);
            }
            catch (Exception e)
            {
                return new UnprocessableEntityObjectResult(e);
            }
        }
    }

    public class BFDRequest
    {
        public IEnumerable<double> Areas { get; set; }
    }
}
