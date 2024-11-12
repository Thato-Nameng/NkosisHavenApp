using Microsoft.Extensions.Logging;
using NkosisHavenAppApi.Data;
using NkosisHavenAppApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NkosisHavenAppApi.BusinessLogic.Services
{
    public class DoctorService
    {
        private readonly IDataStore _dataStore;
        private readonly ILogger<DoctorService> _logger;

        public DoctorService(IDataStore dataStore, ILogger<DoctorService> logger)
        {
            _dataStore = dataStore;
            _logger = logger;
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                _logger.LogInformation("Fetching doctors from the data store.");
                return await _dataStore.GetEntitiesAsync<Doctor>(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching doctors.");
                return Enumerable.Empty<Doctor>();
            }
        }

        public async Task AddDoctorAsync(Doctor doctor)
        {
            try
            {
                _logger.LogInformation("Adding a new doctor to the data store.");
                await _dataStore.InsertEntityAsync(doctor);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding the doctor.");
               
                return; 
            }
        }

        public async Task UpdateDoctorAsync(Doctor doctor)
        {
            try
            {
                _logger.LogInformation("Updating doctor details in the data store.");
                await _dataStore.UpdateEntityAsync(doctor);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the doctor.");
  
                return;
            }
        }
    }
}
