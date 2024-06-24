using System.ComponentModel.DataAnnotations;

namespace ClientManager.Models
{
    public class Gym
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public ICollection<Client>? Clients { get; set; }
    }

}
