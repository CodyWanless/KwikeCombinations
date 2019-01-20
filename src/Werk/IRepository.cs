using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skunkworks.Werk
{
    public interface IRepository<T>
    {
        Task ScheduleWork(IReadOnlyCollection<T> workItems);
    }
}
