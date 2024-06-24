using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClientManager.Models
{
    public class ClientDto
    {
        public int Id { get; set; }
        public int GymId { get; set; }

        [ForeignKey("GymId")]
        public Gym? Gym { get; set; }

        [Required]

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
