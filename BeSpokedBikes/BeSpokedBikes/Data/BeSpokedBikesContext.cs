#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BeSpokedBikes.Models;

namespace BeSpokedBikes.Data
{
    public class BeSpokedBikesContext : DbContext
    {
        public BeSpokedBikesContext (DbContextOptions<BeSpokedBikesContext> options)
            : base(options)
        {
        }

        public DbSet<BeSpokedBikes.Models.Products> Products { get; set; }

        public DbSet<BeSpokedBikes.Models.Discount> Discount { get; set; }

        public DbSet<BeSpokedBikes.Models.Customer> Customer { get; set; }

        public DbSet<BeSpokedBikes.Models.Sales> Sales { get; set; }

        public DbSet<BeSpokedBikes.Models.SalesPerson> SalesPerson { get; set; }
    }
}
