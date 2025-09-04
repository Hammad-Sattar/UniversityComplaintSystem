namespace UniversityComplaintSystem.Models.Dtos
    {
    public class ComplaintActionDto
        {
        public int ActionId { get; set; }
        public int ComplaintId { get; set; }
        public string Action { get; set; }
        public DateTime ActionDate { get; set; }
        public string ActionByUser { get; set; }
        }


    public class CreateComplaintActionDto
        {
        public int ComplaintId { get; set; }
        public int ActionByUserId { get; set; }
        public string Action { get; set; }
        }
    }
