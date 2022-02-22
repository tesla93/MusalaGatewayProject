using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusalaGatewayProject.Models
{
    public class PeripheralDeviceDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(40, ErrorMessage = "The field Vendor should have 40 characters or less")]
        public string Vendor { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Status { get; set; }
        public Guid GatewayId { get; set; }

        public GatewayDTO GatewayNavigation { get; set; }
    }
}
