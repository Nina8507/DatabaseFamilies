﻿// <auto-generated />
using System;
using DatabaseFamilies.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DatabaseFamilies.Migrations
{
    [DbContext(typeof(CloudContext))]
    partial class CloudContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("DatabaseFamilies.Models.Adult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FamilyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("HairColor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Height")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("JobTitleId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("Weight")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("FamilyId");

                    b.HasIndex("JobTitleId");

                    b.ToTable("AdultTable");
                });

            modelBuilder.Entity("DatabaseFamilies.Models.Child", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FamilyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("HairColor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Height")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("Weight")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("FamilyId");

                    b.ToTable("ChildTable");
                });

            modelBuilder.Entity("DatabaseFamilies.Models.Family", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("HouseNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("FamilyTable");
                });

            modelBuilder.Entity("DatabaseFamilies.Models.Interest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ChildId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ChildId");

                    b.ToTable("Interest");
                });

            modelBuilder.Entity("DatabaseFamilies.Models.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("JobTitle")
                        .HasColumnType("TEXT");

                    b.Property<int>("Salary")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("DatabaseFamilies.Models.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ChildId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FamilyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ChildId");

                    b.HasIndex("FamilyId");

                    b.ToTable("Pet");
                });

            modelBuilder.Entity("DatabaseFamilies.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("UserTable");
                });

            modelBuilder.Entity("DatabaseFamilies.Models.Adult", b =>
                {
                    b.HasOne("DatabaseFamilies.Models.Family", null)
                        .WithMany("Adults")
                        .HasForeignKey("FamilyId");

                    b.HasOne("DatabaseFamilies.Models.Job", "JobTitle")
                        .WithMany()
                        .HasForeignKey("JobTitleId");

                    b.Navigation("JobTitle");
                });

            modelBuilder.Entity("DatabaseFamilies.Models.Child", b =>
                {
                    b.HasOne("DatabaseFamilies.Models.Family", null)
                        .WithMany("Children")
                        .HasForeignKey("FamilyId");
                });

            modelBuilder.Entity("DatabaseFamilies.Models.Interest", b =>
                {
                    b.HasOne("DatabaseFamilies.Models.Child", null)
                        .WithMany("Interests")
                        .HasForeignKey("ChildId");
                });

            modelBuilder.Entity("DatabaseFamilies.Models.Pet", b =>
                {
                    b.HasOne("DatabaseFamilies.Models.Child", null)
                        .WithMany("Pets")
                        .HasForeignKey("ChildId");

                    b.HasOne("DatabaseFamilies.Models.Family", null)
                        .WithMany("Pets")
                        .HasForeignKey("FamilyId");
                });

            modelBuilder.Entity("DatabaseFamilies.Models.Child", b =>
                {
                    b.Navigation("Interests");

                    b.Navigation("Pets");
                });

            modelBuilder.Entity("DatabaseFamilies.Models.Family", b =>
                {
                    b.Navigation("Adults");

                    b.Navigation("Children");

                    b.Navigation("Pets");
                });
#pragma warning restore 612, 618
        }
    }
}
