using Microsoft.Extensions.Logging;
using NkosisHavenAppApi.Data;
using NkosisHavenAppApi.Data.Entities;


namespace NkosisHavenAppApi.BusinessLogic.Services
{
    public class MedicationService
    {
        private readonly IDataStore _dataStore;
        private readonly ILogger<MedicationService> _logger;

        public MedicationService(IDataStore dataStore, ILogger<MedicationService> logger)
        {
            _dataStore = dataStore;
            _logger = logger;
        }

        public async Task<IEnumerable<Medication>> GetMedicationsAsync(CancellationToken cancellationToken = default)
        {
            return await _dataStore.GetEntitiesAsync<Medication>(cancellationToken);
        }

        public async Task AddMedicationAsync(Medication medication)
        {
            await _dataStore.InsertEntityAsync(medication);
        }

        public async Task UpdateMedicationAsync(Medication medication)
        {
            await _dataStore.UpdateEntityAsync(medication);
        }
    }
}
