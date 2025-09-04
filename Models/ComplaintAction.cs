using System;
using System.Collections.Generic;

namespace UniversityComplaintSystem.Models;

public partial class ComplaintAction
{
    public int ActionId { get; set; }

    public int ComplaintId { get; set; }

    public int ActionByUserId { get; set; }

    public string Action { get; set; } = null!;

    public DateTime? ActionDate { get; set; }

    public virtual User ActionByUser { get; set; } = null!;

    public virtual Complaint Complaint { get; set; } = null!;
}
