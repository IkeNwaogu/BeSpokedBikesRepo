﻿// <auto-generated />
using System;
using BeSpokedBikes.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BeSpokedBikes.Migrations
{
    [DbContext(typeof(BeSpokedBikesContext))]
    partial class BeSpokedBikesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BeSpokedBikes.Models.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("BeSpokedBikes.Models.Discount", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("BeginDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("DiscountPercentage")
                        .HasColumnType("float");

                    b.Property<string>("EndDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("productID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("productID");

                    b.ToTable("Discount");
                });

            modelBuilder.Entity("BeSpokedBikes.Models.Products", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<double>("CommissionPercentage")
                        .HasColumnType("float");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PurchasePrice")
                        .HasColumnType("float");

                    b.Property<int>("QtyOnHand")
                        .HasColumnType("int");

                    b.Property<double>("SalePrice")
                        .HasColumnType("float");

                    b.Property<string>("Style")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("BeSpokedBikes.Models.Sales", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("CustomerID")
                        .HasColumnType("int");

                    b.Property<string>("Product")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SalesDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SalesPerson")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("BeSpokedBikes.Models.SalesPerson", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manager")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TerminationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("SalesPerson");
                });

            modelBuilder.Entity("BeSpokedBikes.Models.Discount", b =>
                {
                    b.HasOne("BeSpokedBikes.Models.Products", "product")
                        .WithMany()
                        .HasForeignKey("productID");

                    b.Navigation("product");
                });

            modelBuilder.Entity("BeSpokedBikes.Models.Sales", b =>
                {
                    b.HasOne("BeSpokedBikes.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID");

                    b.Navigation("Customer");
                });
#pragma warning restore 612, 618
        }
    }
}