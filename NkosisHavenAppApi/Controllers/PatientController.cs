using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NkosisHavenAppApi.BusinessLogic.Services;
using NkosisHavenAppApi.Data.Entities;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Data.SqlClient;

namespace NkosisHavenAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly PatientService _patientService;

        // Public constructor for dependency injection
        public PatientController(PatientService patientService)
        {
            _patientService = patientService;
        }

        /// <summary>
        /// Gets all patients
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to handle request cancellation</param>
        /// <returns>List of patients</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Patient>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            return Ok(await _patientService.GetPatientsAsync());
        }

        /// <summary>
        /// Adds a new patient
        /// </summary>
        /// <param name="patient">The patient details to be added</param>
        /// <returns>HTTP 201 Created status if successful</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] Patient patient)
        {
            if (patient == null)
                return BadRequest("Patient details must be present");

            await _patientService.AddPatientAsync(patient);

            // Return a 201 Created status with the patient ID or URI of the newly created resource
            return Ok();
        }
    }
}
