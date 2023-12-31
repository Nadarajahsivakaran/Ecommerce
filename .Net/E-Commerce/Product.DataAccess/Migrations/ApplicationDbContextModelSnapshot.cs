﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Product.DataAccess;

#nullable disable

namespace Product.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Product.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IsDelete")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Electronics",
                            CreatedAt = new DateTime(2023, 9, 3, 21, 56, 38, 653, DateTimeKind.Local).AddTicks(8973),
                            IsDelete = 0,
                            UpdatedAt = new DateTime(2023, 9, 3, 21, 56, 38, 653, DateTimeKind.Local).AddTicks(8990)
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Furniture",
                            CreatedAt = new DateTime(2023, 9, 3, 21, 56, 38, 653, DateTimeKind.Local).AddTicks(8992),
                            IsDelete = 0,
                            UpdatedAt = new DateTime(2023, 9, 3, 21, 56, 38, 653, DateTimeKind.Local).AddTicks(8993)
                        });
                });

            modelBuilder.Entity("Product.Models.Products", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IsDelete")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 1,
                            CreatedAt = new DateTime(2023, 9, 3, 21, 56, 38, 653, DateTimeKind.Local).AddTicks(9140),
                            IsDelete = 0,
                            Price = 55250m,
                            ProductName = "Phones",
                            UpdatedAt = new DateTime(2023, 9, 3, 21, 56, 38, 653, DateTimeKind.Local).AddTicks(9141)
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 2,
                            CreatedAt = new DateTime(2023, 9, 3, 21, 56, 38, 653, DateTimeKind.Local).AddTicks(9145),
                            IsDelete = 0,
                            Price = 95000m,
                            ProductName = "Sofa",
                            UpdatedAt = new DateTime(2023, 9, 3, 21, 56, 38, 653, DateTimeKind.Local).AddTicks(9145)
                        });
                });

            modelBuilder.Entity("Product.Models.Products", b =>
                {
                    b.HasOne("Product.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Product.Models.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
