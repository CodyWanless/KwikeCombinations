using System;
using System.Collections.Generic;
using Skunkworks.Model.Interfaces;

namespace Skunkworks.Werk
{
    public sealed class RepositoryFactory : IRepositoryFactory
    {
        private readonly IReadOnlyDictionary<AlgorithmType, IItemRepository> repositories;

        public RepositoryFactory()
        {
            this.repositories = new Dictionary<AlgorithmType, IItemRepository>
            {
                { AlgorithmType.BestFitDecreasing, new BFDItemRepository() }
            };
        }

        public IItemRepository GetRepository(AlgorithmType algorithmType)
        {
            if (repositories.TryGetValue(algorithmType, out var repository))
            {
                return repository;
            }

            throw new InvalidOperationException($"Repository not found for type {algorithmType}");
        }
    }
}
