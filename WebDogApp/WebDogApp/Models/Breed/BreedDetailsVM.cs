using System.ComponentModel.DataAnnotations;

namespace WebDogApp.Models.Breed
{
    public class BreedDetailsVM
    {
        public int Id { get; set; }

        [Display(Name = "Breed Name")]
        public string Name { get; set; } = null!;

        [Display(Name = "Dogs Count")]
        public int DogsCount { get; set; }
    }
}
