using Microsoft.EntityFrameworkCore;

namespace PhoneBook.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Models.Contact> Contacts { get; set; } = default!;

        //Veritabanını otomatik oluştur
        public void InitiliazeDatabase()
        {
            Database.EnsureCreated();
        }
    }
}
