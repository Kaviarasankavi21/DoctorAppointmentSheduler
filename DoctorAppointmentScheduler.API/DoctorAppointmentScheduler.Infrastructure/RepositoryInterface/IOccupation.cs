using DoctorAppointmentScheduler.Application.DTOclass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentScheduler.Infrastructure.RepositoryInterface
{
    public interface IOccupation
    {
        string addOccupation(string Occupationname);
        List<Occupationresponsedto> getallOccupation();
        string deleteOccupation(Guid Occupationid);
        string updateOccupation(Guid Occupationid, string Occupationname);
       
    }
}
