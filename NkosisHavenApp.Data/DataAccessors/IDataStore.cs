using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NkosisHavenApp.Data.DataAccessors
{
    public interface IDataStore
    {
        Task<IEnumerable<T>> GetEntitiesAsync<T>(CancellationToken cancellation = default) where T : class;
        Task InsertEntityAsync<T>(T entity) where T : class;
        Task UpdateEntityAsync<T>(T entity) where T : class;
        Task<IEnumerable<T>> GetEntitiesWithConditionAsync<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellation = default, int take = default) where T : class;
    }
}
