using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientManager.Models
{
    public class Client
    {
        [Required]
        public int Id { get; set; }

        [Required]
        
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

        public ICollection<ClientNotes>? Notes { get; set; }
    }
}
