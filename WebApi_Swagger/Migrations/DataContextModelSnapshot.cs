﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi_Swagger.Data;

namespace WebApi_Swagger.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10");

            modelBuilder.Entity("WebApi_Swagger.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Produto 1",
                            Price = 10m
                        },
                        new
                        {
                            Id = 2,
                            Description = "Produto 2",
                            Price = 20m
                        },
                        new
                        {
                            Id = 3,
                            Description = "Produto 3",
                            Price = 30m
                        },
                        new
                        {
                            Id = 4,
                            Description = "Produto 4",
                            Price = 40m
                        },
                        new
                        {
                            Id = 5,
                            Description = "Produto 5",
                            Price = 50m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
