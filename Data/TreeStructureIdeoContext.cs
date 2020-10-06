using Microsoft.EntityFrameworkCore;
using TreeStructureIdeo.Models;

namespace TreeStructureIdeo.Data
{
    public class TreeStructureIdeoContext : DbContext
    {
        public TreeStructureIdeoContext(DbContextOptions<TreeStructureIdeoContext> options)
            : base(options)
        {
        }

        public DbSet<Knots> Knots { get; set; }
    }
}

