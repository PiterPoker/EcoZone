﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DataAccessProvider;

namespace ecozone.Migrations
{
    [DbContext(typeof(DomainModelContext))]
    [Migration("20170118205712_DataMigrationEco")]
    partial class DataMigrationEco
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Model.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsApproved");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("PhotoPath");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Domain.Model.Block", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ImageType");

                    b.Property<int>("Number");

                    b.Property<string>("Text");

                    b.Property<int>("TypeId");

                    b.Property<int>("UnitId");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.HasIndex("UnitId");

                    b.ToTable("Blocks");
                });

            modelBuilder.Entity("Domain.Model.BlockType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("BlockTypes");
                });

            modelBuilder.Entity("Domain.Model.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthorId");

                    b.Property<string>("Body");

                    b.Property<DateTime>("Date");

                    b.Property<int>("UnitId");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("UnitId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Domain.Model.Like", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthorId");

                    b.Property<int>("UnitId");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("UnitId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("Domain.Model.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Domain.Model.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthorId");

                    b.Property<string>("CoverType");

                    b.Property<DateTime>("Date");

                    b.Property<bool>("IsApproved");

                    b.Property<string>("Name");

                    b.Property<int?>("PendingUnitId");

                    b.Property<long>("Views");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("PendingUnitId");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("Domain.Model.UnitTags", b =>
                {
                    b.Property<int>("TagId");

                    b.Property<int>("UnitId");

                    b.HasKey("TagId", "UnitId");

                    b.HasIndex("TagId");

                    b.HasIndex("UnitId");

                    b.ToTable("UnitTagses");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Domain.Model.Block", b =>
                {
                    b.HasOne("Domain.Model.BlockType", "Type")
                        .WithMany("Blocks")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Model.Unit", "Unit")
                        .WithMany("Blocks")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Model.Comment", b =>
                {
                    b.HasOne("Domain.Model.ApplicationUser", "Author")
                        .WithMany("Comments")
                        .HasForeignKey("AuthorId");

                    b.HasOne("Domain.Model.Unit", "Unit")
                        .WithMany("Comments")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Model.Like", b =>
                {
                    b.HasOne("Domain.Model.ApplicationUser", "Author")
                        .WithMany("Likes")
                        .HasForeignKey("AuthorId");

                    b.HasOne("Domain.Model.Unit", "Unit")
                        .WithMany("Likes")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Model.Unit", b =>
                {
                    b.HasOne("Domain.Model.ApplicationUser", "Author")
                        .WithMany("Units")
                        .HasForeignKey("AuthorId");

                    b.HasOne("Domain.Model.Unit", "PendingUnit")
                        .WithMany()
                        .HasForeignKey("PendingUnitId");
                });

            modelBuilder.Entity("Domain.Model.UnitTags", b =>
                {
                    b.HasOne("Domain.Model.Tag", "Tag")
                        .WithMany("Units")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Model.Unit", "Unit")
                        .WithMany("Tags")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Domain.Model.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Domain.Model.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Model.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}