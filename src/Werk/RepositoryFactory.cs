using System;
using Skunkworks.Model.Interfaces;

namespace Skunkworks.Werk
{
    public sealed class RepositoryFactory : IRepositoryFactory
    {
        private readonly IRepository<IItem> itemRepository;

        public RepositoryFactory()
        {
            this.itemRepository = new ItemRepository();
        }

        public IRepository<T> GetRepository<T>()
        {
            var typeOfT = typeof(T);
            // and kids, this is why we use a DI framework
            if (typeOfT.IsAssignableFrom(typeof(IItem)))
            {
                return itemRepository as IRepository<T>;
            }

            throw new InvalidOperationException($"Repository not found for type {typeOfT}");
        }
    }
}
