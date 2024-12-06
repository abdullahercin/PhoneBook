using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required] public string Name { get; set; } = default!;

        [Required] public string PhoneNumber { get; set; } = default!;

        public string? Email { get; set; }
        public string? Company { get; set; }
    }
}
