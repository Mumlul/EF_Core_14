using EF_Core.Models;
using EF_Core.Rules.Validations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EF_Core.Models.Context
{
    public class AppDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<InterestGroup> InterestGroups { get; set; }
        public DbSet<UserInterestGroup> UserInterestGroups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
        {
            //optionsbuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Users;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;");
            optionsbuilder.UseSqlServer("Server=sql.ects;Database=PL;User Id = student_07;Password = student_07;TrustServerCertificate = True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
            new Role { Id = 1, Title = "Пользователь" },
            new Role { Id = 2, Title = "Менеджер" },
            new Role { Id = 3, Title = "Администратор" }
            );

            modelBuilder.Entity<User>().HasData(
            new User {Id=1,Login="asd",Name="Sasha",Email="a.ploskikh@list.ru",Password="qwerty1_W",CreatedAt=DateTime.Today,RoleId=1 }    
            );

            modelBuilder.Entity<User>()
            .HasOne(s => s.Profile)
            .WithOne(ps => ps.User)
            .HasForeignKey<UserProfile>(ps => ps.UserId);


            modelBuilder.Entity<Role>() 
            .HasMany(g => g.Users)
            .WithOne(s => s.Role)
            .HasForeignKey(s => s.RoleId);

            modelBuilder.Entity<UserInterestGroup>()
            .HasKey(uig => new { uig.Userid, uig.InterestGroupId });

            modelBuilder.Entity<UserInterestGroup>()
            .HasOne(uig => uig.User)
            .WithMany(g => g.InterestGroups)
            .HasForeignKey(uig => uig.Userid);

            modelBuilder.Entity<UserInterestGroup>()
            .HasOne(uig => uig.InterestGroup)
            .WithMany(g => g.UserInterestGroup)
            .HasForeignKey(uig => uig.InterestGroupId);


        }

       
    }
}
