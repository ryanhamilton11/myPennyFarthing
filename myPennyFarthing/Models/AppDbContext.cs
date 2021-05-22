using System;
using Microsoft.EntityFrameworkCore;

namespace myPennyFarthing.Models
{
    public class AppDbContext : DbContext
    {
        //   F I E L D S   &   P R O P E R T I E S
        public DbSet<Bike> Bikes { get; set; }
        public DbSet<MX> MXs { get; set; }
        public DbSet<Ride> Rides { get; set; }
        public DbSet<User> Users { get; set; }



        //   C O N S T R U C T O R S
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        //   M E T H O D S
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //   U S E R S
            modelBuilder.Entity<User>().HasIndex(u => u.UserName).IsUnique();

            //   B I K E S


            //   M A I N T E N A N C E    A C T I O N S


            //   R I D E S
        }
    }
}
