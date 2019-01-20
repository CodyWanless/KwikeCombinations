using System.Collections.Generic;
using System.Threading.Tasks;
using Skunkworks.Model.Interfaces;

namespace Skunkworks.Werk
{
    public interface IItemRepository
    {
        AlgorithmType AlgorithmType { get; }
        Task ScheduleWork(IReadOnlyCollection<IItem> items);
    }
}
