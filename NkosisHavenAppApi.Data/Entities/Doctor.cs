﻿namespace NkosisHavenAppApi.Data.Entities
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialty { get; set; }
        public string Email { get; set; }
        public string PhoneNumber
        {
            get; set;
        }
    }
}
