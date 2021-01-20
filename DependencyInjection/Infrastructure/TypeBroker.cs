using DependencyInjection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Infrastructure
{
    public class TypeBroker
    {
        private static Type repositoryType = typeof(MemoryRepository);
        private static IRepository testRepository;
        public static IRepository Repository => testRepository ?? Activator.CreateInstance(repositoryType) as IRepository;
        public static void SetRepositoryType<T>() where T : IRepository => repositoryType = typeof(T);
        public static void SetTestObject(IRepository repository) => testRepository = repository;
    }
}
