using Microsoft.EntityFrameworkCore;

namespace Woffu.PruebaTecnica.Webapi.Models
{
    public class JobTitleContext : DbContext
    {
        public JobTitleContext(DbContextOptions<JobTitleContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<JobTitle> JobTitles { get; set; }
    }
}
