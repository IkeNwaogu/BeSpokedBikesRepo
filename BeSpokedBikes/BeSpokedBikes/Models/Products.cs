using System.ComponentModel.DataAnnotations;
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
        public double PurchasePrice { get; set; }   
        public double SalePrice { get; set; }
        public int QtyOnHand { get; set; }
        public double CommissionPercentage { get; set; }    
    }
}
