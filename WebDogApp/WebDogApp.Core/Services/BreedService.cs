using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebDogApp.Core.Contacts;
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

        public bool Create(string name)
        {
            Breed item = new Breed
            {
                Name = name
            };

            _context.Breeds.Add(item);
            return _context.SaveChanges() != 0;
        }

        public Breed GetBreedById(int breedId)
        {
            return _context.Breeds.Find(breedId)!;
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

        public bool RemoveById(int breedId)
        {
            var breed = GetBreedById(breedId);
            if (breed == default(Breed))
            {
                return false;
            }
            _context.Breeds.Remove(breed);
            return _context.SaveChanges() != 0;
        }

        public bool UpdateBreed(int breedId, string name)
        {
            var breed = GetBreedById(breedId);
            if (breed == default(Breed))
            {
                return false;
            }
            breed.Name = name;
            _context.Breeds.Update(breed);
            return _context.SaveChanges() != 0;
        }
    }
}
