using System;
using System.Linq;

namespace SystemDot.Querying.Repositories
{
    public interface IQueryableRepository
    {
        void Add<T>(T toAdd) where T : IdEqualityBase<T>;
        void Remove<T>(T toRemove) where T : IdEqualityBase<T>;
        IQueryable<T> Query<T>() where T : IdEqualityBase<T>;
        T GetById<T>(Guid id) where T : IdEqualityBase<T>;
    }
}