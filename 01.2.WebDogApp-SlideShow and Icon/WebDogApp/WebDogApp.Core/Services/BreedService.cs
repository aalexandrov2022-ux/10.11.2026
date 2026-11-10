using WebDogApp.Core.Contracts;
using WebDogApp.Infrastructure.Data;
using WebDogApp.Infrastructure.Data.Domain;

namespace WebDogApp.Core.Services
{
    public class BreedService : IBreedService
    {
        private readonly ApplicationDbContext _context;

        public BreedService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Breed GetBreedById(int breedId)
        {
            return _context.Breeds.Find(breedId);
        }

        public List<Breed> GetBreeds()
        {
            List<Breed> breeds = _context.Breeds.ToList();
            return breeds;
        }

        public List<Dog> GetDogsByBreed(int breedId)
        {
            return _context.Dogs
                .Where(x => x.BreedId == breedId)
                .ToList();
        }
    }
}
