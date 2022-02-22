using MusalaGatewayProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusalaGatewayProject.Repository
{
    public interface IUnitOfWork: IDisposable
    {
        IGenericRepository<Gateway> Gateways { get; }
        IGenericRepository<PeripheralDevice> PeripheralDevices { get; }
        Task Save();
    }
}
