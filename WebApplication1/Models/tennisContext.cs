using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public partial class tennisContext : DbContext
    {

        public tennisContext(DbContextOptions<tennisContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Event { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<Role> Role { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=WebApplication3;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("event");

                entity.Property(e => e.EventId).HasColumnName("event_id");


                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.MemberId).HasColumnName("member_id");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.ToTable("member");

                entity.Property(e => e.MemberId).HasColumnName("member_id");

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("date");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnName("gender")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("role_id")
                .HasDefaultValue(3);



            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("schedule");

                entity.Property(e => e.ScheduleId).HasColumnName("schedule_id");

                entity.Property(e => e.MemberId).HasColumnName("member_id");

                entity.Property(e => e.EventId).HasColumnName("event_id");

            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.RoleType).HasColumnName("role_type")
                .HasDefaultValue("Member");


            });

            modelBuilder.Entity<Member>().HasData(
                new
                {
                    MemberId = 1,
                    Name = "admin",
                    Nickname = "admin",
                    Dob = DateTime.Parse("1991-01-01"),
                    Gender = "M",
                    Biography = "admin",
                    Email = "admin@admin.com",
                    Password = "admin",
                    RoleId = 1
                },
                new
                {
                    MemberId = 2,
                    Name = "coach",
                    Nickname = "coach",
                    Dob = DateTime.Parse("1991-01-01"),
                    Gender = "M",
                    Biography = "coach",
                    Email = "coach@coach.com",
                    Password = "coach",
                    RoleId = 2
                },
                 new
                 {
                     MemberId = 3,
                     Name = "John Doe",
                     Nickname = "jjdoe",
                     Dob = DateTime.Parse("1991-01-01"),
                     Gender = "M",
                     Biography = "new member",
                     Email = "member@member.com",
                     Password = "member",
                     RoleId = 3
                 },
                 new
                 {
                     MemberId = 4,
                     Name = "Roger Federer",
                     Nickname = "The King",
                     Dob = DateTime.Parse("1981-08-08"),
                     Gender = "M",
                     Biography = "Roger Federer is a Swiss professional tennis player ",
                     Email = "roger@r.com",
                     Password = "roger",
                     RoleId = 2
                 });

            modelBuilder.Entity<Role>().HasData(
                new { RoleId = 1, RoleType = "Admin" },
                new { RoleId = 2, RoleType = "Coach" },
                new { RoleId = 3, RoleType = "Member" });

            modelBuilder.Entity<Event>().HasData(
                new { EventId = 1, Name = "Fun With The Familiy", Description = "Free event, everyone is welcomed to join!", MemberId = 2, Date = DateTime.Parse("2018-10-01") },
                new { EventId = 2, Name = "Roger Federer Free Lessons", Description = "Complimentary tennis lessons with Roger Federer", MemberId = 4, Date = DateTime.Parse("2018-11-14") },
                new { EventId = 3, Name = "Weekly 1v1 Competitions", Description = "The weekly 1 on 1 matches", MemberId = 2, Date = DateTime.Parse("2018-12-28") });
        }
    }
}
