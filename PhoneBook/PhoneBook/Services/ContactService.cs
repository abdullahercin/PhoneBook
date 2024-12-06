using Microsoft.EntityFrameworkCore;
using PhoneBook.Data;
using PhoneBook.Models;

namespace PhoneBook.Services
{
    public class ContactService
    {
        private readonly AppDbContext _context;

        public ContactService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddContactAsync(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return contact.Id;
        }

        public async Task<IEnumerable<Contact>> GetContactsAsync()
        {
            return await _context.Contacts.ToListAsync();
        }
    }
}
