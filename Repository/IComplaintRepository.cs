using UniversityComplaintSystem.Models;

namespace UniversityComplaintSystem.Repository
    {
    public interface IComplaintRepository
        {
        Task<IEnumerable<Complaint>> GetAllAsync();
        Task<Complaint> GetByIdAsync(int id);
        Task AddAsync(Complaint complaint);
        Task UpdateAsync(Complaint complaint);
        Task DeleteAsync(int id);
        }

    }
