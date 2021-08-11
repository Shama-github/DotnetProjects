using System.ComponentModel.DataAnnotations;


namespace Entityframeworkcoremvc.Models
{
    public class Emp
    {
        [Key]
        public int EID { get; set; }
        public string EName { get; set; }
        public int ESal { get; set; }
    }
}
