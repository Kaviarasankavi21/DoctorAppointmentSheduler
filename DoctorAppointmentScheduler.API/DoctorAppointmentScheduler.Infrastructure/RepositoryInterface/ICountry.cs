using DoctorAppointmentScheduler.Application.DTOclass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentScheduler.Infrastructure.RepositoryInterface
{
    public interface ICountry
    {
        string addcountry(string countryname);
        List<countryresponsedto> getallcountry();
        string deletecountry(Guid countryid);
        string updatecountry(Guid countryid, string countryname);

    }
}
