using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentScheduler.Application.DTOclass
{
    public class Maritalstatusdto
    {
        public Guid Maritalstatusid { get; set; }
        public string Maritalstatus1 { get; set; } = null!;
    }
    
    public class Maritalstatusresponsedto
    {
        public Guid Maritalstatusid { get; set; }
        public string Maritalstatus1 { get; set; } = null!;
        public bool? isdeleted { get; set; }
    }
}
