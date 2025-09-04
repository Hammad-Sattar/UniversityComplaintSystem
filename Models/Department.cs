using System;
using System.Collections.Generic;

namespace UniversityComplaintSystem.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string Name { get; set; } = null!;

    public int HeadUserId { get; set; }

    public virtual ICollection<Complaint> Complaints { get; set; } = new List<Complaint>();

    public virtual User HeadUser { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
