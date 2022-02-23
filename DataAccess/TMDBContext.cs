using Microsoft.EntityFrameworkCore;
using TaskManagerMVC.Models;

namespace TaskManagerMVC.DataAccess
{
    public class TMDBContext : DbContext
    {
        public TMDBContext(DbContextOptions options) : base(options) { }
        public DbSet<TaskModel> Tasks { get; set; }
    }
}
