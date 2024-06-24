using System.ComponentModel.DataAnnotations.Schema;

namespace ClientManager.Models
{
    public class Membership
    {
        public int Id { get; set; }
        
        public int Client_Id {get; set; }

        [ForeignKey("Client_Id")]
        public Client? Client { get; set; }

        public DateOnly Start_Date { get; set; }

        public DateOnly End_Date { get; set; }

        
    }
}
