namespace ClientManager.Models
{
    public class ClientNotesDto
    {
        public int Id { get; set; }

        public int ClientID { get; set; }

        public Client? Client { get; set; }

        public string? Note_Content { get; set; }

        public DateOnly Updated_Date { get; set; }

        public int Updated_By { get; set; }

        public DateOnly Created_Date { get; set; }

        public int Created_By { get; set; }

        public DateOnly Deleted_date { get; set; }

        public int Deleted_By { get; set; }

        public Boolean Is_Deleted { get; set; }


    }
}