namespace UniversityComplaintSystem.Models.Dtos
    {
    public class UserDto
        {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string? DepartmentName { get; set; } // Show department name instead of full object
        }



    public class CreateUserDto
        {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public int? DepartmentId { get; set; }
        }


    }
