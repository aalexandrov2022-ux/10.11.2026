using System.ComponentModel.DataAnnotations;

namespace WebDogApp.Models.Breed
{
    public class BreedCreateVM
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Breed Name")]
        public string Name { get; set; } = null!;
    }
}
