using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NkosisHavenAppApi.Common;
using NkosisHavenAppApi.Data;
using NkosisHavenAppApi.Data.Entities;
namespace NkosisHavenAppApi.BusinessLogic.Services
{
    public class DiagnosesService
    {
        private readonly IDataStore _dataStore;
        private readonly ILogger<DiagnosesService> _logger;
        private readonly IOptionsSnapshot<AppSettings> _appSettings;

        public DiagnosesService(IDataStore dataStore, ILogger<DiagnosesService> logger, IOptionsSnapshot<AppSettings> appSettings)
        {
            _dataStore = dataStore;
            _logger = logger;
            _appSettings = appSettings;
        }

        public async Task<IEnumerable<Diagnoses>> GetDiagnosisAsync(CancellationToken cancellationToken = default)
        {
            var diagnosis = Enumerable.Empty<Diagnoses>();

            try
            {
                _logger.LogTrace("Retrieving diagnosis data...");
                diagnosis = await _dataStore.GetEntitiesAsync<Data.Entities.Diagnoses>(cancellationToken);
                _logger.LogInformation($"{diagnosis.Count()} diagnosis retrieved.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving diagnosis data.");
                return Enumerable.Empty<Diagnoses>();
            }

            return diagnosis;

        }

        public async Task AddDiagnosisAsync(Diagnoses diagnosis)
        {
            try
            {
                _logger.LogTrace("Adding new diagnosis...");

                if (diagnosis == null)
                {
                    _logger.LogWarning("Cannot add a null diagnosis.");
                    throw new ArgumentNullException(nameof(diagnosis), "diagnosis cannot be null.");
                }

                await _dataStore.InsertEntityAsync(diagnosis);

                _logger.LogInformation($"Patient {diagnosis.DiagnosisId} {diagnosis.DiagnosisDetails} added successfully.");
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
