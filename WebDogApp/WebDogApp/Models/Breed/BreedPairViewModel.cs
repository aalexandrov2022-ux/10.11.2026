using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace WebDogApp.Models.Breed
{
    public class BreedPairViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Breed")]
        public string Name { get; set; } = null!;
    }
}
