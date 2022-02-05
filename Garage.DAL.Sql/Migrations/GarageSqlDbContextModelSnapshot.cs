﻿// <auto-generated />
using System;
using Garage.DAL.Sql.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Garage.DAL.Sql.Migrations
{
    [DbContext(typeof(GarageSqlDbContext))]
    partial class GarageSqlDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Garage.DAL.Infrastructure.Entities.CarEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarLocationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Licensed")
                        .HasColumnType("bit");

                    b.Property<string>("Make")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("YearModel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarLocationId");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("Garage.DAL.Infrastructure.Entities.CarLocationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WarehouseId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("WarehouseId")
                        .IsUnique()
                        .HasFilter("[WarehouseId] IS NOT NULL");

                    b.ToTable("CarLocationEntity");
                });

            modelBuilder.Entity("Garage.DAL.Infrastructure.Entities.WarehouseEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Warehouse");
                });

            modelBuilder.Entity("Garage.DAL.Infrastructure.Entities.WarehouseLocationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Lat")
                        .HasPrecision(10, 8)
                        .HasColumnType("decimal(10,8)");

                    b.Property<decimal>("Long")
                        .HasPrecision(11, 8)
                        .HasColumnType("decimal(11,8)");

                    b.Property<string>("WarehouseId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("WarehouseId")
                        .IsUnique()
                        .HasFilter("[WarehouseId] IS NOT NULL");

                    b.ToTable("WarehouseLocationEntity");
                });

            modelBuilder.Entity("Garage.DAL.Infrastructure.Entities.CarEntity", b =>
                {
                    b.HasOne("Garage.DAL.Infrastructure.Entities.CarLocationEntity", "CarLocation")
                        .WithMany("Vehicles")
                        .HasForeignKey("CarLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarLocation");
                });

            modelBuilder.Entity("Garage.DAL.Infrastructure.Entities.CarLocationEntity", b =>
                {
                    b.HasOne("Garage.DAL.Infrastructure.Entities.WarehouseEntity", "Warehouse")
                        .WithOne("Cars")
                        .HasForeignKey("Garage.DAL.Infrastructure.Entities.CarLocationEntity", "WarehouseId");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("Garage.DAL.Infrastructure.Entities.WarehouseLocationEntity", b =>
                {
                    b.HasOne("Garage.DAL.Infrastructure.Entities.WarehouseEntity", "Warehouse")
                        .WithOne("Location")
                        .HasForeignKey("Garage.DAL.Infrastructure.Entities.WarehouseLocationEntity", "WarehouseId");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("Garage.DAL.Infrastructure.Entities.CarLocationEntity", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("Garage.DAL.Infrastructure.Entities.WarehouseEntity", b =>
                {
                    b.Navigation("Cars");

                    b.Navigation("Location");
                });
#pragma warning restore 612, 618
        }
    }
}