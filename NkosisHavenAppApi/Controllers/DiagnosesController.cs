using Microsoft.AspNetCore.Mvc;
using NkosisHavenAppApi.BusinessLogic.Services;
using NkosisHavenAppApi.Data.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NkosisHavenAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosesController : ControllerBase
    {
        private readonly DiagnosesService _diagnosesService;

        public DiagnosesController(DiagnosesService diagnosesService)
        {
            _diagnosesService = diagnosesService;
        }

        /// <summary>
        /// Gets the list of all diagnoses.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token for the operation.</param>
        /// <returns>A list of diagnoses</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Diagnoses>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var diagnoses = await _diagnosesService.GetDiagnosisAsync(cancellationToken);
            return Ok(diagnoses);
        }

        /// <summary>
        /// Adds a new diagnosis.
        /// </summary>
        /// <param name="diagnosis">The diagnosis details to be added.</param>
        /// <returns>Returns the status of the operation.</returns>
        [HttpPost("PostDiagnosis")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(Diagnoses diagnosis)
        {
            if (diagnosis is null)
            {
                return BadRequest("A Diagnosis details must be present.");
            }

            await _diagnosesService.AddDiagnosisAsync(diagnosis);

            return Ok();
        }
    }
}
