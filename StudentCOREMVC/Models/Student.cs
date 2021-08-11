using System.ComponentModel.DataAnnotations;

namespace StudentCOREMVC.Models
{
    public class Student
    {
        [Key]
        public int SID { get; set; }
        public string  Name { get; set; }
        public int Marks { get; set; }
    }
}
