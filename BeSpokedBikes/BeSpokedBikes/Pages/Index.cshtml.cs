using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BeSpokedBikes.Models;
namespace BeSpokedBikes.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public  Dictionary<string, int> numberOfItemsSold = Report.numberOfItemsSold;
        public List<string> employees = Report.employees;
        public List<List<string>> report = Report.theReport;
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public int number = Report.numberOfItemsSold["Reynold Quarcoo"];
        public void OnGet()
        {
            String name = employees.First();
        }
    }
}