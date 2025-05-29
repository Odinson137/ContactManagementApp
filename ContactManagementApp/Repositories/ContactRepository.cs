using ContactManagementApp.Data;
using ContactManagementApp.DTO;
using ContactManagementApp.Interfaces;
using ContactManagementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManagementApp.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly ApplicationDbContext _context;

    public ContactRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ICollection<ContactDto>> GetAllAsync()
    {
        return await _context.Contacts.Select(c => new ContactDto
        {
            Id = c.Id,
            Name = c.Name,
            MobilePhone = c.MobilePhone,
            JobTitle = c.JobTitle,
            BirthDate = c.BirthDate,
        }).ToListAsync();
    }

    public ValueTask<Contact?> GetByIdAsync(int id)
    {
        return _context.Contacts.FindAsync(id);
    }

    public async Task AddAsync(Contact contact)
    {
        _context.Contacts.Add(contact);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Contact contact)
    {
        _context.Contacts.Update(contact);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var contact = await _context.Contacts.FindAsync(id);
        if (contact != null)
        {
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
        }
    }
}