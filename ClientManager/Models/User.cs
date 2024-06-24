using System.ComponentModel.DataAnnotations;

namespace ClientManager.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public string? UserName { get; set; }

        public ICollection<Client>? Clients { get; set; }
    }
}
