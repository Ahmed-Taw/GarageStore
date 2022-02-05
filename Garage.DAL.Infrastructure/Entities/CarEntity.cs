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
    public class CarEntity
    {
        [Key]
        [JsonProperty("_id")]
        public int Id { get; set; }
        public string Make { get; set; }

        public string Model { get; set; }

        [JsonProperty("year_model")]
        public int YearModel { get; set; }

        public double Price { get; set; }

        public bool Licensed { get; set; }

        [JsonProperty("date_added")]
        public DateTime DateAdded { get; set; }

        [ForeignKey("CarLocation")]
        public int CarLocationId { get; set; }
        public virtual CarLocationEntity CarLocation { get; set; }

    }
}
