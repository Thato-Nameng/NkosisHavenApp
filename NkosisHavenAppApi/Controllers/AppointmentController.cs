using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NkosisHavenAppApi.BusinessLogic.Services;
using NkosisHavenAppApi.Data.Entities;
using System.Threading.Tasks;
using System.Threading;

namespace NkosisHavenAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly AppointmentService _appointmentService;
        public AppointmentController(AppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        /// <summary>
        /// Gets a list of appointments.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token for the operation.</param>
        /// <returns>A list of appointments</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Appointment>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var appointments = await _appointmentService.GetAppointmentAsync(cancellationToken);

            // Check if there are no appointments
            if (appointments == null || !appointments.Any())
            {
                return NotFound("No appointments found.");
            }

            return Ok(appointments);
        }

        /// <summary>
        /// Adds a new appointment.
        /// </summary>
        /// <param name="appointment">The appointment details to create.</param>
        /// <returns>Result of the appointment creation.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] Appointment appointment)
        {
            // Validate the appointment object
            if (appointment == null)
            {
                return BadRequest("Appointment details must be provided.");
            }

            // Add the appointment using the service
            await _appointmentService.AddAppointmentAsync(appointment);

            // Return a status of Created, with a reference to the created resource
            return Ok();
        }
    }
}
