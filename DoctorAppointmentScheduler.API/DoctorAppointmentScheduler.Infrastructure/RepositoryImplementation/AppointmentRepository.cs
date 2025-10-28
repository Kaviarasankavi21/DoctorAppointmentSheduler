using DoctorAppointmentScheduler.Application.DTOclass;
using DoctorAppointmentScheduler.Domain.Models;
using DoctorAppointmentScheduler.Infrastructure.RepositoryInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentScheduler.Infrastructure.RepositoryImplementation
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly DoctorappointmentContext _context;

        public AppointmentRepository(DoctorappointmentContext context)
        {
            _context = context;
        }

        // Get all appointments
        //public List<AppointmentDto> GetAll()
        //{
        //    return _context.Appointments
        //        .Include(a => a.Patient)
        //        .Include(a => a.Doctor)
        //        .Select(entity => new AppointmentDto
        //        {
        //            AppointmentId = entity.Appointmentid,
        //            PatientId = entity.Patientid,
        //            PatientName = entity.Patient != null
        //                          ? entity.Patient.Firstname + " " + entity.Patient.Lastname
        //                          : "N/A",
        //            DoctorId = entity.Doctorid,
        //            DoctorName = entity.Doctor != null
        //                         ? entity.Doctor.Firstname + " " + entity.Doctor.Lastname
        //                         : "N/A",
        //            AppointmentDate = entity.Appointmentdate,
        //            AppointmentTime = entity.Appointmenttime,
        //            Reason = entity.Reason ?? string.Empty,
        //            Status = entity.Status.HasValue ? entity.Status.Value : 0,
        //            Specialization = entity.Doctor != null && entity.Doctor.Specialization != null
        //                                ? entity.Doctor.Specialization
        //                                : "N/A",
        //            Createdate = entity.Createdate,
        //            Updatedate = entity.Updatedate,
        //        })
        //        .ToList();
        //}

        public List<AppointmentDto> GetAll()
        {
            return (from appt in _context.Appointments
                    join patient in _context.Patientdetails
                        on appt.Patientid equals patient.Patientid into patJoin
                    from p in patJoin.DefaultIfEmpty()   // Left join to safely get patient
                    select new AppointmentDto
                    {
                        AppointmentId = appt.Appointmentid,
                        PatientId = appt.Patientid,
                        PatientName = p != null ? p.Name : "N/A",  // Patient name from join
                        DoctorId = appt.Doctorid,
                        DoctorName = appt.Doctor != null
                                     ? appt.Doctor.Firstname + " " + appt.Doctor.Lastname
                                     : "N/A",  // Keep original logic for doctor
                        AppointmentDate = appt.Appointmentdate,
                        AppointmentTime = appt.Appointmenttime,
                        Reason = appt.Reason ?? string.Empty,
                        Status = appt.Status.HasValue ? appt.Status.Value : 0,
                        Specialization = appt.Doctor != null && appt.Doctor.Specialization != null
                                            ? appt.Doctor.Specialization
                                            : "N/A",
                        Createdate = appt.Createdate,
                        Updatedate = appt.Updatedate,
                    }).ToList();
        }



        public List<PatientsDDL> GetPatients(string username)
        {
            return _context.Patientdetails
                .Where(p => p.Username == username)   // ✅ filter by username
                .Select(entity => new PatientsDDL
                {
                    Patientid = entity.Patientid,
                    PatientName = entity.Name
                })
                .ToList();
        }



        // Get appointment by ID
        public AppointmentDto GetById(Guid id)
        {
            var entity = _context.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .FirstOrDefault(a => a.Appointmentid == id);

            if (entity == null) return null;

            return new AppointmentDto
            {
                AppointmentId = entity.Appointmentid,
                PatientId = entity.Patientid,
                PatientName = entity.Patient.Firstname,
                DoctorId = entity.Doctorid,
                DoctorName = entity.Doctor.Firstname,
                AppointmentDate = entity.Appointmentdate,
                AppointmentTime = entity.Appointmenttime,
                Reason = entity.Reason ?? string.Empty,
                Status = entity.Status.HasValue ? entity.Status.Value : 0,
                Createdate = entity.Createdate,
                Updatedate = entity.Updatedate
            };
        } // Add appointment
        public void Add(AppointmentDto dto)
        {
            var patientExists = _context.Patientdetails.Any(p => p.Patientid == dto.PatientId);
            var entity = new Appointment
            {


                //Appointmentid = dto.AppointmentId == Guid.Empty ? Guid.NewGuid() : dto.AppointmentId,
                Patientid = dto.PatientId,
                Doctorid = dto.DoctorId,
                Appointmentdate = dto.AppointmentDate,
                Appointmenttime = dto.AppointmentTime,
                Reason = dto.Reason,
                Status = (short?)dto.Status
            };

            _context.Appointments.Add(entity);
            _context.SaveChanges();
        }

        // Update appointment
        public void Update(AppointmentDto dto)
        {
            var entity = _context.Appointments.FirstOrDefault(a => a.Appointmentid == dto.AppointmentId);
            if (entity != null)
            {
                entity.Patientid = (Guid)dto.PatientId;
                entity.Doctorid = dto.DoctorId;
                entity.Appointmentdate = dto.AppointmentDate;
                entity.Appointmenttime = dto.AppointmentTime;
                entity.Reason = dto.Reason;
                entity.Status = (short?)dto.Status;

                _context.Appointments.Update(entity);
                _context.SaveChanges();
            }
        }

        // Delete appointment
        public void Delete(Guid id)
        {
            var entity = _context.Appointments.FirstOrDefault(a => a.Appointmentid == id);
            if (entity != null)
            {
                _context.Appointments.Remove(entity);
                _context.SaveChanges();
            }
        }


        public AppointmentDetailDto GetAppointmentDetails(Guid id)
        {
            var appointment = _context.Appointments
                .Where(a => a.Appointmentid == id)
                .Select(a => new AppointmentDetailDto
                {
                    AppointmentId = a.Appointmentid,
                    PatientId = a.Patientid,
                    PatientName = a.Patient.Firstname,
                    DoctorId = a.Doctorid,
                    DoctorName = a.Doctor.Firstname,
                    Specialization = a.Doctor.Specialization,
                    Phone = a.Doctor.Phonenumber,
                    Gender = a.Doctor.Gender,
                    Qualification = a.Doctor.Qualification,
                    YearsOfExperience = a.Doctor.Yearsofexperience,
                    ConsultationFee = a.Doctor.Consultationfee,
                    AvailabilityStartTime = a.Doctor.Availabilitystarttime,
                    AvailabilityEndTime = a.Doctor.Availabilityendtime,
                    AppointmentDate = a.Appointmentdate,
                    AppointmentTime = a.Appointmenttime,
                    Reason = a.Reason,
                    Createdate = a.Createdate,
                    Updatedate = a.Updatedate
                }).FirstOrDefault();

            return appointment;
        }
    }
}

