using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApplication1.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [DisplayName("User Name")]
        public string UName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string DOB { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string UPassword { get; set; }
        public string Img { get; set; }
    }
}
