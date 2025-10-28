using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentScheduler.Application.DTOclass
{
    public class Authdto
    {
        public string Username { get; set; } = null!;

        public string Hashedpassword { get; set; } = null!;
    }
}
