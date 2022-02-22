using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MusalaGatewayProject.Data
{
    public class PeripheralDevice
    {
        [Key]
        public int Id { get; set; }
        public string Vendor { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Status { get; set; }
        public Guid GatewayId { get; set; }

        [ForeignKey(nameof(GatewayId))]
        public virtual Gateway GatewayNavigation { get; set; }
    }
}
