using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.DAL.Infrastructure.Entities
{
    public class WarehouseEntity
    {
        [Key]
        [JsonProperty("_id")]
        public string Id { get; set; }
        public string Name { get; set; }
        public virtual WarehouseLocationEntity Location { get; set; }
        
        public virtual CarLocationEntity Cars { get; set; }
    }
}
