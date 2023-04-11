using System.ComponentModel.DataAnnotations;

namespace COMP003B.Assignment3.Models
{
    public class Person
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set;}
        [Required]
        [Range(0, 120)]
        public int Age { get; set;}

    }
}
