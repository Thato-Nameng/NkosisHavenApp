using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NkosisHavenApp.Models
{
	public class Appointment
	{
		public int AppointmentId { get; set; }
		public int PatientId { get; set; }
		public int DoctorId { get; set; }
		public DateTime AppointmentDate { get; set; }
		public string AppointmentReason { get; set; }
		public string AppointmentStatus { get; set; } = "Pending";
		public DateTime CreatedDate { get; set; } = DateTime.Now;
	}
}
