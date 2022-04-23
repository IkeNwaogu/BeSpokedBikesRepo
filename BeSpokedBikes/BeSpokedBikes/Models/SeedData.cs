using Microsoft.EntityFrameworkCore;
using BeSpokedBikes.Data;

namespace BeSpokedBikes.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            //grabs the data context
            using(var context = new BeSpokedBikesContext(
                serviceProvider.GetRequiredService<DbContextOptions<BeSpokedBikesContext>>()))
            {
                if(context == null || context.Products == null || context.Customer == null || context.Discount == null || context.Sales == null || context.SalesPerson == null)
                {
                    throw new ArgumentNullException("The context is NULL");
                }

                //If there aren't any product entries currently,then add some
                if(!(context.Products.Any()))
                {
                    context.Products.AddRange(
                        new Products
                        {
                            Name = "Thunderbolt",
                            Manufacturer = "Tesla",
                            Style = "Rough Rider",
                            PurchasePrice = 400,
                            SalePrice = 600,
                            QtyOnHand = 50,
                            CommissionPercentage = 0.10
                        },
                        new Products
                        {
                            Name = "Venom",
                            Manufacturer = "Toyota",
                            Style = "Smooth Rider",
                            PurchasePrice = 700,
                            SalePrice = 1000,
                            QtyOnHand = 50,
                            CommissionPercentage = 0.18
                        },
                        new Products
                        {
                            Name = "Spitfire",
                            Manufacturer = "Stellantis",
                            Style = "Ocean Rider",
                            PurchasePrice = 600,
                            SalePrice = 900,
                            QtyOnHand = 50,
                            CommissionPercentage = 0.10
                        },
                        new Products
                        {
                            Name = "Interceptor",
                            Manufacturer = "Tesla",
                            Style = "Smooth Rider",
                            PurchasePrice = 280,
                            SalePrice = 730,
                            QtyOnHand = 50,
                            CommissionPercentage = 0.30
                        },
                        new Products
                        {
                            Name = "Thunderbird",
                            Manufacturer = "Ford Motor",
                            Style = "Rough Rider",
                            PurchasePrice = 1050,
                            SalePrice = 1800,
                            QtyOnHand = 50,
                            CommissionPercentage = 0.12
                        },
                        new Products
                        {
                            Name = "Black Lightning",
                            Manufacturer = "Toyota",
                            Style = "Sky Rider",
                            PurchasePrice = 535,
                            SalePrice = 800,
                            QtyOnHand = 50,
                            CommissionPercentage = 0.10
                        },
                        new Products
                        {
                            Name = "Commando",
                            Manufacturer = "Stellantis",
                            Style = "Ocean Rider",
                            PurchasePrice = 300,
                            SalePrice = 750,
                            QtyOnHand = 50,
                            CommissionPercentage = 0.08
                        }
                      );
                }

                if(!context.Customer.Any())
                {
                    context.Customer.AddRange(
                        new Customer
                        {
                            FirstName = "Charlie",
                            LastName =  "Brown",
                            Address = "5146 board fish road",
                            Phone = "404-210-0035",
                            //year,month,day
                            StartDate = new DateTime(2010,3,7)
                        },
                         new Customer
                         {
                             FirstName = "Sally",
                             LastName = "May",
                             Address = "5132 slim slam road",
                             Phone = "404-643-0133",
                             //year,month,day
                             StartDate = new DateTime(2008, 5, 2)
                         },
                          new Customer
                          {
                              FirstName = "Garry",
                              LastName = "Coleman",
                              Address = "5145 crude oil road",
                              Phone = "678-913-2235",
                              //year,month,day
                              StartDate = new DateTime(2012, 5, 9)
                          },
                           new Customer
                           {
                               FirstName = "Linda",
                               LastName = "Earnest",
                               Address = "2568 big jammy road",
                               Phone = "678-314-0023",
                               //year,month,day
                               StartDate = new DateTime(2010, 7, 7)
                           },
                            new Customer
                            {
                                FirstName = "Ronnie",
                                LastName = "erwin",
                                Address = "5457 waptap road",
                                Phone = "770-936-1824",
                                //year,month,day
                                StartDate = new DateTime(2012, 5, 5)
                            },
                             new Customer
                             {
                                 FirstName = "Mark",
                                 LastName = "turner",
                                 Address = "5177 longway road",
                                 Phone = "404-324-5555",
                                 //year,month,day
                                 StartDate = new DateTime(2014, 3, 7)
                             }
                        );
                }

                if(!context.Discount.Any())
                {
                    context.Discount.AddRange(
                        new Discount
                        {
                            Product = "Thunderbolt",
                            BeginDate = new DateTime(2013,5,7),
                            EndDate = new DateTime(2013,5, 25),
                            DiscountPercentage = 0.10
                        },
                         new Discount
                         {
                             Product = "Interceptor",
                             BeginDate = new DateTime(2015, 2, 3),
                             EndDate = new DateTime(2015, 3, 25),
                             DiscountPercentage = 0.10
                         },
                          new Discount
                          {
                              Product = "Commando",
                              BeginDate = new DateTime(2013, 3, 7),
                              EndDate = new DateTime(2013, 8, 17),
                              DiscountPercentage = 0.10
                          }
                        );     
                }
                if(!context.SalesPerson.Any())
                {
                    context.SalesPerson.AddRange(
                        new SalesPerson
                        {
                            FirstName = "Michael",
                            LastName = "Scott",
                            Address = "9310 garry fish lane",
                            Phone = "404-915-2734",
                            //year,month,day
                            StartDate = new DateTime(2008, 4, 1),
                            TerminationDate = new DateTime(2999, 4, 1),
                            Manager = "Larry WiseGuy"
                        },
                        new SalesPerson
                        {
                            FirstName = "Reynold",
                            LastName = "Quarcoo",
                            Address = "8150 grubhub lane",
                            Phone = "404-235-0612",
                            //year,month,day
                            StartDate = new DateTime(2010, 5, 5),
                            TerminationDate = new DateTime(2999, 4, 1),
                            Manager = "Herman WiseGuy"
                        },
                        new SalesPerson
                        {
                            FirstName = "Adam",
                            LastName = "Phillips",
                            Address = "1456 yellow lane",
                            Phone = "404-543-4732",
                            //year,month,day
                            StartDate = new DateTime(2008, 4, 1),
                            TerminationDate = new DateTime(2999, 4, 1),
                            Manager = "Larry WiseGuy"
                        },
                        new SalesPerson
                        {
                            FirstName = "Stacy",
                            LastName = "Adams",
                            Address = "1427 goop lane",
                            Phone = "678-282-0014",
                            //year,month,day
                            StartDate = new DateTime(2015, 7, 2),
                            TerminationDate = new DateTime(2999, 4, 1),
                            Manager = "Herman WiseGuy"
                        }
                        ); 
                }
                //saves the changes
                context.SaveChanges();
            }
        }
    }
}
