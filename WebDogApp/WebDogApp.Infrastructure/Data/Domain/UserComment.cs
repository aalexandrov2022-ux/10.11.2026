using System.ComponentModel.DataAnnotations;

namespace WebDogApp.Infrastructure.Data.Domain
{
    public class UserComment
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(500)]
        public string Comment { get; set; } = null!;
    }
}
