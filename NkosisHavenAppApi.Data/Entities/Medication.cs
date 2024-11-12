namespace NkosisHavenAppApi.Data.Entities
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
    }
}
