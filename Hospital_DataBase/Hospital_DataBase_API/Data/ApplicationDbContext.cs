using Hospital_DataBase_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_DataBase_API.Data
{
    public class ApplicationDbContext : DbContext { 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        { 
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Procedure> Procedures { get; set; }
       
    }
}
