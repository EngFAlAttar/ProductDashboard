using Microsoft.EntityFrameworkCore;

namespace ProductDashboard.Data
{
    public class AppDbContext :DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
