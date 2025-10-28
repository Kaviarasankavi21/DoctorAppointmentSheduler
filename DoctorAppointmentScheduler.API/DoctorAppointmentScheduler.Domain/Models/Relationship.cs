using System;
using System.Collections.Generic;

namespace DoctorAppointmentScheduler.Domain.Models;

public partial class Relationship
{
    public Guid Relationshipid { get; set; }

    public string Relationshipname { get; set; } = null!;

    public bool? Isdeleted { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
