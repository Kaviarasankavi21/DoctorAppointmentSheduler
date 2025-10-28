using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentScheduler.Application.DTOclass
{
    public class Titledto
    {
        public Guid Titleid { get; set; }
        public string Titlename { get; set; } = null!;
    }
    
    public class Titleresponsedto
    {
        public Guid Titleid { get; set; }
        public string Titlename { get; set; } = null!;
        public bool? isdeleted { get; set; }
    }
}
