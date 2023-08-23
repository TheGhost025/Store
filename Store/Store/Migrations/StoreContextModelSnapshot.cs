﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Store.Entities;

#nullable disable

namespace Store.Migrations
{
    [DbContext(typeof(StoreContext))]
    partial class StoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Store.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("cust_id")
                        .HasColumnType("int");

                    b.Property<int>("prod_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("cust_id");

                    b.HasIndex("prod_id");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("Store.Models.ConfermCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<int>("cust_id")
                        .HasColumnType("int");

                    b.Property<int>("prod_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("cust_id");

                    b.HasIndex("prod_id");

                    b.ToTable("ConfermCart");
                });

            modelBuilder.Entity("Store.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConfPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Store.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("sell_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("sell_id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Store.Models.Seller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConfPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Seller");
                });

            modelBuilder.Entity("Store.Models.Cart", b =>
                {
                    b.HasOne("Store.Models.Customer", "Customer")
                        .WithMany("Cart")
                        .HasForeignKey("cust_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Store.Models.Product", "Product")
                        .WithMany("Cart")
                        .HasForeignKey("prod_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Store.Models.ConfermCart", b =>
                {
                    b.HasOne("Store.Models.Customer", "Customer")
                        .WithMany("ConfermCart")
                        .HasForeignKey("cust_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Store.Models.Product", "Product")
                        .WithMany("ConfermCart")
                        .HasForeignKey("prod_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Store.Models.Product", b =>
                {
                    b.HasOne("Store.Models.Seller", "Seller")
                        .WithMany("Product")
                        .HasForeignKey("sell_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("Store.Models.Customer", b =>
                {
                    b.Navigation("Cart");

                    b.Navigation("ConfermCart");
                });

            modelBuilder.Entity("Store.Models.Product", b =>
                {
                    b.Navigation("Cart");

                    b.Navigation("ConfermCart");
                });

            modelBuilder.Entity("Store.Models.Seller", b =>
                {
                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}