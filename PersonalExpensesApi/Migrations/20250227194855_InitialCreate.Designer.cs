﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PersonalExpensesApi.Data;

#nullable disable

namespace PersonalExpensesApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250227194855_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "uuid-ossp");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PersonalExpensesApi.Models.Account", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("KeycloakId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp");

                    b.HasKey("Id");

                    b.HasIndex("KeycloakId")
                        .IsUnique();

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("PersonalExpensesApi.Models.Expense", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid");

                    b.Property<string>("AccountId1")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp");

                    b.Property<int?>("CurrentInstallment")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<Guid?>("ExpenseKindId")
                        .HasColumnType("uuid");

                    b.Property<string>("ExpenseKindId1")
                        .HasColumnType("text");

                    b.Property<decimal?>("InstallmentValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("InstallmentsTotal")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<Guid?>("PaymentKindId")
                        .HasColumnType("uuid");

                    b.Property<string>("PaymentKindId1")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId1");

                    b.HasIndex("ExpenseKindId1");

                    b.HasIndex("PaymentKindId1");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("PersonalExpensesApi.Models.ExpenseKind", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp");

                    b.HasKey("Id");

                    b.ToTable("ExpenseKinds");
                });

            modelBuilder.Entity("PersonalExpensesApi.Models.PaymentKind", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("PaymentKind");
                });

            modelBuilder.Entity("PersonalExpensesApi.Models.Expense", b =>
                {
                    b.HasOne("PersonalExpensesApi.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PersonalExpensesApi.Models.ExpenseKind", "ExpenseKind")
                        .WithMany()
                        .HasForeignKey("ExpenseKindId1");

                    b.HasOne("PersonalExpensesApi.Models.PaymentKind", "PaymentKind")
                        .WithMany()
                        .HasForeignKey("PaymentKindId1");

                    b.Navigation("Account");

                    b.Navigation("ExpenseKind");

                    b.Navigation("PaymentKind");
                });
#pragma warning restore 612, 618
        }
    }
}
