using ContactManagementApp.DTO;
using ContactManagementApp.Models;

namespace ContactManagementApp.Interfaces;

public interface IContactRepository
{
    Task<ICollection<ContactDto>> GetAllAsync();
    
    ValueTask<Contact?> GetByIdAsync(int id);
    
    Task AddAsync(Contact contact);
    
    Task UpdateAsync(Contact contact);
    
    Task DeleteAsync(int id);
}