using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NkosisHavenAppApi.Data.Entities
{
    public class Diagnoses
    {
        public int DiagnosisId { get; set; }
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public string DiagnosisDetails { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
