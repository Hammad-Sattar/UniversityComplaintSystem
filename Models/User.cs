using System;
using System.Collections.Generic;

namespace UniversityComplaintSystem.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public string Role { get; set; } = null!;

    public int? DepartmentId { get; set; }

    public virtual ICollection<ComplaintAction> ComplaintActions { get; set; } = new List<ComplaintAction>();

    public virtual ICollection<Complaint> Complaints { get; set; } = new List<Complaint>();

    public virtual Department? Department { get; set; }

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
}
