namespace UniversityComplaintSystem.Models.Dtos
    {
    public class ComplaintDto
        {
        public int ComplaintId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public int UserId { get; set; }
        public string UserName { get; set; }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        }

    }
