using System.ComponentModel.DataAnnotations;

namespace BeSpokedBikes.Models
{
    public class Discount
    {
        public int ID { get; set; }
        public string? Product { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Begin Date")]
        public DateTime BeginDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Discount Percentage")]
        public double DiscountPercentage { get; set; }
    }
}
