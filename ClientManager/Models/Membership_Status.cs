using System.ComponentModel.DataAnnotations.Schema;

namespace ClientManager.Models
{
    public class Membership_Status
    {
        public int Id { get; set; }

        public string? status { get; set; }

        public string? Status_Description { get; set; }

        public DateOnly Updated_Date { get; set; }

        public int Updated_By { get; set; }

        public DateOnly Created_Date { get; set; }

        public int Created_By { get; set; }

        public DateOnly Deleted_date { get; set; }

        public int Deleted_By { get; set; }

        public Boolean Is_Deleted { get; set; }


    }
}

