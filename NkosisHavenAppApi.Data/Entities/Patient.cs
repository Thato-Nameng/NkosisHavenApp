using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NkosisHavenAppApi.Data.Entities
{
	public class Patient
	{
		public int PatientId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int IDNumber { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string Gender { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string PAddress { get; set; }
		public string MedicalReason { get; set; }
		public string PasswordHash { get; set; }
	}
}
