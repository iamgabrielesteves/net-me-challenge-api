﻿// <auto-generated />
using System;
using MeChallenge.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MeChallenge.Infrastructure.Migrations
{
    [DbContext(typeof(MeChallengeContext))]
    [Migration("20220530150729_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MeChallenge.Domain.AggregatesModels.Order.Order", b =>
                {
                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid");

                    b.Property<int>("ItemsApproved")
                        .HasColumnType("integer");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("ValueApproved")
                        .HasColumnType("numeric");

                    b.HasKey("OrderId");

                    b.ToTable("Orders", "MeChallenge");
                });

            modelBuilder.Entity("MeChallenge.Domain.AggregatesModels.Product.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal>("UnitValue")
                        .HasColumnType("numeric");

                    b.HasKey("ProductId");

                    b.ToTable("Products", "MeChallenge");

                    b.HasData(
                        new
                        {
                            ProductId = new Guid("98ecf0f5-53ff-48f3-80d0-048059357bec"),
                            Description = "Lorem Ipsum",
                            Name = "T-shirt",
                            UnitValue = 50m
                        },
                        new
                        {
                            ProductId = new Guid("8832c3fc-ca04-476d-8ced-4d400f5bdf07"),
                            Description = "Lorem Ipsum",
                            Name = "Jacket",
                            UnitValue = 400m
                        },
                        new
                        {
                            ProductId = new Guid("09d92788-b384-4e6d-bce2-fcb9cf1928e9"),
                            Description = "Lorem Ipsum",
                            Name = "Glasses",
                            UnitValue = 250m
                        },
                        new
                        {
                            ProductId = new Guid("05077f8d-a577-47d6-9c92-6714332950e4"),
                            Description = "Lorem Ipsum",
                            Name = "Shorts",
                            UnitValue = 95m
                        },
                        new
                        {
                            ProductId = new Guid("58551994-7838-41c2-9928-480cc3bcf287"),
                            Description = "Lorem Ipsum",
                            Name = "Cap",
                            UnitValue = 35m
                        });
                });

            modelBuilder.Entity("MeChallenge.Domain.AggregatesModels.Order.Order", b =>
                {
                    b.OwnsMany("MeChallenge.Domain.AggregatesModels.Order.OrderProducts", "OrderProducts", b1 =>
                        {
                            b1.Property<Guid>("OrderId")
                                .HasColumnType("uuid");

                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uuid");

                            b1.Property<int>("Quantity")
                                .HasColumnType("integer");

                            b1.Property<decimal>("Value")
                                .HasColumnType("numeric");

                            b1.HasKey("OrderId", "ProductId");

                            b1.ToTable("OrderProducts", "MeChallenge");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.Navigation("OrderProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
