using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentScheduler.Application.DTOclass
{
    public class PatientDto
    {
        public Guid Patientid { get; set; }
        public Guid? Titleid { get; set; }
        public string Name { get; set; } = string.Empty;
        public short? Gender { get; set; }
        public DateOnly? Dob { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public Guid? Maritalstatusid { get; set; }
        public Guid? Occupationid { get; set; }
        public string? State { get; set; }
        public string? Pincode { get; set; }
        public string? Address { get; set; }
        public bool? Isactive { get; set; }
    }
}
