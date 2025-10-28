using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentScheduler.Application.DTOclass
{
    public class AppointmentDto
    {
        public Guid AppointmentId { get; set; } = Guid.Empty;
        public Guid PatientId { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public Guid DoctorId { get; set; }
        public string DoctorName { get; set; } = string.Empty;
        public DateOnly AppointmentDate { get; set; }
        public TimeOnly AppointmentTime { get; set; }
        public string Reason { get; set; } = string.Empty;
        public int Status { get; set; }
        public DateTime? Createdate { get; set; }
        public DateTime? Updatedate { get; set; }
        public string Specialization { get; set; } = string.Empty;

    }

    public class AppointmentDetailDto
    {
        public Guid AppointmentId { get; set; }
        public Guid PatientId { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public Guid DoctorId { get; set; }
        public string DoctorName { get; set; } = string.Empty;

        // Detailed doctor info
        public string Specialization { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Qualification { get; set; } = string.Empty;
        public int? YearsOfExperience { get; set; }
        public decimal? ConsultationFee { get; set; }
        public TimeOnly? AvailabilityStartTime { get; set; }
        public TimeOnly? AvailabilityEndTime { get; set; }

        public DateOnly AppointmentDate { get; set; }
        public TimeOnly AppointmentTime { get; set; }
        public string Reason { get; set; } = string.Empty;
        public int Status { get; set; }
        public DateTime? Createdate { get; set; }
        public DateTime? Updatedate { get; set; }
    }

    public class PatientsDDL
    {
        public Guid Patientid { get; set; }
        public string PatientName { get; set; }
    }
}


