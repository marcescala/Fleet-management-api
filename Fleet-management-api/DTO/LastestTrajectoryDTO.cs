using System;
using Fleet_management_api.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fleet_management_api.DTO
{
	public class LastestTrajectoryDTO
	{
        public int Id { get; set; }

        public string? Plate { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public DateTime Date { get; set; }
    }
}

