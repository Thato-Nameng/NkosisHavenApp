using NkosisHavenApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NkosisHavenApp.Data
{
    public interface IDataStore
    {
       
        Task<IEnumerable<T>> Get<T>(CancellationToken cancellation = default) where T : class;
        //Task InsertEntityAsync<T>(T entity) where T : class;
        //Task UpdateEntityAsync<T>(T entity) where T : class;

    }
}
