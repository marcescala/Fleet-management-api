using System;
using System.ComponentModel.DataAnnotations;// Anotaciones de datos
using System.ComponentModel.DataAnnotations.Schema; // Atributos de mapeo de esquema

namespace Fleet_management_api.Models
{
    public class Trajectory
    {
        [Key]//Anotaciones de datos
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Valor de Id generado automaticamente
        public int Id { get; set; }

        public int TaxiId { get; set; }

        [ForeignKey("TaxiId")] // Atributos de mapeo de esquema
        public required Taxi Taxi { get; set; } // modificador required esta propiedad es obligatoria, no puede ser nula.


        public DateTime Date { get; set; }

        
        public double Latitude { get; set; }

        
        public double Longitude { get; set; }

  
    }
}

