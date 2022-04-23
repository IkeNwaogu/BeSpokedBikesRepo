using System.ComponentModel.DataAnnotations;

namespace BeSpokedBikes.Models
{
    public class Sales
    {
        public int ID { get; set; }
        public string? Product { get; set; }
        public string? SalesPerson { get; set; }

        public Customer? Customer { get; set; }

        [DataType(DataType.Date)]
        public DateTime SalesDate { get; set; } //Todo: Get datetype
    }
}
