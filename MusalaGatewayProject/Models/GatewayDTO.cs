using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusalaGatewayProject.Models
{
    public class GatewayDTO
    {
        public Guid SerialNumber { get; set; }
        [Required]
        [StringLength(100, ErrorMessage ="The field name should have 100 characters or less")]
        public string Name { get; set; }
        [Required]
        public string IpAddress { get; set; }

        public IEnumerable<PeripheralDeviceDTO> PeripheralDevices { get; set; }
    }
}
