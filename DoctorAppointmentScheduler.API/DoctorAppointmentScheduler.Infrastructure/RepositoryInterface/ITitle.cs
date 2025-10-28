using DoctorAppointmentScheduler.Application.DTOclass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentScheduler.Infrastructure.RepositoryInterface
{
    public interface ITitle
    {
        string addTitle(string Titlename);
        List<Titleresponsedto> getallTitle();
        string deleteTitle(Guid Titleid);
        string updateTttitle(Guid Titleid, string Titlename);
    }
}
