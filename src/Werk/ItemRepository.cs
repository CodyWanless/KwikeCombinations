using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Skunkworks.Model.Interfaces;

namespace Skunkworks.Werk
{
    public sealed class ItemRepository : IRepository<IItem>
    {
        private readonly IServiceClient serviceClient;
        private readonly string bfdUrl;

        public ItemRepository()
            : this(HttpServiceClient.Instance) { } // #BastardInjectionSaturday

        public ItemRepository(IServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
            this.bfdUrl = System.Environment.GetEnvironmentVariable("BFD_URI");
        }

        public Task ScheduleWork(IReadOnlyCollection<IItem> workItems)
        {
            var request = new
            {
                Areas = workItems.Select(item => item.AreaRequired)
            };

            return this.serviceClient.PostAsync(bfdUrl, request);
        }
    }
}
