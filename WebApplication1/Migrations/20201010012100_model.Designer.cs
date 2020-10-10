﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Models;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(tennisContext))]
    [Migration("20201010012100_model")]
    partial class model
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication1.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("event_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnName("date")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description")
                        .HasColumnType("text");

                    b.Property<int>("MemberId")
                        .HasColumnName("member_id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.HasKey("EventId");

                    b.HasIndex("MemberId");

                    b.ToTable("event");

                    b.HasData(
                        new
                        {
                            EventId = 1,
                            Date = new DateTime(2018, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Free event, everyone is welcomed to join!",
                            MemberId = 2,
                            Name = "Fun With The Familiy"
                        },
                        new
                        {
                            EventId = 2,
                            Date = new DateTime(2018, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Complimentary tennis lessons with Roger Federer",
                            MemberId = 4,
                            Name = "Roger Federer Free Lessons"
                        },
                        new
                        {
                            EventId = 3,
                            Date = new DateTime(2018, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The weekly 1 on 1 matches",
                            MemberId = 2,
                            Name = "Weekly 1v1 Competitions"
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("member_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Biography")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Dob")
                        .HasColumnName("dob")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnName("gender")
                        .HasColumnType("varchar(1)")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("role_id")
                        .HasColumnType("int")
                        .HasDefaultValue(3);

                    b.HasKey("MemberId");

                    b.HasIndex("RoleId");

                    b.ToTable("member");

                    b.HasData(
                        new
                        {
                            MemberId = 1,
                            Biography = "admin",
                            Dob = new DateTime(1991, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admin@admin.com",
                            Gender = "M",
                            Name = "admin",
                            Nickname = "admin",
                            Password = "admin",
                            RoleId = 1
                        },
                        new
                        {
                            MemberId = 2,
                            Biography = "coach",
                            Dob = new DateTime(1991, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "coach@coach.com",
                            Gender = "M",
                            Name = "coach",
                            Nickname = "coach",
                            Password = "coach",
                            RoleId = 2
                        },
                        new
                        {
                            MemberId = 3,
                            Biography = "new member",
                            Dob = new DateTime(1991, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "member@member.com",
                            Gender = "M",
                            Name = "John Doe",
                            Nickname = "jjdoe",
                            Password = "member",
                            RoleId = 3
                        },
                        new
                        {
                            MemberId = 4,
                            Biography = "Roger Federer is a Swiss professional tennis player ",
                            Dob = new DateTime(1981, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "roger@r.com",
                            Gender = "M",
                            Name = "Roger Federer",
                            Nickname = "The King",
                            Password = "roger",
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("role_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleType")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("role_type")
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Member");

                    b.HasKey("RoleId");

                    b.ToTable("role");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            RoleType = "Admin"
                        },
                        new
                        {
                            RoleId = 2,
                            RoleType = "Coach"
                        },
                        new
                        {
                            RoleId = 3,
                            RoleType = "Member"
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.Schedule", b =>
                {
                    b.Property<int>("ScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("schedule_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EventId")
                        .HasColumnName("event_id")
                        .HasColumnType("int");

                    b.Property<int>("MemberId")
                        .HasColumnName("member_id")
                        .HasColumnType("int");

                    b.HasKey("ScheduleId");

                    b.HasIndex("EventId");

                    b.HasIndex("MemberId");

                    b.ToTable("schedule");
                });

            modelBuilder.Entity("WebApplication1.Models.Event", b =>
                {
                    b.HasOne("WebApplication1.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication1.Models.Member", b =>
                {
                    b.HasOne("WebApplication1.Models.Role", "Role")
                        .WithMany("Members")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication1.Models.Schedule", b =>
                {
                    b.HasOne("WebApplication1.Models.Event", "Event")
                        .WithMany("Schedules")
                        .HasForeignKey("EventId");

                    b.HasOne("WebApplication1.Models.Member", "Member")
                        .WithMany("Schedules")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
