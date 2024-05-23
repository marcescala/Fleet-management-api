using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Hosting;

namespace Fleet_management_api.Models
{
	public class Taxi
	{
        [Key]
        public int Id { get; set; }

        public string? Plate { get; set; }

        public ICollection<Trajectory>? Trajectories;
    }
}

