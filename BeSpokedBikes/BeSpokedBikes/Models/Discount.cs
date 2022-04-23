namespace BeSpokedBikes.Models
{
    public class Discount
    {
        public int ID { get; set; }
        public Products? product { get; set; }
        public string? BeginDate { get; set; }
        public string? EndDate { get; set; }
        public double DiscountPercentage { get; set; }
    }
}
