using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeSpokedBikes.Models
{
    public class Products
    {
        //Todo: Find datatype tag for money

        //The ID field is required by the database for the primary key
        public int ID { get; set; }

        public string? Name { get; set; }
        public string? Manufacturer { get; set; } 
        public string? Style { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Purchase Price")]
        public double PurchasePrice { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Sale Price")]
        public double SalePrice { get; set; }
        public int QtyOnHand { get; set; }
        [Display(Name = "Commission Percentage")]
        public double CommissionPercentage { get; set; }    
    }
}
