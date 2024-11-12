using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NkosisHavenAppApi.Common;
using NkosisHavenAppApi.Data;
using NkosisHavenAppApi.Data.Entities;

namespace NkosisHavenAppApi.BusinessLogic.Services
{

    public class AppointmentService
    {
        private readonly IDataStore _dataStore;
        private readonly ILogger<AppointmentService> _logger;
        private readonly IOptionsSnapshot<AppSettings> _appSettings;

        public AppointmentService(IDataStore dataStore, ILogger<AppointmentService> logger, IOptionsSnapshot<AppSettings> appSettings)
        {
            _dataStore = dataStore;
            _logger = logger;
            _appSettings = appSettings;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentAsync(CancellationToken cancellationToken = default)
        {
            var appointment = Enumerable.Empty<Appointment>();

            try
            {
                _logger.LogTrace("Retrieving appointment data...");
                appointment = await _dataStore.GetEntitiesAsync<Data.Entities.Appointment>(cancellationToken);
                _logger.LogInformation($"{appointment.Count()} appointment retrieved.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving appointment data.");
                return Enumerable.Empty<Appointment>();
            }

            return appointment;

        }

        public async Task AddAppointmentAsync(Appointment appointment)
        {
            try
            {
                _logger.LogTrace("Adding new appointment...");

                if (appointment == null)
                {
                    _logger.LogWarning("Cannot add a null appointment.");
                    throw new ArgumentNullException(nameof(appointment), "appointment cannot be null.");
                }

                await _dataStore.InsertEntityAsync(appointment);

                _logger.LogInformation($"appointment {appointment.AppointmentId} {appointment.AppointmentReason} added successfully.");
            }
            catch (ArgumentNullException ex)
            {

                _logger.LogError(ex, "appointment data is null.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding the appointment.");
            }
        }
    }
}
