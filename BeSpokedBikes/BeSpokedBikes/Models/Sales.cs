using System.ComponentModel.DataAnnotations;

namespace BeSpokedBikes.Models
{
    public class Sales
    {
        public int ID { get; set; }
        public string? Product { get; set; }
        [Display(Name = "Sales Person")]
        public string? SalesPerson { get; set; }

        public string? Customer { get; set; }

        public float Commission { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Sales Date")]
        public DateTime SalesDate { get; set; } 

        
    }
}
