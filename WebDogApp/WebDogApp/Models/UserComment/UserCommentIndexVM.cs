using System.ComponentModel.DataAnnotations;

namespace WebDogApp.Models.UserComment
{
    public class UserCommentIndexVM
    {
        public int Id { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; } = null!;

        [Display(Name = "Email")]
        public string Email { get; set; } = null!;

        [Display(Name = "Comment")]
        public string Comment { get; set; } = null!;
    }
}
