using Microsoft.EntityFrameworkCore;
using MusalaGatewayProject.Configuration;
using MusalaGatewayProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusalaGatewayProject.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new GatewayConfiguration());
            //builder.ApplyConfiguration(new PeripheralDeviceConfiguration());

        }

        public DbSet<Gateway> Gateways{ get; set; }
        public DbSet<PeripheralDevice> PeripheralDevices{ get; set; }
    }
}
