using MusalaGatewayProject.Data;
using MusalaGatewayProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusalaUnitTest.Fixture
{
    public static class ModelsGatewayFixture
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
                },
                new Gateway
                {
                    SerialNumber = Guid.NewGuid(),
                    Name = "Gateway-C",
                    IpAddress = "10.10.120.2",
                },
                new Gateway
                {
                    SerialNumber = Guid.NewGuid(),
                    Name = "Gateway-D",
                    IpAddress = "101.10.120.2",
                },
                new Gateway
                {
                    SerialNumber = Guid.NewGuid(),
                    Name = "Gateway-E",
                    IpAddress = "11.10.120.2",
                },
                new Gateway
                {
                    SerialNumber = Guid.NewGuid(),
                    Name = "Gateway-F",
                    IpAddress = "151.10.120.2",
                },
                new Gateway
                {
                    SerialNumber = Guid.NewGuid(),
                    Name = "Gateway-G",
                    IpAddress = "101.10.123.2",
                },
                new Gateway
                {
                    SerialNumber = Guid.NewGuid(),
                    Name = "Gateway-H",
                    IpAddress = "101.10.120.21",
                },
                new Gateway
                {
                    SerialNumber = Guid.NewGuid(),
                    Name = "Gateway-I",
                    IpAddress = "101.10.120.23",
                },
                new Gateway
                {
                    SerialNumber = Guid.NewGuid(),
                    Name = "Gateway-J",
                    IpAddress = "101.101.120.23",
                },

            };

        public static Gateway GetOneGateway() =>
            new Gateway()
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
            };

        public static GatewayDTO GetOneInvalidIpGatewayDTO() =>
            new GatewayDTO()
            {
                SerialNumber = new Guid("92AB451F-D3F5-4F9D-A53F-08D9F7D527FF"),
                Name = "Gateway-B",
                IpAddress = "10.10.100",                
            };

        public static GatewayDTO GetOneValidGatewayDTO() =>
           new GatewayDTO()
           {
               SerialNumber = new Guid("92AB451F-D3F5-4F9D-A53F-08D9F7D527FF"),
               Name = "Gateway-B",
               IpAddress = "10.10.100.1",
           };




    }
}
