using Skunkworks.Model.Interfaces;

namespace Skunkworks.Werk
{
    public interface IRepositoryFactory
    {
        IItemRepository GetRepository(AlgorithmType algorithmType);
    }
}
