using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NkosisHavenAppApi.Common;
using NkosisHavenAppApi.Data.Entities;
using NkosisHavenAppApi.Data;
using Microsoft.Data.SqlClient;
namespace NkosisHavenAppApi.BusinessLogic.Services
{
    public class PatientService
    {
        private readonly IDataStore _dataStore;
        private readonly ILogger<PatientService> _logger;
        private readonly IOptionsSnapshot<AppSettings> _appSettings;

        public PatientService(IDataStore dataStore, ILogger<PatientService> logger, IOptionsSnapshot<AppSettings> appSettings)
        {
            _dataStore = dataStore;
            _logger = logger;
            _appSettings = appSettings;
        }

        public async Task<IEnumerable<Patient>> GetPatientsAsync(CancellationToken cancellationToken = default)
        {
            var patients = Enumerable.Empty<Patient>();
          
            patients = await _dataStore.GetEntitiesAsync<Data.Entities.Patient>(cancellationToken);

            return patients;

        }

        public async Task AddPatientAsync(Patient patient)
        {
            try
            {
                _logger.LogTrace("Adding new Patient...");

                if (patient == null)
                {
                    _logger.LogWarning("Cannot add a null patient.");
                    throw new ArgumentNullException(nameof(patient), "Patient cannot be null.");
                }

                await _dataStore.InsertEntityAsync(patient);
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, "Patient data is null.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding the patient.");
            }
        }
    }
}
