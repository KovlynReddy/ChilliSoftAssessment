﻿// <auto-generated />
using System;
using ChilliSoftAssessment.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChilliSoftAssessment.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChilliSoftDLL.Models.Employee", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeePosition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ep")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            id = 1,
                            EmployeeId = "EMID01",
                            EmployeeName = "KovlynReddy",
                            EmployeePosition = "Executive",
                            EmployeeStatus = "Employeed",
                            ep = 0
                        },
                        new
                        {
                            id = 2,
                            EmployeeId = "EMID02",
                            EmployeeName = "KatelynReddy",
                            EmployeePosition = "Member",
                            EmployeeStatus = "Employeed",
                            ep = 0
                        },
                        new
                        {
                            id = 3,
                            EmployeeId = "EMID03",
                            EmployeeName = "ShanMchelm",
                            EmployeePosition = "MinutesMaster",
                            EmployeeStatus = "Employeed",
                            ep = 0
                        });
                });

            modelBuilder.Entity("ChilliSoftDLL.Models.Item", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Categorey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeResponsible")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemTalker")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastMeetingId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("meetingstatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ms")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            id = 1,
                            Categorey = "Discussion",
                            Description = "Disucessing new potencial projects",
                            EmployeeResponsible = "EMID01",
                            ItemId = "ProjectId1",
                            ItemName = "Project Meeting",
                            ms = 0
                        },
                        new
                        {
                            id = 2,
                            Categorey = "Discussion",
                            Description = "Disucessing potencial project fixes",
                            EmployeeResponsible = "EMID02",
                            ItemId = "ProjectId2",
                            ItemName = "Project Discussion",
                            ms = 0
                        });
                });

            modelBuilder.Entity("ChilliSoftDLL.Models.Meeting", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Caption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("HoursDuration")
                        .HasColumnType("int");

                    b.Property<string>("MeetingId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MinutesMaster")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeElapsed")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("mt")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Meetings");
                });

            modelBuilder.Entity("ChilliSoftDLL.Models.Message", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MeetingId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MessageId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MinutesMaster")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoomId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenderId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeSent")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("ChilliSoftDLL.Models.MinutesEntry", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmployeeId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MinutesId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MinutesMasterId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("MinutesEntry");
                });

            modelBuilder.Entity("ChilliSoftDLL.Models.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Rateing")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReportDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReportName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReportsId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("ChilliSoftDLL.Models.Room", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatorId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoomId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeEnded")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeStarted")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
