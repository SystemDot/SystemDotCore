using System;
using System.Collections.Concurrent;
using System.Linq;

namespace SystemDot.Querying.Repositories
{
    public class InMemoryRepository : IQueryableRepository
    {
        private readonly ConcurrentDictionary<object, object> entities;

        public InMemoryRepository()
        {
            entities = new ConcurrentDictionary<object, object>();
        }

        public void Add<T>(T toAdd) where T : IdEqualityBase<T>
        {
            entities.TryAdd(toAdd, toAdd);
        }

        public void Remove<T>(T toRemove) where T : IdEqualityBase<T>
        {
            object temp;
            entities.TryRemove(toRemove, out temp);
        }

        public IQueryable<T> Query<T>() where T : IdEqualityBase<T>
        {
            return entities.Values.OfType<T>().ToList().AsQueryable();
        }

        public T GetById<T>(Guid id) where T : IdEqualityBase<T>
        {
            return entities.Values.OfType<T>().SingleOrDefault(x => x.Id == id);
        }
    }
}