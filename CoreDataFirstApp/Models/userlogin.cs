using System.ComponentModel.DataAnnotations;

namespace CoreDataFirstApp.Models
{
    public class userlogin
    {
        [Key]
        public int Sid { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        
        public string password { get; set; }
       
    }
}
