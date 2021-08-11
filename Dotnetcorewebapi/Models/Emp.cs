using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dotnetcorewebapi.Models
{
    public class Employees
    {
        [Key]
        public int EID { get; set; }
        public string EName { get; set; }
        public int ESal { get; set; }
    }
}
