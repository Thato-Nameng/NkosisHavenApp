using NkosisHavenApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NkosisHavenApp.Data
{
    public interface IAppointment
    {

        Task<List<Appointment>> GetAppointmentsAsync();
        //Task<Appointment> GetAppointmentAsync(int id);
        //Task AddAppointmentAsync(Appointment appointment);
        //Task UpdateAppointmentAsync(Appointment appointment);
        //Task DeleteAppointmentAsync(int id);

    }
}
