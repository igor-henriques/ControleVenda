using System;
using System.ComponentModel.DataAnnotations;

namespace Infra.Models.Table
{
    public class Log
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
