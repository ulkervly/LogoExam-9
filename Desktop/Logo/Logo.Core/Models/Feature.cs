using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logo.Core.Models
{
    public class Feature:BaseEntity
    {
        public string? IconUrl {  get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(350)]
        public string Description { get; set; }
    }
}
