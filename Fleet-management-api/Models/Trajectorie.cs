using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fleet_management_api.Models
{
	public class Trajectorie
	{
        [Key]
        public int Id { get; set; }

        public int TaxiId { get; set; }

        [ForeignKey("TaxiId")]
        public required Taxi Taxi { get; set; }

        
        public DateTime Date { get; set; }

        
        public double Latitude { get; set; }

        
        public double Longitude { get; set; }
    }
}

