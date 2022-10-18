using JiuJitsuTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace JiuJitsuTracker.DataAccess;

public class ApplicationDbContext : DbContext
{
    // Options recieved in the constructor get passed to the base class which is DbContext
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    // creating table of class info named classes with the class info model properties
    public DbSet<ClassInfo> Classes { get; set; }
}
