using DoctorAppointmentScheduler.Application.DTOclass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentScheduler.Infrastructure.RepositoryInterface
{
    public interface IMaritalstatus
    {
        string addMaritalstatus(string Maritalstatusname);
        List<Maritalstatusresponsedto> getallMaritalstatus();
        string deleteMaritalstatus(Guid Maritalstatusid);
        string updateMaritalstatus(Guid Maritalstatusid, string Maritalstatusname);
    }
}
