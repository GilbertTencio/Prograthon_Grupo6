using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationAPP.Models
{
    public class Laboratory
    {
        public int IdLaboratory { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Range(1, 500)]
        public int Capacity { get; set; }

        [Required]
        [StringLength(150)]
        public string Responsible { get; set; }
        public Laboratory() { }
        public Laboratory(int id, string name, int capacity, string responsible)
        {
            IdLaboratory = id;
            Name = name;
            Capacity = capacity;
            Responsible = responsible;
        }
    }
}