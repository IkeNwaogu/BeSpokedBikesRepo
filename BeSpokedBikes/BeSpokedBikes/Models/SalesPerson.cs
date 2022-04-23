using System.ComponentModel.DataAnnotations;
namespace BeSpokedBikes.Models
{
    public class SalesPerson
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string Phone { get; set; }
        [DataType(DataType.Date)] //This annotation makes it so only the date is displayed and not the time information
        public DateTime StartDate { get; set; } 
        [DataType(DataType.Date)]
        public DateTime TerminationDate { get; set; }
        public string? Manager { get; set; }
    }
}
