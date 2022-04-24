using Microsoft.EntityFrameworkCore;
using BeSpokedBikes.Data;
using BeSpokedBikes.Models;
namespace BeSpokedBikes
{
    public class Duplicates
    {
        public bool CheckForDuplicates(BeSpokedBikesContext context,IServiceProvider serviceProvider)
        {
            using (context = new BeSpokedBikesContext(
                serviceProvider.GetRequiredService<DbContextOptions<BeSpokedBikesContext>>()))
            {
                if (context == null || context.Products == null)
                {
                    throw new ArgumentNullException(nameof(context));
                }
             
            }

                return false;
        }
    }
}
