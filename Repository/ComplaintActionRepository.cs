using Microsoft.EntityFrameworkCore;
using System;
using UniversityComplaintSystem.Models;
using UniversityComplaintSystem.Repository;

public class ComplaintActionRepository : IComplaintActionRepository
    {
    private readonly ComplainsDbContext _context;

    public ComplaintActionRepository(ComplainsDbContext context)
        {
        _context = context;
        }

    public async Task<IEnumerable<ComplaintAction>> GetAllByComplaintIdAsync(int complaintId)
        {
        return await _context.ComplaintActions
            .Include(a => a.ActionByUser)
            .Where(a => a.ComplaintId == complaintId)
            .ToListAsync();
        }

    public async Task<ComplaintAction> GetByIdAsync(int id)
        {
        return await _context.ComplaintActions
            .Include(a => a.ActionByUser)
            .FirstOrDefaultAsync(a => a.ActionId == id);
        }

    public async Task<ComplaintAction> AddAsync(ComplaintAction action)
        {
        _context.ComplaintActions.Add(action);
        await _context.SaveChangesAsync();
        return action;
        }
    }
