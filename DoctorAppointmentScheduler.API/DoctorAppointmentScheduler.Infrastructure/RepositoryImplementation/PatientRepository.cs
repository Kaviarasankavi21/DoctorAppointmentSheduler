using DoctorAppointmentScheduler.Application.DTOclass;
using DoctorAppointmentScheduler.Domain.Models;
using DoctorAppointmentScheduler.Infrastructure.RepositoryInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DoctorAppointmentScheduler.Infrastructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly DoctorappointmentContext _context;

        public PatientRepository(DoctorappointmentContext context)
        {
            _context = context;
        }

        public IEnumerable<PatientDto> GetAll()
        {
            // Materialize first to avoid EF Core client projection issues
            var patients = _context.Patientdetails
                                   .AsNoTracking()
                                   .ToList();  // Load into memory

            return patients.Select(p => MapToDto(p));
        }

        public PatientDto GetById(Guid patientId)
        {
            var patient = _context.Patientdetails
                                  .AsNoTracking()
                                  .FirstOrDefault(p => p.Patientid == patientId);

            return patient != null ? MapToDto(patient) : null!;

        }

        public PatientDto Add(PatientDto dto)
        {
            var patient = new Patientdetail
            {
                Patientid = Guid.NewGuid(),
                Titleid = dto.Titleid,
                Name = dto.Name,
                Gender = dto.Gender,
                Dob = dto.Dob,
                Mobile = dto.Mobile,
                Email = dto.Email,
                Maritalstatusid = dto.Maritalstatusid,
                Occupationid = dto.Occupationid,
                State = dto.State,
                Pincode = dto.Pincode,
                Address = dto.Address,
                Isactive = dto.Isactive
            };

            _context.Patientdetails.Add(patient);
            _context.SaveChanges();

            return MapToDto(patient);
        }

        public PatientDto Update(PatientDto dto)
        {
            var existing = _context.Patientdetails.FirstOrDefault(p => p.Patientid == dto.Patientid);
            if (existing == null) return null!;

            existing.Titleid = dto.Titleid;
            existing.Name = dto.Name;
            existing.Gender = dto.Gender;
            existing.Dob = dto.Dob;
            existing.Mobile = dto.Mobile;
            existing.Email = dto.Email;
            existing.Maritalstatusid = dto.Maritalstatusid;
            existing.Occupationid = dto.Occupationid;
            existing.State = dto.State;
            existing.Pincode = dto.Pincode;
            existing.Address = dto.Address;
            existing.Isactive = dto.Isactive;

            _context.Patientdetails.Update(existing);
            _context.SaveChanges();

            return MapToDto(existing);
        }

        public bool Delete(Guid patientId)
        {
            var patient = _context.Patientdetails.FirstOrDefault(p => p.Patientid == patientId);
            if (patient == null) return false;

            _context.Patientdetails.Remove(patient);
            _context.SaveChanges();
            return true;
        }

        // Mapping method (can stay instance method now)
        private PatientDto MapToDto(Patientdetail p)
        {
            return new PatientDto
            {
                Patientid = p.Patientid,
                Titleid = p.Titleid,
                Name = p.Name,
                Gender = p.Gender,
                Dob = p.Dob,
                Mobile = p.Mobile,
                Email = p.Email,
                Maritalstatusid = p.Maritalstatusid,
                Occupationid = p.Occupationid,
                State = p.State,
                Pincode = p.Pincode,
                Address = p.Address,
                Isactive = p.Isactive
            };
        }
    }
}
