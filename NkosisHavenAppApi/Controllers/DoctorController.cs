using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NkosisHavenAppApi.BusinessLogic.Services;
using NkosisHavenAppApi.Data.Entities;

namespace NkosisHavenAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DoctorController : ControllerBase
    {
        private readonly DoctorService _doctorService;

        public DoctorController(DoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Doctor>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDoctors(CancellationToken cancellationToken)
        {
            var doctors = await _doctorService.GetDoctorsAsync(cancellationToken);

            return Ok(doctors);
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctor([FromBody] Doctor doctor)
        {
            await _doctorService.AddDoctorAsync(doctor);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMedication([FromBody] Doctor doctor)
        {
            await _doctorService.UpdateDoctorAsync(doctor);

            return Ok();

        }
    }
}
