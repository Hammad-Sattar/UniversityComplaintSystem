using UniversityComplaintSystem.Models;

namespace UniversityComplaintSystem.Repository
    {
    public interface IComplaintActionRepository
        {
        Task<IEnumerable<ComplaintAction>> GetAllByComplaintIdAsync(int complaintId);
        Task<ComplaintAction> GetByIdAsync(int id);
        Task<ComplaintAction> AddAsync(ComplaintAction action);
        }

    }
