using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NkosisHavenAppApi.Data.DataAccessors
{
    public partial class DataStore : IDataStore
    {
        private readonly ApplicationDbContext _dbContext;

        public DataStore(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
