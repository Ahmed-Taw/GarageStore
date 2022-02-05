using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.DAL.Infrastructure.Entities
{
    public class WarehouseLocationEntity
    {
        [Key]
        public int Id { get; set; }

        public decimal Lat { get; set; }
        public decimal Long { get; set; }
        
        [ForeignKey("Warehouse")]
        public string WarehouseId { get; set; }
        public virtual WarehouseEntity Warehouse { get; set; }

    }
}
