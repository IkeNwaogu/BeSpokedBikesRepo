using System.ComponentModel.DataAnnotations;

namespace BeSpokedBikes.Models
{
    public class Customer
    {
        public int ID { get; set; }
        [Display(Name = "First")]
        public string? FirstName { get; set; }
        [Display(Name = "Last")]
        public string? LastName { get; set; }
        public string? Address { get; set; } 
        public string? Phone { get; set; }

        [DataType(DataType.Date)] //This annotation makes it so only the date is displayed and not the time information
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }   
    }
}
