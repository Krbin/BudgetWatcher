﻿// <auto-generated />
using System;
using BudgetWatcher.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BudgetWatcher.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240505120151_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.29");

            modelBuilder.Entity("BudgetWatcher.Models.BalanceModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("CreationDateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Balances");
                });

            modelBuilder.Entity("BudgetWatcher.Models.ExpenseModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("CreationDateTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateOfTransaction")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Recipient")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.Property<bool>("wasSend")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("BudgetWatcher.Models.RevenueModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("CreationDateTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateOfTransaction")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Sender")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("wasReceived")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Revenues");
                });

            modelBuilder.Entity("BudgetWatcher.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccessLevel")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ExpenseModelId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastAccessDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("RevenueModelId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasAlternateKey("Salt");

                    b.HasIndex("ExpenseModelId");

                    b.HasIndex("RevenueModelId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BudgetWatcher.Models.UserModel", b =>
                {
                    b.HasOne("BudgetWatcher.Models.ExpenseModel", null)
                        .WithMany("CreatedBy")
                        .HasForeignKey("ExpenseModelId");

                    b.HasOne("BudgetWatcher.Models.RevenueModel", null)
                        .WithMany("CreatedBy")
                        .HasForeignKey("RevenueModelId");
                });

            modelBuilder.Entity("BudgetWatcher.Models.ExpenseModel", b =>
                {
                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("BudgetWatcher.Models.RevenueModel", b =>
                {
                    b.Navigation("CreatedBy");
                });
#pragma warning restore 612, 618
        }
    }
}