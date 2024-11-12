﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NkosisHavenApp.Models
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
