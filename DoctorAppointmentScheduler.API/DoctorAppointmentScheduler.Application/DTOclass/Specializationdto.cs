using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentScheduler.Application.DTOclass
{
    public class Specializationdto
    {
        public Guid SpecializationId { get; set; }
        public string SpecializationName { get; set; } = null!;
    }
    
    public class Specializationresponsedto
    {
        public Guid SpecializationId { get; set; }
        public string SpecializationName { get; set; } = null!;
        public bool? IsDeleted { get; set; }
    }
    
}
