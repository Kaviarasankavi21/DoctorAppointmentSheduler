using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentScheduler.Application.DTOclass
{
    public class Countrydto
    {
        public Guid Countryid { get; set; }

        public string Countryname { get; set; } = null!;
    }
    public class countryresponsedto
    {
        public Guid countryid { get; set; }
        public string countryname { get; set; } = null!;
        public bool? isdeleted { get; set; }
    }
}
