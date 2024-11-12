using NkosisHavenAppApi.Data.Entities;
using System.Linq.Expressions;

namespace NkosisHavenAppApi.Data
{
    public interface IDataStore
    {
        Task<IEnumerable<T>> GetEntitiesAsync<T>(CancellationToken cancellation = default) where T : class;
        Task InsertEntityAsync<T>(T entity) where T : class;
        Task UpdateEntityAsync<T>(T entity) where T : class;
        Task<IEnumerable<T>> GetEntitiesWithConditionAsync<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellation = default, int take = default) where T : class;


	}
}
