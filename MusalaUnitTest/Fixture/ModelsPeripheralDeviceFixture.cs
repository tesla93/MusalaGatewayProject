using MusalaGatewayProject.Data;
using MusalaGatewayProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusalaUnitTest.Fixture
{
    public static class ModelsPeripheralDeviceFixture
    {
        public static List<PeripheralDevice> GetTenPeripheralDevices() =>
            new()
            {
                new PeripheralDevice()
                {
                    Id = 1,
                    Vendor = "Nokia",
                    DateCreated = DateTime.Now,
                    Status = true,
                    GatewayId = new Guid("D8835792-079D-4BF6-A92A-4C68D7FFCC3D")
                },
                new PeripheralDevice()
                {
                    Id = 2,
                    Vendor = "Huawei",
                    DateCreated = DateTime.Now,
                    Status = false,
                    GatewayId = new Guid("D8835792-079D-4BF6-A92A-4C68D7FFCC3D")
                },
                new PeripheralDevice()
                {
                    Id = 3,
                    Vendor = "Huawei1",
                    DateCreated = DateTime.Now,
                    Status = false,
                    GatewayId = new Guid("D8835792-079D-4BF6-A92A-4C68D7FFCC3D")
                },
                new PeripheralDevice()
                {
                    Id = 4,
                    Vendor = "Huawei2",
                    DateCreated = DateTime.Now,
                    Status = false,
                    GatewayId = new Guid("D8835792-079D-4BF6-A92A-4C68D7FFCC3D")
                },
                new PeripheralDevice()
                {
                    Id = 5,
                    Vendor = "Huawei6",
                    DateCreated = DateTime.Now,
                    Status = false,
                    GatewayId = new Guid("D8835792-079D-4BF6-A92A-4C68D7FFCC3D")
                },
                new PeripheralDevice()
                {
                    Id = 6,
                    Vendor = "Huawei7",
                    DateCreated = DateTime.Now,
                    Status = false,
                    GatewayId = new Guid("D8835792-079D-4BF6-A92A-4C68D7FFCC3D")
                },
                new PeripheralDevice()
                {
                    Id = 7,
                    Vendor = "Huawei8",
                    DateCreated = DateTime.Now,
                    Status = false,
                    GatewayId = new Guid("D8835792-079D-4BF6-A92A-4C68D7FFCC3D")
                },
                new PeripheralDevice()
                {
                    Id = 8,
                    Vendor = "Huawei9",
                    DateCreated = DateTime.Now,
                    Status = false,
                    GatewayId = new Guid("D8835792-079D-4BF6-A92A-4C68D7FFCC3D")
                },
                new PeripheralDevice()
                {
                    Id = 9,
                    Vendor = "Huawei10",
                    DateCreated = DateTime.Now,
                    Status = false,
                    GatewayId = new Guid("D8835792-079D-4BF6-A92A-4C68D7FFCC3D")
                },
                new PeripheralDevice()
                {
                    Id = 10,
                    Vendor = "Huawei11",
                    DateCreated = DateTime.Now,
                    Status = false,
                    GatewayId = new Guid("D8835792-079D-4BF6-A92A-4C68D7FFCC3D")
                },
            };

        public static PeripheralDevice GetOnePeripheralDevice() =>
           new PeripheralDevice()
           {
               Id = 1,
               Vendor = "Nokia",
               DateCreated = DateTime.Now,
               Status = true,
               GatewayId = new Guid("D8835792-079D-4BF6-A92A-4C68D7FFCC3D")
           };

        public static PeripheralDeviceDTO GetOnePeripheralDeviceDTO() =>
           new PeripheralDeviceDTO()
           {
               Id = 1,
               Vendor = "Nokia",
               DateCreated = DateTime.Now,
               Status = true,
               GatewayId = new Guid("D8835792-079D-4BF6-A92A-4C68D7FFCC3D")
           };
    }
}
