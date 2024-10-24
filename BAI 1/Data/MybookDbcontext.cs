using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BAI_1.Data
{
    public class MybookDbcontext : IdentityDbContext<ApplicationUser>
    {
        public MybookDbcontext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}
