using Microsoft.EntityFrameworkCore;

namespace ImageuploadApi.Models.Domain
{
    public class DatabaseContext :DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options ): base(options)
        {
            
        }

        public DbSet<Productsimg> productsimg  { get; set; }
    }
}
