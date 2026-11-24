using System.ComponentModel.DataAnnotations;

namespace WebDogApp.Models.UserComment
{
    public class UserCommentCreateVM
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "User Name")]
        public string UserName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(500)]
        [Display(Name = "Comment")]
        public string Comment { get; set; } = null!;
    }
}
