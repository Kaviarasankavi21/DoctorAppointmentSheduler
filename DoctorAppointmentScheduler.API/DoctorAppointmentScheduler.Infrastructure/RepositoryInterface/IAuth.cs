using DoctorAppointmentScheduler.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentScheduler.Infrastructure.RepositoryInterface
{
    public interface IAuth
    {
        User ValidateUser(string Username, string Hashedpassword);
    }
}
