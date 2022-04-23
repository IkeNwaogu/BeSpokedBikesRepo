using System.ComponentModel.DataAnnotations;

namespace BeSpokedBikes.Models
{
    public class Discount
    {
        public int ID { get; set; }
        public string? Product { get; set; }

        [DataType(DataType.Date)]
        public DateTime BeginDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public double DiscountPercentage { get; set; }
    }
}
