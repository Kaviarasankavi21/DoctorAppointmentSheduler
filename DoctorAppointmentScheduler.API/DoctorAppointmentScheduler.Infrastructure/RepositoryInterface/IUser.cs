using DoctorAppointmentScheduler.Application.DTOclass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentScheduler.Infrastructure.RepositoryInterface
{
    public interface IUser
    {
        string AddUser(UserRequestDto request);
        List<UserResponseDto> GetAllUsers();
        UserResponseDto GetUserById(Guid id);
        string UpdateUser(Guid id, UserRequestDto request);
        string DeleteUser(Guid id);

        RegisterResponseDto RegisterUser(RegisterDto registerDto);
        List<userresponsemin> GetDoctors();

    }
}
