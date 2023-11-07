using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public DbSet<Department> Department { get; set; }
    }


    [Table("Department")]
    public class Department
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
