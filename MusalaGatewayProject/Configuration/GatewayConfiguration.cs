using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusalaGatewayProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusalaGatewayProject.Configuration
{
    public class GatewayConfiguration : IEntityTypeConfiguration<Gateway>
    {
        public void Configure(EntityTypeBuilder<Gateway> builder)
        {
            builder.HasData(
                new Gateway
                {
                    SerialNumber = Guid.NewGuid(),
                    Name = "Gateway-A",
                    IpAddress = "192.168.1.1",                    
                },
                new Gateway
                {
                    SerialNumber = Guid.NewGuid(),
                    Name = "Gateway-B",
                    IpAddress = "192.168.2.1",
                },
                 new Gateway
                 {
                     SerialNumber = Guid.NewGuid(),
                     Name = "Gateway-C",
                     IpAddress = "192.168.3.1",
                 }
                );
        }
    }
}
