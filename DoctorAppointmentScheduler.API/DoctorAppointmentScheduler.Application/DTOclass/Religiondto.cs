using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentScheduler.Application.DTOclass
{
    public class Religiondto
    {
        public Guid Religionid { get; set; }
        public string Religionname { get; set; }
    }

    public class Religionresponsedto
    {
        public Guid Religionid { get; set; }
        public string Religionname { get; set; } = null!;
        public bool? isdeleted { get; set; }
    }


}   
