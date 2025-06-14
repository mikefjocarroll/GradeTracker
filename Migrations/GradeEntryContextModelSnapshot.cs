﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using gradeTracker.Data;

#nullable disable

namespace gradeTracker.Migrations
{
    [DbContext(typeof(GradeEntryContext))]
    partial class GradeEntryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.5");

            modelBuilder.Entity("gradeTracker.Models.GradeEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AssignmentName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Score")
                        .HasColumnType("REAL");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("TotalPossible")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("GradeEntries");
                });
#pragma warning restore 612, 618
        }
    }
}
