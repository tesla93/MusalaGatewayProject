using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusalaGatewayProject.Data
{
    public class Gateway
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SerialNumber { get; set; }
        public string Name { get; set; }
        public string IpAddress { get; set; }

        public virtual IEnumerable<PeripheralDevice> PeripheralDevices { get; set; }
    }
}
