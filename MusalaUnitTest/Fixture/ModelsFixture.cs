using MusalaGatewayProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusalaUnitTest.Fixture
{
    public static class ModelsFixture
    {
        public static List<Gateway> GetGateways() =>
            new()
            {
                new Gateway
                {
                    SerialNumber=new Guid("D8835792-079D-4BF6-A92A-4C68D7FFCC3D"),
                    Name= "Gateway-A",
                    IpAddress="192.168.1.1",
                    PeripheralDevices=new List<PeripheralDevice>()
                    {
                        new()
                        {
                             Id = 1,
                             Vendor = "Nokia",
                             DateCreated = DateTime.Now,
                             Status = true,
                        },
                        new()
                        {
                             Id = 2,
                             Vendor = "Huawei",
                             DateCreated = DateTime.Now,
                             Status = false,
                        }
                    }                    
                },
                new Gateway
                {
                    SerialNumber = new Guid("92AB451F-D3F5-4F9D-A53F-08D9F7D527FF"),
                    Name = "Gateway-B",
                    IpAddress = "10.10.100.2",
                    PeripheralDevices = new List<PeripheralDevice>()
                    {
                        new()
                        {
                             Id = 3,
                             Vendor = "Alcatel",
                             DateCreated = DateTime.Now,
                             Status = true,
                        },
                        new()
                        {
                             Id = 4,
                             Vendor = "Xiaomi",
                             DateCreated = DateTime.Now,
                             Status = false,
                        }
                    }
                }
            };

        public static List<PeripheralDevice> GetPeripheralDevices() =>
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
                }
            };
        
    }
}
