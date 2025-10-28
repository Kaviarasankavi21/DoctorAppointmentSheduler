using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentScheduler.Application.DTOclass
{
    public class UserRequestDto
    {
        [Required] public string FirstName { get; set; }
         public string LastName { get; set; }
        public string? Specialization { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [Required] public string PhoneNumber { get; set; }
        public string Address { get; set; }
        [Required] public string Username { get; set; }
        [Required] public string Password { get; set; }
        [Required] public string Role { get; set; }
        public int? YearsOfExperience { get; set; }
        public string Qualification { get; set; }
        public decimal? ConsultationFee { get; set; }
        public TimeSpan? AvailabilityStartTime { get; set; }
        public TimeSpan? AvailabilityEndTime { get; set; }
        public Guid? TitleId { get; set; }
        public Guid? CountryId { get; set; }
        public Guid? OccupationId { get; set; }
        public Guid? ReligionId { get; set; }
        public Guid? MaritalStatusId { get; set; }
    }

    public class UserResponseDto
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialization { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public int? YearsOfExperience { get; set; }
        public string Qualification { get; set; }
        public decimal? ConsultationFee { get; set; }
        public TimeSpan? AvailabilityStartTime { get; set; }
        public TimeSpan? AvailabilityEndTime { get; set; }
        public Guid? TitleId { get; set; }
        public Guid? CountryId { get; set; }
        public Guid? OccupationId { get; set; }
        public Guid? ReligionId { get; set; }
        public Guid? MaritalStatusId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

    }


    public class RegisterDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? DateOfBirth { get; set; }   // string to allow flexibility, parsed later
        public string? Gender { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public Guid? TitleId { get; set; }
        public Guid? OccupationId { get; set; }
        public Guid? ReligionId { get; set; }
        public Guid? MaritalStatusId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Role { get; set; }  // optional; defaults to "Patient" in repo
    }


    public class RegisterResponseDto
    {
        public Guid UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = "Patient";  // default patient
        public string PhoneNumber { get; set; } = string.Empty;
        public string Message {get; set; } = string.Empty; // success / error message
    }

    public class userresponsemin
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialization { get; set; }
        public string Gender { get; set; }
    }
}
