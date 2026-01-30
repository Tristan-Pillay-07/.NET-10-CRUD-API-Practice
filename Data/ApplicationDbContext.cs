using Microsoft.EntityFrameworkCore;
using NewCRUDAPI.Models;

namespace NewCRUDAPI.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Student> Students => Set<Student>();
    }
}
