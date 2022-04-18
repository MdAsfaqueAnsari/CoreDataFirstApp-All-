using System.ComponentModel.DataAnnotations;

namespace CoreDataFirstApp.Models
{
    public class EmpModel
    {
        [Key]
        public int Sid { get; set; }
        [Required]
        public string Sname { get; set; }
        [Required]
        [EmailAddress]
        public string Smail { get; set; }
        [Required]
        public int? Smob { get; set; }
        [Required]
        public string City { get; set; }
    }
}
