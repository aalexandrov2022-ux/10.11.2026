using WebDogApp.Infrastructure.Data.Domain;

namespace WebDogApp.Core.Contracts
{
    public interface IBreedService
    {
        List<Breed> GetBreeds();
        Breed GetBreedById(int breedId);
        List<Dog> GetDogsByBreed(int breedId);
    }
}
