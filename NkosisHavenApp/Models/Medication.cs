using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NkosisHavenApp.Models
{
	public class Medication
	{
		public int MedicationId { get; set; }
		public int DiagnosisId { get; set; }
		public int PatientId { get; set; }
		public string MedicationName { get; set; }
		public string Dosage { get; set; }
		public string Instructions { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public Diagnosis Diagnosis { get; set; } 
	}
}
