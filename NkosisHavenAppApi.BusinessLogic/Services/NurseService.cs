using Microsoft.Extensions.Logging;
using NkosisHavenAppApi.Data;
using NkosisHavenAppApi.Data.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NkosisHavenAppApi.BusinessLogic.Services
{
	public class NurseService
	{
		private readonly IDataStore _dataStore;
		private readonly ILogger<NurseService> _logger;

		public NurseService(IDataStore dataStore, ILogger<NurseService> logger)
		{
			_dataStore = dataStore;
			_logger = logger;
		}

		public async Task<IEnumerable<Nurse>> GetNursesAsync(CancellationToken cancellationToken = default)
		{
			return await _dataStore.GetEntitiesAsync<Nurse>(cancellationToken);
		}

		public async Task AddNurseAsync(Nurse nurse)
		{
			if (nurse == null)
			{
				_logger.LogWarning("Cannot add a null nurse.");
				throw new ArgumentNullException(nameof(nurse), "Nurse cannot be null.");
			}

			await _dataStore.InsertEntityAsync(nurse);
		}
	}
}
