using Microsoft.EntityFrameworkCore;
using BeSpokedBikes.Data;
namespace BeSpokedBikes.Models
{
 
    public class Report
    {
        //@param SalesPerson, itemsSold
        public static Dictionary<string, int> numberOfItemsSold = new Dictionary<string, int>();
        //@param SalesPerson, TotalCommisionEarned
        public static Dictionary<string, double> commission = new Dictionary<string, double>();
        
        public static List<string> employees = new List<string>();





        public static List<List<string>> theReport = new List<List<string>>();

     
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BeSpokedBikesContext(
                serviceProvider.GetRequiredService<DbContextOptions<BeSpokedBikesContext>>()))
            {
                if (context == null || context.Products == null || context.Customer == null || context.Discount == null || context.Sales == null || context.SalesPerson == null)
                {
                    throw new ArgumentNullException("The context is NULL");
                }

                if(context.Sales.Any())
                {
                    var SalesRep = from person in context.Sales select person.SalesPerson;
                    /*
                     * Using Sales table instead of SalesPerson table because Sales table already has First and last name built as one string
                     * Adds every sales person to the numberOfItemsSold dictionary, commission dictionary, and to the employees list
                     * dictionaries must have unique keys so everytime we run into an employee name we have already added, we continue 
                     */
                    foreach (var _saleRep in SalesRep)
                    {
                        if (employees.Contains(_saleRep))
                        {
                            continue;
                        }
                        else
                        {
                            employees.Add(_saleRep.ToString());
                        }
                        
                    }
                    theReport.Add(employees);
                  

                    /*
                     * The idea behind this foreach loop is that everytime a sales person made a sale, their name
                     * was added to the sales table along with the sale they made. Therefor if I add up the number of times
                     * their name appears in the table, that is equivalent to how many sales they made
                     */
                    foreach (var _salesRep in SalesRep)
                    {

                        if (!numberOfItemsSold.ContainsKey(_salesRep))
                        {
                            numberOfItemsSold.Add(_salesRep, 1);
                            
                        }
                        else if(numberOfItemsSold.ContainsKey(_salesRep))
                        {
                            numberOfItemsSold[_salesRep.ToString()]++;
                        }
                    }
                    List<string> temp = new List<string>();
                    foreach (var item in numberOfItemsSold)
                    {
                        temp.Add(item.Value.ToString());
                    }
                   
                    theReport.Add(temp);



                    //Calculate commission and number of items sold
                }

            }
        }
    }
}
