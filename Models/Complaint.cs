using System;
using System.Collections.Generic;

namespace UniversityComplaintSystem.Models;

public partial class Complaint
{
    public int ComplaintId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int UserId { get; set; }

    public int DepartmentId { get; set; }

    public virtual ICollection<ComplaintAction> ComplaintActions { get; set; } = new List<ComplaintAction>();

    public virtual Department Department { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
