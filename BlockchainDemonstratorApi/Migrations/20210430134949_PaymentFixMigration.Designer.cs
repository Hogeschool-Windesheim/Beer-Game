﻿// <auto-generated />
using BlockchainDemonstratorApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlockchainDemonstratorApi.Migrations
{
    [DbContext(typeof(BeerGameContext))]
    [Migration("20210430134949_PaymentFixMigration")]
    partial class PaymentFixMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlockchainDemonstratorApi.Models.Classes.Game", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CurrentDay")
                        .HasColumnType("int");

                    b.Property<int>("CurrentPhase")
                        .HasColumnType("int");

                    b.Property<string>("FarmerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ManufacturerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProcessorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RetailerId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("FarmerId");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("ProcessorId");

                    b.HasIndex("RetailerId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("BlockchainDemonstratorApi.Models.Classes.Option", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("CostOfMaintenance")
                        .HasColumnType("float");

                    b.Property<double>("CostOfStartUp")
                        .HasColumnType("float");

                    b.Property<double>("Flexibility")
                        .HasColumnType("float");

                    b.Property<double>("GuaranteedCapacity")
                        .HasColumnType("float");

                    b.Property<double>("LeadTime")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("BlockchainDemonstratorApi.Models.Classes.Order", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("ArrivalDay")
                        .HasColumnType("float");

                    b.Property<string>("DeliveryToPlayerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("HistoryOfPlayerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("OrderDay")
                        .HasColumnType("int");

                    b.Property<int>("OrderNumber")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("RequestForPlayerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Volume")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryToPlayerId");

                    b.HasIndex("HistoryOfPlayerId");

                    b.HasIndex("RequestForPlayerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BlockchainDemonstratorApi.Models.Classes.Payment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<double>("DueDay")
                        .HasColumnType("float");

                    b.Property<string>("PlayerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("ToPlayer")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("BlockchainDemonstratorApi.Models.Classes.Player", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<string>("CurrentOrderId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Inventory")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CurrentOrderId");

                    b.HasIndex("RoleId");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("BlockchainDemonstratorApi.Models.Classes.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("LeadTime")
                        .HasColumnType("float");

                    b.Property<int>("Product")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("BlockchainDemonstratorApi.Models.Classes.Game", b =>
                {
                    b.HasOne("BlockchainDemonstratorApi.Models.Classes.Player", "Farmer")
                        .WithMany()
                        .HasForeignKey("FarmerId");

                    b.HasOne("BlockchainDemonstratorApi.Models.Classes.Player", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("ManufacturerId");

                    b.HasOne("BlockchainDemonstratorApi.Models.Classes.Player", "Processor")
                        .WithMany()
                        .HasForeignKey("ProcessorId");

                    b.HasOne("BlockchainDemonstratorApi.Models.Classes.Player", "Retailer")
                        .WithMany()
                        .HasForeignKey("RetailerId");
                });

            modelBuilder.Entity("BlockchainDemonstratorApi.Models.Classes.Option", b =>
                {
                    b.HasOne("BlockchainDemonstratorApi.Models.Classes.Role", null)
                        .WithMany("Options")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("BlockchainDemonstratorApi.Models.Classes.Order", b =>
                {
                    b.HasOne("BlockchainDemonstratorApi.Models.Classes.Player", null)
                        .WithMany("IncomingDeliveries")
                        .HasForeignKey("DeliveryToPlayerId");

                    b.HasOne("BlockchainDemonstratorApi.Models.Classes.Player", null)
                        .WithMany("OrderHistory")
                        .HasForeignKey("HistoryOfPlayerId");

                    b.HasOne("BlockchainDemonstratorApi.Models.Classes.Player", null)
                        .WithMany("IncomingOrders")
                        .HasForeignKey("RequestForPlayerId");
                });

            modelBuilder.Entity("BlockchainDemonstratorApi.Models.Classes.Payment", b =>
                {
                    b.HasOne("BlockchainDemonstratorApi.Models.Classes.Player", null)
                        .WithMany("Payments")
                        .HasForeignKey("PlayerId");
                });

            modelBuilder.Entity("BlockchainDemonstratorApi.Models.Classes.Player", b =>
                {
                    b.HasOne("BlockchainDemonstratorApi.Models.Classes.Order", "CurrentOrder")
                        .WithMany()
                        .HasForeignKey("CurrentOrderId");

                    b.HasOne("BlockchainDemonstratorApi.Models.Classes.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });
#pragma warning restore 612, 618
        }
    }
}
