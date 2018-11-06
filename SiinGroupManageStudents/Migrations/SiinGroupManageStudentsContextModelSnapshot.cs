﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SiinGroupManageStudents.Models;

namespace SiinGroupManageStudents.Migrations
{
    [DbContext(typeof(SiinGroupManageStudentsContext))]
    partial class SiinGroupManageStudentsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SiinGroupManageStudents.Models.Mark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StudentRollNumber");

                    b.Property<int>("SubjectMark");

                    b.Property<string>("SubjectName");

                    b.HasKey("Id");

                    b.HasIndex("StudentRollNumber");

                    b.ToTable("Mark");

                    b.HasData(
                        new { Id = 1, StudentRollNumber = "D00538", SubjectMark = 9, SubjectName = "Java Core" },
                        new { Id = 2, StudentRollNumber = "D00529", SubjectMark = 7, SubjectName = "C#" },
                        new { Id = 3, StudentRollNumber = "D00553", SubjectMark = 8, SubjectName = "PHP" }
                    );
                });

            modelBuilder.Entity("SiinGroupManageStudents.Models.Student", b =>
                {
                    b.Property<string>("RollNumber")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email");

                    b.Property<string>("FullName");

                    b.Property<int>("Status");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("RollNumber");

                    b.ToTable("Student");

                    b.HasData(
                        new { RollNumber = "D00538", CreatedAt = new DateTime(2018, 11, 6, 19, 37, 56, 400, DateTimeKind.Local), Email = "admin@siingroup.com", FullName = "Ngô Văn Tuấn", Status = 0, UpdatedAt = new DateTime(2018, 11, 6, 19, 37, 56, 400, DateTimeKind.Local) },
                        new { RollNumber = "D00529", CreatedAt = new DateTime(2018, 11, 6, 19, 37, 56, 400, DateTimeKind.Local), Email = "nhuconcua@gmail.com", FullName = "Phan Văn Hoàng Hưng", Status = 0, UpdatedAt = new DateTime(2018, 11, 6, 19, 37, 56, 400, DateTimeKind.Local) },
                        new { RollNumber = "D00553", CreatedAt = new DateTime(2018, 11, 6, 19, 37, 56, 400, DateTimeKind.Local), Email = "ngaccoc@gmail.com", FullName = "Nguyễn Văn Ngọc", Status = 0, UpdatedAt = new DateTime(2018, 11, 6, 19, 37, 56, 400, DateTimeKind.Local) }
                    );
                });

            modelBuilder.Entity("SiinGroupManageStudents.Models.Mark", b =>
                {
                    b.HasOne("SiinGroupManageStudents.Models.Student", "Student")
                        .WithMany("Marks")
                        .HasForeignKey("StudentRollNumber");
                });
#pragma warning restore 612, 618
        }
    }
}