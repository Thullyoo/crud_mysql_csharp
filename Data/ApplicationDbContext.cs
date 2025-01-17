using Microsoft.EntityFrameworkCore;

namespace crud_mysql.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
     public DbSet<Person> Persons { get; set; }
}