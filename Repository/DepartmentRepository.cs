using Microsoft.EntityFrameworkCore;
using System;
using UniversityComplaintSystem.Models;

namespace UniversityComplaintSystem.Repository
    {
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ComplainsDbContext _context;

        public DepartmentRepository(ComplainsDbContext context)
            {
            _context = context;
            }

        public async Task<IEnumerable<Department>> GetAllAsync()
            {
            return await _context.Departments.Include(d => d.HeadUser).ToListAsync();
            }

        public async Task<Department?> GetByIdAsync(int id)
            {
            return await _context.Departments.Include(d => d.HeadUser)
                                             .FirstOrDefaultAsync(d => d.DepartmentId == id);
            }

        public async Task<Department> AddAsync(Department department)
            {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return department;
            }

        public async Task<Department?> UpdateAsync(Department department)
            {
            var existing = await _context.Departments.FindAsync(department.DepartmentId);
            if (existing == null) return null;

            _context.Entry(existing).CurrentValues.SetValues(department);
            await _context.SaveChangesAsync();
            return existing;
            }

        public async Task<bool> DeleteAsync(int id)
            {
            var department = await _context.Departments.FindAsync(id);
            if (department == null) return false;

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            return true;
            }
        }
    }
