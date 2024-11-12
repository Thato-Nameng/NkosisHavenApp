using Microsoft.EntityFrameworkCore;
using NkosisHavenAppApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NkosisHavenAppApi.Data.DataAccessors
{
    partial class DataStore
    {

        public async Task<IEnumerable<Patient>> GetOrdersAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Patient.ToListAsync(cancellationToken);
        }
        public async Task<IEnumerable<T>> GetEntitiesAsync<T>(CancellationToken cancellation = default) where T : class
        {
            return await _dbContext.Set<T>().ToListAsync(cancellation);
        }

        public async Task InsertEntityAsync<T>(T entity) where T : class
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateEntityAsync<T>(T entity) where T : class
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetEntitiesWithConditionAsync<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellation = default, int take = default) where T : class
        {
            return await _dbContext.Set<T>()
                .Where(predicate)
                .Take(take)
                .ToListAsync(cancellation);
        }
    }
}
