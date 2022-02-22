using AutoMapper;
using MusalaGatewayProject.Data;
using MusalaGatewayProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusalaGatewayProject.Configuration
{
    public class AutomapperConfiguration : Profile
    {
        public AutomapperConfiguration()
        {
            CreateMap<Gateway, GatewayDTO>().ReverseMap();
            CreateMap<PeripheralDevice, PeripheralDeviceDTO>().ReverseMap();
            

        }
    }
}
