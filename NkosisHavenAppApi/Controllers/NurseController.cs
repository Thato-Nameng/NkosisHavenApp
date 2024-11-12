using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NkosisHavenAppApi.Data;
using NkosisHavenAppApi.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NkosisHavenAppApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NurseController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		public NurseController(ApplicationDbContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Get all Nurse-Patient mappings
		/// </summary>
		[HttpGet]
		[ProducesResponseType(typeof(IEnumerable<Nurse>), StatusCodes.Status200OK)]
		public async Task<IActionResult> Get(CancellationToken cancellationToken)
		{
			var nurses = _context.Nurses.ToList();
			return Ok(nurses);
		}

		/// <summary>
		/// Create a new Nurse-Patient mapping
		/// </summary>
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		public async Task<IActionResult> Create([FromBody] Nurse nurse)
		{
			if (nurse == null)
				return BadRequest("Nurse details must be provided");

			_context.Nurses.Add(nurse);
			await _context.SaveChangesAsync();
			return Ok();
		}
	}
}
