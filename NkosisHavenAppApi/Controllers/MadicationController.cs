using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NkosisHavenAppApi.BusinessLogic.Services;
using NkosisHavenAppApi.Data.Entities;

namespace NkosisHavenAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationController : ControllerBase
    {
        private readonly MedicationService _medicationService;

        public MedicationController(MedicationService medicationService)
        {
            _medicationService = medicationService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Medication>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMedications(CancellationToken cancellationToken)
        {
            var medications = await _medicationService.GetMedicationsAsync(cancellationToken);
            return Ok(medications);
        }

        [HttpPost]
        public async Task<IActionResult> AddMedication([FromBody] Medication medication)
        {
            await _medicationService.AddMedicationAsync(medication);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMedication([FromBody] Medication medication)
        {
            await _medicationService.UpdateMedicationAsync(medication);
            return Ok();

        }
    }
}
