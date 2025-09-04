namespace UniversityComplaintSystem.Models.Dtos
    {
    public class DepartmentDto
        {
        public int DepartmentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? HeadName { get; set; } // Head User Name
        }

    public class CreateDepartmentDto
        {
        public string Name { get; set; } = string.Empty;
        public int HeadUserId { get; set; } // Must be a valid UserId with role DeptHead
        }
    }
