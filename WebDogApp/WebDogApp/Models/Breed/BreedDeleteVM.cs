using System.ComponentModel.DataAnnotations;

namespace WebDogApp.Models.Breed
{
    public class BreedDeleteVM
    {
        public int Id { get; set; }

        [Display(Name = "Breed Name")]
        public string Name { get; set; } = null!;
    }
}
