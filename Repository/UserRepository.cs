
using Microsoft.EntityFrameworkCore;
using System;
using UniversityComplaintSystem.Models;
using UniversityComplaintSystem.Repository;

namespace ComplaintSystem.Repositories
    {
    public class UserRepository : IUserRepository
        {
        private readonly ComplainsDbContext _context;

        public UserRepository(ComplainsDbContext context)
            {
            _context = context;
            }

        public async Task<IEnumerable<User>> GetAllAsync()
            {
            return await _context.Users.Include(u => u.Department).ToListAsync();
            }

        public async Task<User?> GetByIdAsync(int id)
            {
            return await _context.Users.Include(u => u.Department)
                                       .FirstOrDefaultAsync(u => u.UserId == id);
            }

        public async Task<User> AddAsync(User user)
            {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
            }

        public async Task<User?> UpdateAsync(User user)
            {
            var existing = await _context.Users.FindAsync(user.UserId);
            if (existing == null) return null;

            _context.Entry(existing).CurrentValues.SetValues(user);
            await _context.SaveChangesAsync();
            return existing;
            }

        public async Task<bool> DeleteAsync(int id)
            {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
            }
        }
    }
