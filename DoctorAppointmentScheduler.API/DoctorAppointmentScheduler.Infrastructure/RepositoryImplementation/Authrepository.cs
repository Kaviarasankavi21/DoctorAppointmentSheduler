using DoctorAppointmentScheduler.Domain.Models;
using DoctorAppointmentScheduler.Infrastructure.RepositoryInterface;
using DoctorAppointmentScheduler.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DoctorAppointmentScheduler.Infrastructure.Authentication
{
    public class Authrepository : IAuth
    {
        private readonly DoctorappointmentContext _context;
        private readonly Errorhandling _er;

        public Authrepository(DoctorappointmentContext context)
        {
            _context = context;
            _er = new Errorhandling();
        }

        public User ValidateUser(string Username, string Hashedpassword)
        {
            try
            {
                var user = _context.Users
                     .FirstOrDefault(u => u.Username == Username);
                if (user == null)
                {
                    return null;
                }

                bool result = PasswordHasher.VerifyPassword(Hashedpassword, user.Hashedpassword);


                return result ? user : null;
            }
            catch (Exception ex)
            {
                _er.Add(ex.Message);
                throw ex;
            }
        }
    }
}
