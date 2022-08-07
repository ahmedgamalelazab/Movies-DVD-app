using Microsoft.EntityFrameworkCore;
using App.Models;

namespace App.Data {

    public class SalatyDbContext : DbContext{

        public SalatyDbContext()
        {
            
        }


        public SalatyDbContext(DbContextOptions<SalatyDbContext>options):base(options)
        {
            
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Salah> Salahs { get; set; }
        public virtual DbSet<Tasbeeh> Tasbeehs { get; set; }

    }


}