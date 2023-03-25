﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace UserService.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230325165549_AddedOtherTables")]
    partial class AddedOtherTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SharedModal.Modals.BidHistory", b =>
                {
                    b.Property<int>("BidHistoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BidHistoryID"));

                    b.Property<decimal>("BidAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("BidTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ProductID")
                        .HasColumnType("int");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("BidHistoryID");

                    b.HasIndex("ProductID");

                    b.HasIndex("UserID");

                    b.ToTable("BidHistories");
                });

            modelBuilder.Entity("SharedModal.Modals.CatagoryType", b =>
                {
                    b.Property<int>("CatagoryTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CatagoryTypeID"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductCatagoryID")
                        .HasColumnType("int");

                    b.HasKey("CatagoryTypeID");

                    b.HasIndex("ProductCatagoryID");

                    b.ToTable("CatagoryTypes");
                });

            modelBuilder.Entity("SharedModal.Modals.City", b =>
                {
                    b.Property<int>("CityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityID"));

                    b.Property<int?>("DivisionID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityID");

                    b.HasIndex("DivisionID");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("SharedModal.Modals.Division", b =>
                {
                    b.Property<int>("DivisionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DivisionID"));

                    b.Property<string>("DivisionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DivisionID");

                    b.ToTable("Divisions");
                });

            modelBuilder.Entity("SharedModal.Modals.Payment", b =>
                {
                    b.Property<int>("PaymentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentID"));

                    b.Property<decimal>("PaymentAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("PaymentTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentTypeID")
                        .HasColumnType("int");

                    b.Property<int?>("ProductID")
                        .HasColumnType("int");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("PaymentID");

                    b.HasIndex("PaymentTypeID");

                    b.HasIndex("ProductID");

                    b.HasIndex("UserID");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("SharedModal.Modals.PaymentType", b =>
                {
                    b.Property<int>("PaymentTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentTypeID"));

                    b.Property<string>("PaymentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PaymentTypeID");

                    b.ToTable("PaymentTypes");
                });

            modelBuilder.Entity("SharedModal.Modals.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"));

                    b.Property<decimal?>("AskingPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("BaseImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CatagoryTypeID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("TopBid")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ProductID");

                    b.HasIndex("CatagoryTypeID");

                    b.HasIndex("UserID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SharedModal.Modals.ProductCatagory", b =>
                {
                    b.Property<int>("ProductCatagoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductCatagoryID"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductCatagoryID");

                    b.ToTable("ProductCatagories");
                });

            modelBuilder.Entity("SharedModal.Modals.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsEmailVerified")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPhoneVerified")
                        .HasColumnType("bit");

                    b.Property<string>("NIDNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddressOne")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddressTwo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.HasIndex("CityID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SharedModal.Modals.BidHistory", b =>
                {
                    b.HasOne("SharedModal.Modals.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID");

                    b.HasOne("SharedModal.Modals.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SharedModal.Modals.CatagoryType", b =>
                {
                    b.HasOne("SharedModal.Modals.ProductCatagory", "ProductCatagory")
                        .WithMany("CatagoryTypes")
                        .HasForeignKey("ProductCatagoryID");

                    b.Navigation("ProductCatagory");
                });

            modelBuilder.Entity("SharedModal.Modals.City", b =>
                {
                    b.HasOne("SharedModal.Modals.Division", "Division")
                        .WithMany("Cities")
                        .HasForeignKey("DivisionID");

                    b.Navigation("Division");
                });

            modelBuilder.Entity("SharedModal.Modals.Payment", b =>
                {
                    b.HasOne("SharedModal.Modals.PaymentType", "PaymentType")
                        .WithMany()
                        .HasForeignKey("PaymentTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SharedModal.Modals.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID");

                    b.HasOne("SharedModal.Modals.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("PaymentType");

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SharedModal.Modals.Product", b =>
                {
                    b.HasOne("SharedModal.Modals.CatagoryType", "CatagoryType")
                        .WithMany()
                        .HasForeignKey("CatagoryTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SharedModal.Modals.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CatagoryType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SharedModal.Modals.User", b =>
                {
                    b.HasOne("SharedModal.Modals.City", "City")
                        .WithMany()
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("SharedModal.Modals.Division", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("SharedModal.Modals.ProductCatagory", b =>
                {
                    b.Navigation("CatagoryTypes");
                });
#pragma warning restore 612, 618
        }
    }
}