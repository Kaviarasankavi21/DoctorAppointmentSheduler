using DoctorAppointmentScheduler.Application.DTOclass;
using DoctorAppointmentScheduler.Domain.Models;
using DoctorAppointmentScheduler.Infrastructure.RepositoryInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DoctorAppointmentScheduler.Infrastructure.RepositoryImplementation
{
    public class Titlerepository : ITitle
    {
        private readonly DoctorappointmentContext _context;

        public Titlerepository(DoctorappointmentContext context)
        {
            _context = context;
        }

        public string addTitle(string titleName)
        {
            if (string.IsNullOrWhiteSpace(titleName))
                return "Title name is required.";

            var exists = _context.Titles
                .Any(t => (t.Isdeleted == false || t.Isdeleted == null) &&
                          EF.Functions.ILike(t.Titlename, titleName.Trim()));

            if (exists)
                return "Title already exists.";

            var title = new Title
            {
                Titleid = Guid.NewGuid(),
                Titlename = titleName.Trim(),
                Isdeleted = false
            };

            _context.Titles.Add(title);
            _context.SaveChanges();

            return "Title added successfully.";
        }


        public List<Titleresponsedto> getallTitle()
        {
            return _context.Titles
                .Where(c => c.Isdeleted == false)
                .Select(c => new Titleresponsedto
                {
                    Titleid = c.Titleid,
                    Titlename = c.Titlename,
                    isdeleted = c.Isdeleted
                })
                .ToList();
        }

        public string updateTitle(Guid titleId, string titleName)
        {
            var title = _context.Titles
                .FirstOrDefault(t => t.Titleid == titleId && !t.Isdeleted == false);

            if (title == null)
                return "Title not found.";

            title.Titlename = titleName;
            _context.SaveChanges();

            return "Title updated successfully.";
        }

        public string deleteTitle(Guid Titleid)
        {
            var Title = _context.Titles.FirstOrDefault(c => c.Titleid == Titleid);
            if (Title == null)
                return "Title not found";

            Title.Isdeleted = true;
            _context.SaveChanges();
            return "Title deleted successfully";
        }

        public string updateTttitle(Guid Titleid, string Titlename)
        {
            var Title = _context.Titles.FirstOrDefault(c => c.Titleid == Titleid);
            if (Title == null)
                return "Title not found";

            Title.Titlename = Titlename;
            _context.SaveChanges();
            return "Title updated successfully";
        }
    }
}
