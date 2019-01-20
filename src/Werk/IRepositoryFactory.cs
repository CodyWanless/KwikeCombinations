using Skunkworks.Model.Interfaces;

namespace Skunkworks.Werk
{
    public interface IRepositoryFactory
    {
        IRepository<T> GetRepository<T>();
    }
}
