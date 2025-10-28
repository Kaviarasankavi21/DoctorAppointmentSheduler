using DoctorAppointmentScheduler.Application;
using DoctorAppointmentScheduler.Application.DTOclass;
using DoctorAppointmentScheduler.Domain.Models;
using DoctorAppointmentScheduler.Infrastructure.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace DoctorAppointmentScheduler.Infrastructure.RepositoryImplementation
{
    public class UserRepository : IUser
    {
        private readonly DoctorappointmentContext _context;

        public UserRepository(DoctorappointmentContext context)
        {
            _context = context;
        }

        //Add user
        public string AddUser(UserRequestDto request)
        {
            try
            {


                var user = new User
                {
                    Userid = Guid.NewGuid(),
                    Firstname = request.FirstName,
                    Lastname = request.LastName,
                    Specialization = request.Specialization,
                    Gender = request.Gender,
                    Dateofbirth = request.DateOfBirth.HasValue ? DateOnly.FromDateTime(request.DateOfBirth.Value) : (DateOnly?)null,
                    Phonenumber = request.PhoneNumber,
                    Address = request.Address,
                    Username = request.Username,
                    Hashedpassword = PasswordHasher.HashPassword(request.Password),
                    Role = request.Role,
                    Yearsofexperience = request.YearsOfExperience,
                    Qualification = request.Qualification,
                    Consultationfee = request.ConsultationFee,
                    Availabilitystarttime = request.AvailabilityStartTime.HasValue ? TimeOnly.FromTimeSpan(request.AvailabilityStartTime.Value) : (TimeOnly?)null,
                    Availabilityendtime = request.AvailabilityEndTime.HasValue ? TimeOnly.FromTimeSpan(request.AvailabilityEndTime.Value) : (TimeOnly?)null,
                    Titleid = request.TitleId,
                    Countryid = request.CountryId,
                    Occupationid = request.OccupationId,
                    Religionid = request.ReligionId,
                    Maritalstatusid = request.MaritalStatusId,
                    Isactive = true,
                    Isdelete = false
                };

                _context.Users.Add(user);
                _context.SaveChanges();
                return "User created successfully.";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }


        //public string AddUser(UserRequestDto request)
        //{
        //    try
        //    {
        //        var userId = Guid.NewGuid();

        //        var user = new User
        //        {
        //            Userid = userId,
        //            Firstname = request.FirstName,
        //            Lastname = request.LastName,
        //            Specialization = request.Specialization,
        //            Gender = request.Gender,
        //            Dateofbirth = request.DateOfBirth.HasValue ? DateOnly.FromDateTime(request.DateOfBirth.Value) : (DateOnly?)null,
        //            Phonenumber = request.PhoneNumber,
        //            Address = request.Address,
        //            Username = request.Username,
        //            Hashedpassword = PasswordHasher.HashPassword(request.Password),
        //            Role = request.Role,
        //            Yearsofexperience = request.YearsOfExperience,
        //            Qualification = request.Qualification,
        //            Consultationfee = request.ConsultationFee,
        //            Availabilitystarttime = request.AvailabilityStartTime.HasValue ? TimeOnly.FromTimeSpan(request.AvailabilityStartTime.Value) : (TimeOnly?)null,
        //            Availabilityendtime = request.AvailabilityEndTime.HasValue ? TimeOnly.FromTimeSpan(request.AvailabilityEndTime.Value) : (TimeOnly?)null,
        //            Titleid = request.TitleId,
        //            Countryid = request.CountryId,
        //            Occupationid = request.OccupationId,
        //            Religionid = request.ReligionId,
        //            Maritalstatusid = request.MaritalStatusId,
        //            Isactive = true,
        //            Isdelete = false
        //        };

        //        _context.Users.Add(user);

        //        // ✅ Extra step: If the user role is Patient, insert into PatientDetails
        //        if (request != null)
        //        {
        //            var patient = new Patientdetail
        //            {
        //                Patientid = Guid.NewGuid(),
        //                Titleid = request.TitleId,
        //                Name = $"{request.FirstName} {request.LastName}",
        //               // Gender = request.Gender,
        //                Dob = request.DateOfBirth.HasValue ? DateOnly.FromDateTime(request.DateOfBirth.Value) : (DateOnly?)null,
        //                Mobile = request.PhoneNumber,
        //                Email = request.Username, // or request.Email if you have it separately
        //                Maritalstatusid = request.MaritalStatusId,
        //                Occupationid = request.OccupationId,
        //                Nationalityid = request.CountryId,
        //                //State = request.State,
        //                //Pincode = request.Pincode,
        //                Address = request.Address,
        //                Username = request.Username,
        //                Password = request.Password, // ⚠️ better to store hashed here too
        //                Age = request.DateOfBirth.HasValue ? (short?)(DateTime.Now.Year - request.DateOfBirth.Value.Year) : null,
        //                Visitdate = DateOnly.FromDateTime(DateTime.Now),
        //                Visittime = TimeOnly.FromDateTime(DateTime.Now),
        //                Isactive = true
        //            };

        //            _context.Patientdetails.Add(patient);
        //        }

        //        _context.SaveChanges();
        //        return "User created successfully.";
        //    }
        //    catch (Exception ex)
        //    {
        //        return $"Error: {ex.Message}";
        //    }
        //}

        //Register
        public RegisterResponseDto RegisterUser(RegisterDto registerDto)
        {
            if (string.IsNullOrWhiteSpace(registerDto.FirstName) ||
                string.IsNullOrWhiteSpace(registerDto.Password))
            {
                return new RegisterResponseDto { Message = "Invalid registration data." };
            }

            string role = string.IsNullOrWhiteSpace(registerDto.Role) ? "Patient" : registerDto.Role;
            if (role != "Patient" && role != "Doctor")
            {
                return new RegisterResponseDto { Message = "Role must be either 'Patient' or 'Doctor'." };
            }

            var existingUser = _context.Users
                .FirstOrDefault(u => u.Phonenumber == registerDto.PhoneNumber ||
                                     u.Username == registerDto.Username);

            if (existingUser != null)
            {
                return new RegisterResponseDto { Message = "User already exists." };
            }

            DateOnly? dateOfBirth = null;
            if (!string.IsNullOrWhiteSpace(registerDto.DateOfBirth))
            {
                if (DateTime.TryParse(registerDto.DateOfBirth, out var parsedDate))
                {
                    dateOfBirth = DateOnly.FromDateTime(parsedDate);
                }
            }

            var user = new User
            {
                Userid = Guid.NewGuid(),
                Firstname = registerDto.FirstName,
                Lastname = registerDto.LastName,
                Dateofbirth = dateOfBirth,
                Gender = registerDto.Gender,
                Username = registerDto.Username,
                Hashedpassword = PasswordHasher.HashPassword(registerDto.Password),
                Titleid = registerDto.TitleId,
                Occupationid = registerDto.OccupationId,
                Religionid = registerDto.ReligionId,
                Maritalstatusid = registerDto.MaritalStatusId,
                Phonenumber = registerDto.PhoneNumber,
                Address = registerDto.Address,
                Role = role,
                Isactive = true,
                Isdelete = false
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return new RegisterResponseDto
            {
                UserId = user.Userid,
                Username = user.Username ?? "",
                FullName = $"{user.Firstname} {user.Lastname}".Trim(),
                Role = user.Role,
                PhoneNumber = user.Phonenumber ?? "",
                Message = "User registered successfully!"
            };
        }

        // Get all users
        public List<UserResponseDto> GetAllUsers()
        {
            return _context.Users
                .Where(u => u.Isdelete == false)
                .Select(u => new UserResponseDto
                {
                    UserId = u.Userid,
                    FirstName = u.Firstname,
                    LastName = u.Lastname,
                    Specialization = u.Specialization,
                    Gender = u.Gender,
                    DateOfBirth = u.Dateofbirth.HasValue ? u.Dateofbirth.Value.ToDateTime(TimeOnly.MinValue) : (DateTime?)null,
                    PhoneNumber = u.Phonenumber,
                    Address = u.Address,
                    Username = u.Username,
                    Role = u.Role,
                    YearsOfExperience = u.Yearsofexperience,
                    Qualification = u.Qualification,
                    ConsultationFee = u.Consultationfee,
                    AvailabilityStartTime = u.Availabilitystarttime.HasValue ? u.Availabilitystarttime.Value.ToTimeSpan() : (TimeSpan?)null,
                    AvailabilityEndTime = u.Availabilityendtime.HasValue ? u.Availabilityendtime.Value.ToTimeSpan() : (TimeSpan?)null,
                    TitleId = u.Titleid,
                    CountryId = u.Countryid,
                    OccupationId = u.Occupationid,
                    ReligionId = u.Religionid,
                    MaritalStatusId = u.Maritalstatusid,
                    IsActive = u.Isactive.GetValueOrDefault(),
                    IsDeleted = u.Isdelete.GetValueOrDefault()
                }).ToList();
        }

        // Update user
        public string UpdateUser(Guid id, UserRequestDto request)
        {
            var user = _context.Users.FirstOrDefault(u => u.Userid == id && u.Isdelete == false);
            if (user == null) return "User not found.";

            user.Firstname = request.FirstName;
            user.Lastname = request.LastName;
            user.Specialization = request.Specialization;
            user.Gender = request.Gender;
            user.Dateofbirth = request.DateOfBirth.HasValue ? DateOnly.FromDateTime(request.DateOfBirth.Value) : (DateOnly?)null;
            user.Phonenumber = request.PhoneNumber;
            user.Address = request.Address;
            user.Username = request.Username;
            if (!string.IsNullOrEmpty(request.Password))
                user.Hashedpassword = request.Password; // 🔒 hash it
            user.Role = request.Role;
            user.Yearsofexperience = request.YearsOfExperience;
            user.Qualification = request.Qualification;
            user.Consultationfee = request.ConsultationFee;
            user.Availabilitystarttime = request.AvailabilityStartTime.HasValue ? TimeOnly.FromTimeSpan(request.AvailabilityStartTime.Value) : (TimeOnly?)null;
            user.Availabilityendtime = request.AvailabilityEndTime.HasValue ? TimeOnly.FromTimeSpan(request.AvailabilityEndTime.Value) : (TimeOnly?)null;
            user.Titleid = request.TitleId;
            user.Countryid = request.CountryId;
            user.Occupationid = request.OccupationId;
            user.Religionid = request.ReligionId;
            user.Maritalstatusid = request.MaritalStatusId;

            _context.SaveChanges();
            return "User updated successfully.";
        }

        // Soft delete user
        public string DeleteUser(Guid id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Userid == id && u.Isdelete == false);

            if (user == null)
            {
                return "User not found.";
            }

            user.Isdelete = true;
            user.Isactive = false; // Set IsActive to false

            _context.SaveChanges();

            return "User deleted successfully.";
        }

        // Get single user by Id
        public UserResponseDto GetUserById(Guid id)
        {
            var u = _context.Users.FirstOrDefault(x => x.Userid == id && x.Isdelete == false);
            if (u == null) return null;

            return new UserResponseDto
            {
                UserId = u.Userid,
                FirstName = u.Firstname,
                LastName = u.Lastname,
                Specialization = u.Specialization,
                Gender = u.Gender,
                DateOfBirth = u.Dateofbirth.HasValue ? u.Dateofbirth.Value.ToDateTime(TimeOnly.MinValue) : (DateTime?)null,
                PhoneNumber = u.Phonenumber,
                Address = u.Address,
                Username = u.Username,
                Role = u.Role,
                YearsOfExperience = u.Yearsofexperience,
                Qualification = u.Qualification,
                ConsultationFee = u.Consultationfee,
                AvailabilityStartTime = u.Availabilitystarttime.HasValue ? u.Availabilitystarttime.Value.ToTimeSpan() : (TimeSpan?)null,
                AvailabilityEndTime = u.Availabilityendtime.HasValue ? u.Availabilityendtime.Value.ToTimeSpan() : (TimeSpan?)null,
                TitleId = u.Titleid,
                CountryId = u.Countryid,
                OccupationId = u.Occupationid,
                ReligionId = u.Religionid,
                MaritalStatusId = u.Maritalstatusid,
                IsActive = u.Isactive.GetValueOrDefault(),
                IsDeleted = u.Isdelete.GetValueOrDefault()
            };
        }

        public List<userresponsemin> GetDoctors()
        {
            return _context.Users
                .Where(u => u.Role == "Doctor")
                .Select(u => new userresponsemin
                {
                   
                    FirstName = u.Firstname,
                    LastName = u.Lastname,
                    Specialization = u.Specialization,
                   Gender=u.Gender
                })
                .ToList();
        }

    }
}

