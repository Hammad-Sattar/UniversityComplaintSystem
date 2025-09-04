using Microsoft.EntityFrameworkCore;
using UniversityComplaintSystem.Models;

namespace UniversityComplaintSystem.Repository
    {
    public class ComplaintRepository : IComplaintRepository
        {
        private readonly ComplainsDbContext _context;

        public ComplaintRepository(ComplainsDbContext context)
            {
            _context = context;
            }

        public async Task<IEnumerable<Complaint>> GetAllAsync()
            {
            return await _context.Complaints
                .Include(c => c.User)
                .Include(c => c.Department)
                .ToListAsync();
            }

        public async Task<Complaint> GetByIdAsync(int id)
            {
            return await _context.Complaints
                .Include(c => c.User)
                .Include(c => c.Department)
                .FirstOrDefaultAsync(c => c.ComplaintId == id);
            }

        public async Task AddAsync(Complaint complaint)
            {
            await _context.Complaints.AddAsync(complaint);
            await _context.SaveChangesAsync();
            }

        public async Task UpdateAsync(Complaint complaint)
            {
            _context.Complaints.Update(complaint);
            await _context.SaveChangesAsync();
            }

        public async Task DeleteAsync(int id)
            {
            var complaint = await _context.Complaints.FindAsync(id);
            if (complaint != null)
                {
                _context.Complaints.Remove(complaint);
                await _context.SaveChangesAsync();
                }
            }
        }
    }
