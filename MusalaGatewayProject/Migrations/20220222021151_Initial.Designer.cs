// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusalaGatewayProject.Context;

namespace MusalaGatewayProject.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220222021151_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("MusalaGatewayProject.Data.Gateway", b =>
                {
                    b.Property<Guid>("SerialNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SerialNumber");

                    b.ToTable("Gateways");
                });

            modelBuilder.Entity("MusalaGatewayProject.Data.PeripheralDevice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("GatewaySerialNumber")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Vendor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GatewaySerialNumber");

                    b.ToTable("PeripheralDevices");
                });

            modelBuilder.Entity("MusalaGatewayProject.Data.PeripheralDevice", b =>
                {
                    b.HasOne("MusalaGatewayProject.Data.Gateway", null)
                        .WithMany("PeripheralDevices")
                        .HasForeignKey("GatewaySerialNumber");
                });

            modelBuilder.Entity("MusalaGatewayProject.Data.Gateway", b =>
                {
                    b.Navigation("PeripheralDevices");
                });
#pragma warning restore 612, 618
        }
    }
}
