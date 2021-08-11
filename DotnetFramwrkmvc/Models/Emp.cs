using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetFramwrkmvc.Models
{
    public class Emp
    {
        [Key]
        public int EID { get; set; }

        [Required]
        [StringLength(15,MinimumLength =2)]
        public string Name { get; set; }

        [Range(10000,55000)]
        public int Sal { get; set; }
    }
}
