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
    [Migration("20211209174047_AddedNewHistory")]
    partial class AddedNewHistory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlockchainDemonstratorApi.Models.Classes.Admin", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("BlockchainDemonstratorApi.Models.Classes.Delivery", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("ArrivalDay")
                        .HasColumnType("float");

                    b.Property<string>("OrderId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<bool>("Processed")
                        .HasColumnType("bit");

                    b.Property<int>("SendDeliveryDay")
                        .HasColumnType("int");

                    b.Property<int>("Volume")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Deliveries");
                });

            modelBuilder.Entity("BlockchainDemonstratorApi.Models.Classes.Factors", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("defaultInventory")
                        .HasColumnType("int");

                    b.Property<int>("farmerProductPrice")
                        .HasColumnType("int");

                    b.Property<int>("flushInventoryPrice")
                        .HasColumnType("int");

                    b.Property<int>("harvesterProductPrice")
                        .HasColumnType("int");

                    b.Property<double>("holdingFactor")
                        .HasColumnType("float");

                    b.Property<int>("initialCapital")
                        .HasColumnType("int");

                    b.Property<int>("manuProductPrice")
                        .HasColumnType("int");

                    b.Property<int>("procProductPrice")
                        .HasColumnType("int");

                    b.Property<int>("ratioAChance")
                        .HasColumnType("int");

                    b.Property<int>("ratioALeadtime")
                        .HasColumnType("int");

                    b.Property<int>("ratioBChance")
                        .HasColumnType("int");

                    b.Property<int>("ratioBLeadtime")
                        .HasColumnType("int");

                    b.Property<int>("ratioCChance")
                        .HasColumnType("int");

                    b.Property<int>("ratioCLeadtime")
                        .HasColumnType("int");

                    b.Property<int>("retailProductPrice")
                        .HasColumnType("int");

                    b.Property<int>("retailerOrderVolumeRandomMaximum")
                        .HasColumnType("int");

                    b.Property<int>("retailerOrderVolumeRandomMinimum")
                        .HasColumnType("int");

                    b.Property<int>("roundIncrement")
                        .HasColumnType("int");

                    b.Property<int>("setUpDeliveryVolume")
                        .HasColumnType("int");

                    b.Property<int>("setUpOrderVolume")
                        .HasColumnType("int");

                    b.Property<int>("setupCost")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Factors");
                });

            modelBuilder.Entity("BlockchainDemonstratorApi.Models.Classes.Game", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CurrentDay")
                        .HasColumnType("int");

                    b.Property<string>("FarmerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GameMasterId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("GameStarted")
                        .HasColumnType("bit");

                    b.Property<string>("ManufacturerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProcessorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RetailerId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("FarmerId");

                    b.HasIndex("GameMasterId");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("ProcessorId");

                    b.HasIndex("RetailerId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("BlockchainDemonstratorApi.Models.Classes.GameMaster", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.ToTable("GameMasters");
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

                    b.Property<double>("GuaranteedCapacityPenalty")
                        .HasColumnType("float");

                    b.Property<double>("LeadTime")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("TransportCostOneTrip")
                        .HasColumnType("float");

                    b.Property<double>("TransportCostPerDay")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("BlockchainDemonstratorApi.Models.Classes.Order", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IncomingOrderForPlayerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("OrderDay")
                        .HasColumnType("int");

                    b.Property<int>("OrderNumber")
                        .HasColumnType("int");

                    b.Property<string>("OutgoingOrderForPlayerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Volume")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IncomingOrderForPlayerId");

                    b.HasIndex("OutgoingOrderForPlayerId");

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

                    b.Property<bool>("FromPlayer")
                        .HasColumnType("bit");

                    b.Property<string>("PlayerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Topic")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("BlockchainDemonstratorApi.Models.Classes.Player", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Backorder")
                        .HasColumnType("int");

                    b.Property<string>("BackorderHistoryJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<string>("BalanceHistoryJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChosenOptionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CurrentOrderId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GrossProfitHistoryJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Inventory")
                        .HasColumnType("int");

                    b.Property<string>("InventoryHistoryJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Margin")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderWorthHistoryJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OverallProfitHistoryJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ChosenOptionId");

                    b.HasIndex("CurrentOrderId");

                    b.HasIndex("RoleId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("BlockchainDemonstratorApi.Models.Classes.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Product")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("BlockchainDemonstratorApi.Models.Classes.Delivery", b =>
                {
                    b.HasOne("BlockchainDemonstratorApi.Models.Classes.Order", null)
                        .WithMany("Deliveries")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BlockchainDemonstratorApi.Models.Classes.Game", b =>
                {
                    b.HasOne("BlockchainDemonstratorApi.Models.Classes.Player", "Farmer")
                        .WithMany()
                        .HasForeignKey("FarmerId");

                    b.HasOne("BlockchainDemonstratorApi.Models.Classes.GameMaster", null)
                        .WithMany("Games")
                        .HasForeignKey("GameMasterId");

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
                        .WithMany("IncomingOrders")
                        .HasForeignKey("IncomingOrderForPlayerId");

                    b.HasOne("BlockchainDemonstratorApi.Models.Classes.Player", null)
                        .WithMany("OutgoingOrders")
                        .HasForeignKey("OutgoingOrderForPlayerId");
                });

            modelBuilder.Entity("BlockchainDemonstratorApi.Models.Classes.Payment", b =>
                {
                    b.HasOne("BlockchainDemonstratorApi.Models.Classes.Player", null)
                        .WithMany("Payments")
                        .HasForeignKey("PlayerId");
                });

            modelBuilder.Entity("BlockchainDemonstratorApi.Models.Classes.Player", b =>
                {
                    b.HasOne("BlockchainDemonstratorApi.Models.Classes.Option", "ChosenOption")
                        .WithMany()
                        .HasForeignKey("ChosenOptionId");

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
