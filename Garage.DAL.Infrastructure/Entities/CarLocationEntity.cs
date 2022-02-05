using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.DAL.Infrastructure.Entities
{
    public class CarLocationEntity
    {
        [Key]
        public int Id { get; set; }
        public string Location { get; set; }

        [ForeignKey("Warehouse")]
        public string WarehouseId { get; set; }
        public virtual WarehouseEntity Warehouse { get; set; }
        public virtual ICollection<CarEntity> Vehicles { get; set; } 

    }
}
