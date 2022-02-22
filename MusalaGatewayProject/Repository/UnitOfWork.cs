using MusalaGatewayProject.Context;
using MusalaGatewayProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusalaGatewayProject.Repository
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly DatabaseContext _context;
        private IGenericRepository<Gateway> _gateways;
        private IGenericRepository<PeripheralDevice> _peripheralDevices;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }
        public IGenericRepository<Gateway> Gateways => _gateways ??= new GenericRepository<Gateway>(_context);

        public IGenericRepository<PeripheralDevice> PeripheralDevices => _peripheralDevices ??= new GenericRepository<PeripheralDevice>(_context);

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

       
    }
}
