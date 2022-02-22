using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusalaGatewayProject.Data;
using System;

namespace MusalaGatewayProject.Configuration
{
    public class PeripheralDeviceConfiguration : IEntityTypeConfiguration<PeripheralDevice>
    {
        public void Configure(EntityTypeBuilder<PeripheralDevice> builder)
        {
            builder.HasData(
                new PeripheralDevice
                {
                    Id = 1,
                    Vendor = "Nokia",
                    DateCreated = DateTime.Now,
                    Status = true,
                    //GatewayId = Guid.NewGuid(),
                },
                new PeripheralDevice
                {
                    Id = 2,
                    Vendor = "Alcatel",
                    DateCreated = DateTime.Now,
                    Status = true,
                    //GatewayId = Guid.NewGuid(),
                },
                 new PeripheralDevice
                 {
                     Id = 3,
                     Vendor = "Huawei",
                     DateCreated = DateTime.Now,
                     Status = false,
                     //GatewayId = Guid.NewGuid(),
                 }
                );
        }
    }
}
